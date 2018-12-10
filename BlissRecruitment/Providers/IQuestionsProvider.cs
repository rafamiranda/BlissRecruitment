using BlissRecruitment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlissRecruitment.Providers
{
    public interface IQuestionsProvider
    {
        #region Methods

        IEnumerable<QuestionEntity> LoadAllQuestions();

        QuestionEntity LoadQuestion(int id);

        Task<bool> SaveQuestion(QuestionEntity question);

        Task<bool> UpdateQuestion(QuestionEntity questionToUpdate);
        #endregion
    }
}
