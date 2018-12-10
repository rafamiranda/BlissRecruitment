DB Set up

	Run script in the following order:

	db01.sql
		- Configure Physical file path for db data and log data.
		Ex.:
		[DbDataFilePath] = "C:\db"
		[LogDataFilePath] = "C:\log"


	db02.sql


Database Configuration:
	Configure connection string section in ConnectionStrings at appsettings.json:
	Ex.:
	"ConnectionStrings": {
		"BlissRecruitmentDatabase": "Server=(localdb)\\mssqllocaldb;Database=BlissRecruitmentDatabase;Trusted_Connection=True;"
		}

SMTP Configs
	Configure SMTP Settings and emails settings in SmtpSettings section at appsettings.json:
	
	SmtpServer - Smtp server host address
	SmtpPort : Smtp Port
	EmailFrom: Email From 
	Subject: Subject of the message
	Message: Message (It also concatenates with the url content to be shared)
	
	Ex.:
	"SmtpSettings": {
		"SmtpServer": "localhost",
		"SmtpPort": "25",
		"EmailFrom": "rafael.miranda@blissapplications.com",
		"Subject": "Share Url Test",
		"Message": "Test Message to Share Question URL Content"
		}


