USE [BlissRecruitmentDatabase]
GO

IF(Object_ID('Choices') is NOT null)
BEGIN 
	DROP TABLE [dbo].[Choices]
END

IF(Object_ID('Questions') is NOT null)
BEGIN 
	DROP TABLE [dbo].[Questions]
END
GO

/****** Object:  Table [dbo].[Questions]    Script Date: 12/11/2018 12:11:52 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Questions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Question] [nvarchar](max) NULL,
	[ImageUrl] [nvarchar](max) NULL,
	[ThumbUrl] [nvarchar](max) NULL,
	[Published] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Questions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


ALTER TABLE [dbo].[Choices] DROP CONSTRAINT [FK_Choices_Questions_QuestionEntityId]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Choices](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Choice] [nvarchar](max) NULL,
	[Votes] [int] NOT NULL,
	[QuestionEntityId] [int] NULL,
 CONSTRAINT [PK_Choices] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[Choices]  WITH CHECK ADD  CONSTRAINT [FK_Choices_Questions_QuestionEntityId] FOREIGN KEY([QuestionEntityId])
REFERENCES [dbo].[Questions] ([Id])
GO

ALTER TABLE [dbo].[Choices] CHECK CONSTRAINT [FK_Choices_Questions_QuestionEntityId]
GO


