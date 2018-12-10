using BlissRecruitment.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlissRecruitment.Managers
{
    public interface IQuestionsManager
    {
        #region Methods

        IEnumerable<QuestionEntity> LoadAllQuestions();

        QuestionEntity LoadQuestion(int id);

        Task<ActionResult<QuestionEntity>> SaveQuestion(QuestionViewModel question);

        Task<ActionResult<QuestionEntity>> UpdateQuestion(int id, QuestionEntity question);

        #endregion
    }
}
