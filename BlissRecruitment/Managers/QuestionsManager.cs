using BlissRecruitment.Models;
using BlissRecruitment.Providers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlissRecruitment.Managers
{
    public class QuestionsManager : IQuestionsManager
    {
        #region Constructor
        public QuestionsManager(IQuestionsProvider questionsProvider)
        {
            QuestionsProvider = questionsProvider;
        }
        #endregion

        #region Properties

        public IQuestionsProvider QuestionsProvider { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        /// Loads all questions
        /// </summary>
        /// <returns>Questions</returns>
        public IEnumerable<QuestionEntity> LoadAllQuestions()
        {
            return QuestionsProvider.LoadAllQuestions();
        }

        /// <summary>
        /// Loads a question
        /// </summary>
        /// <param name="id">question id</param>
        /// <returns>Question</returns>
        public QuestionEntity LoadQuestion(int id)
        {
            return QuestionsProvider.LoadQuestion(id);
        }

        /// <summary>
        /// Saves a question and its choices
        /// </summary>
        /// <param name="questionToUpdate">The question to be saved</param>
        /// <returns>True if succeeded</returns>
        public async Task<ActionResult<QuestionEntity>> SaveQuestion(QuestionViewModel question)
        {
            try
            {
                QuestionEntity eQuestion = new QuestionEntity
                {
                    Id = question.Id,
                    ImageUrl = question.ImageUrl,
                    ThumbUrl = question.ThumbUrl,
                    Published = DateTime.UtcNow,
                    Question = question.Question
                };

                List<ChoiceEntity> choices = new List<ChoiceEntity>();
                foreach (string sChoice in question.Choices)
                {
                    choices.Add(new ChoiceEntity { Choice = sChoice, QuestionEntityId = eQuestion.Id });
                }

                eQuestion.Choices = choices;

                bool result = await QuestionsProvider.SaveQuestion(eQuestion);

                ActionResult<QuestionEntity> actionResult = new ActionResult<QuestionEntity>(eQuestion);

                return actionResult;
            }
            catch (Exception e)
            {
                string message = e.Message;
                //TODO: LogError
                return new ObjectResult(null);
            }
        }

        /// <summary>
        /// Updates a question and its choices
        /// </summary>
        /// <param name="questionToUpdate">The question to be updated</param>
        /// <returns>True if succeeded</returns>
        public async Task<ActionResult<QuestionEntity>> UpdateQuestion(int id, QuestionEntity question)
        {
            try
            {
                question.Id = id;
                question.Published = DateTime.UtcNow;

                bool result = await QuestionsProvider.UpdateQuestion(question);
                ActionResult<QuestionEntity> actionResult = new ActionResult<QuestionEntity>(question);
                return actionResult;
            }
            catch (Exception e)
            {
                string message = e.Message;
                //TODO: LogError
                return new ObjectResult(null);
            }
        }
        #endregion
    }
}