using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlissRecruitment.Models;
using System.Net;
using BlissRecruitment.Managers;
using Microsoft.Extensions.Configuration;

namespace BlissRecruitment.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShareController : ControllerBase
    {
        #region Constructor 

        public ShareController(IShareManager shareManager)
        {
            ShareManager = shareManager;
        }

        #endregion

        #region Properties

        protected IShareManager ShareManager { get; }

        #endregion

        #region Methods
        // POST: share
        /// <summary>
        /// Shares a url
        /// </summary>
        /// <param name="email"></param>
        /// <param name="contentUrl"></param>
        /// <returns></returns>
        [HttpPost]        
        public ActionResult Post([FromQuery] string email, [FromQuery] string contentUrl)
        {
            if (ShareManager.SendEmail(email, contentUrl))
            {
                var result = StatusCode((int) HttpStatusCode.OK, new { status = "OK" } );
                return result;
            }
            else
            {
                var result = StatusCode((int) HttpStatusCode.BadRequest);
                return result;
            }
        }
        #endregion
    }
}
