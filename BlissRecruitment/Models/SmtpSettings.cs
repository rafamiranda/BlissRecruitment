namespace BlissRecruitment.Models
{
    public class SmtpSettings
    {
        public SmtpSettings(string smtpServer, int smtpPort, string emailFrom, string subject, string message)
        {
            SmtpPort = smtpPort;
            SmtpServer = smtpServer;
            EmailFrom = emailFrom;
            Subject = subject;
            Message = message;
        }

        #region Properties

        public string SmtpServer { get; }

        public  int SmtpPort { get; }

        public string EmailFrom { get; }

        public  string Subject { get; }

        public  string Message { get; }

        #endregion
    }
}
