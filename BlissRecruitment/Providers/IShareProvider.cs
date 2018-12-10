using BlissRecruitment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlissRecruitment.Providers
{
    public interface IShareProvider
    {
        #region Methods

        /// <summary>
        /// Sends an email
        /// </summary>
        /// <param name="emailAddress">email address</param>
        /// <param name="urlContent">url content</param>
        /// <returns>True if success</returns>
        bool SendEmail(string emailAddress, string urlContent);

        #endregion
    }
}
