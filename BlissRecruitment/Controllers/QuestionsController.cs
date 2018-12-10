using BlissRecruitment.Managers;
using BlissRecruitment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace BlissRecruitment.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        #region Constructor
        public QuestionsController(IQuestionsManager questionsManager)
        {
            QuestionsManager = questionsManager;
        }
        #endregion

        #region Properties

        protected IQuestionsManager QuestionsManager { get; }

        #endregion

        #region Methods

        // GET: questions
        [HttpGet]
        public ActionResult<IEnumerable<QuestionEntity>> Get([FromQuery] string limit = "", [FromQuery] string offset = "", [FromQuery] string filter = "")
        {
            //List<QuestionEntity> questionsList = QuestionsManager.LoadAllQuestions();
            //questionsList.Take
            IEnumerable<QuestionEntity> questions = QuestionsManager.LoadAllQuestions();
            if (questions == null)
                return NotFound(new { status = "Questions not found" });

            return StatusCode((int)HttpStatusCode.OK, questions);
        }

        // GET: questions/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            QuestionEntity question = QuestionsManager.LoadQuestion(id);
            if (question == null)
                return NotFound(new { status = "Question not found" });

            return StatusCode((int)HttpStatusCode.OK, question);
        }

        // POST: questions
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] QuestionViewModel question)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode((int)HttpStatusCode.BadRequest);
            }

            ActionResult<QuestionEntity> actionResult = await QuestionsManager.SaveQuestion(question);

            if (actionResult == null || actionResult.Value == null)
                return StatusCode((int) HttpStatusCode.InternalServerError);

            return StatusCode((int) HttpStatusCode.Created, actionResult.Value); ;
        }

        // PUT: questions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] QuestionEntity question)
        {
            if (!ModelState.IsValid || id <= 0) 
            {
                return StatusCode((int) HttpStatusCode.BadRequest);
            }

            ActionResult<QuestionEntity> actionResult = await QuestionsManager.UpdateQuestion(id, question);

            if (actionResult == null || actionResult.Value == null)
                return StatusCode((int) HttpStatusCode.InternalServerError);

            return StatusCode((int) HttpStatusCode.Created, actionResult.Value);
        }

        #endregion
    }
}
