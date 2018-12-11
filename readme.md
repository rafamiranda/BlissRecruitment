
BlissRecruitment Configuration Document

DB Set up

	1 - Create a DB named BlissRecruitmentDatabase
	
	2 - Run the following script (Creates Question and Choices tables):
		./Scripts/DB_Tables_Drop_Create.sql

WebApi Configurations

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


