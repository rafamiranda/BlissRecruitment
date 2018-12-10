using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using BlissRecruitment.Providers;
using BlissRecruitment.Models;

namespace BlissRecruitment.Managers
{
    public class ShareManager : IShareManager
    {
        #region Constructor

        public ShareManager(IShareProvider shareProvider)
        {
            ShareProvider = shareProvider;
        }
        #endregion

        #region Properties
        public IShareProvider ShareProvider { get; private set; }
        #endregion

        #region Methods

        /// <summary>
        /// Sends an email
        /// </summary>
        /// <param name="emailAddress">email address</param>
        /// <param name="urlContent">url content</param>
        /// <returns>True if success</returns>
        public bool SendEmail(string emailAddress, string urlContent)
        {
            return ShareProvider.SendEmail(emailAddress, urlContent);
        }
        #endregion
    }
}