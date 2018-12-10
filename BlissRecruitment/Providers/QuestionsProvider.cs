using BlissRecruitment.DataAccess;
using BlissRecruitment.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlissRecruitment.Providers
{
    public class QuestionsProvider : IQuestionsProvider
    {
        #region Constructor

        public QuestionsProvider(BlissRecruitmentDBContext dbContext)
        {
            BlissRecruitmentDBContext = dbContext;
        }

        #endregion

        #region Properties

        public BlissRecruitmentDBContext BlissRecruitmentDBContext { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Loads all questions
        /// </summary>
        /// <returns>Questions</returns>
        public IEnumerable<QuestionEntity> LoadAllQuestions()
        {
            //var result = from question in BlissRecruitmentDBContext.Questions
            //             join choice in BlissRecruitmentDBContext.Choices
            //             on question.Id equals choice.QuestionEntityId
            //             select new QuestionEntity
            //             {
            //                 Id = question.Id,
            //                 ImageUrl = question.ImageUrl,
            //                 Published = question.Published,
            //                 Question = question.Question,
            //                 ThumbUrl = question.ThumbUrl,
            //                 Choices = BlissRecruitmentDBContext.Choices.TakeWhile<ChoiceEntity>(c => c.QuestionEntityId == question.Id).ToList()
            //             };


            List<QuestionEntity> result = BlissRecruitmentDBContext.Questions.Include(question => question.Choices).ToList();
            return result;
        }

        /// <summary>
        /// Loads a question
        /// </summary>
        /// <param name="id">question id</param>
        /// <returns>Question</returns>
        public QuestionEntity LoadQuestion(int id)
        {
            QuestionEntity result = BlissRecruitmentDBContext.Questions.Include(question => question.Choices).SingleOrDefault(q => q.Id == id);
            return result;
        }

        /// <summary>
        /// Saves a question and its choices
        /// </summary>
        /// <param name="questionToUpdate">The question to be saved</param>
        /// <returns>True if succeeded</returns>
        public async Task<bool> SaveQuestion(QuestionEntity question)
        {
            BlissRecruitmentDBContext.Questions.Add(question);
            int result = await BlissRecruitmentDBContext.SaveChangesAsync();

            return result > -1;
        }

        /// <summary>
        /// Updates a question and its choices
        /// </summary>
        /// <param name="questionToUpdate">The question to be updated</param>
        /// <returns>True if succeeded</returns>
        public async Task<bool> UpdateQuestion(QuestionEntity questionToUpdate)
        {
            var question = await BlissRecruitmentDBContext.Questions
                .Include(q => q.Choices)
                .SingleOrDefaultAsync(c => c.Id == questionToUpdate.Id);

            question.Question = questionToUpdate.Question;
            question.ImageUrl = questionToUpdate.ImageUrl;
            question.ThumbUrl = questionToUpdate.ThumbUrl;

            //BlissRecruitmentDBContext.Entry(question).CurrentValues.SetValues(questionToUpdate);
            var questionChoices = question.Choices.ToList();

            foreach (var questionChoice in questionChoices)
            {
                var choice = questionToUpdate.Choices.SingleOrDefault(i => i.Id == questionChoice.Id || i.Choice == questionChoice.Choice);
                if (choice != null)
                {
                    choice.Id = questionChoice.Id;
                    choice.QuestionEntityId = questionChoice.QuestionEntityId;
                    BlissRecruitmentDBContext.Entry(questionChoice).CurrentValues.SetValues(choice);
                }
                    
                else
                    BlissRecruitmentDBContext.Remove(questionChoice);
            }
            // add the new items
            foreach (var choice in questionToUpdate.Choices)
            {
                if (questionChoices.All(i => i.Id != choice.Id || i.Choice != choice.Choice))
                {
                    question.Choices.Add(choice);
                }
            }

            int result =  await BlissRecruitmentDBContext.SaveChangesAsync();
            return result > -1;
        }
        #endregion
    }
}