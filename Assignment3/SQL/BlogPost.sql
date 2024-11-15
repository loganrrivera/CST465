CREATE TABLE [dbo].[BlogPost](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](200) NOT NULL,
	[Content] [varchar](max) NOT NULL,
	[Author] [varchar](100) NOT NULL,
	[Timestamp] [datetime] NOT NULL,
 CONSTRAINT [PK_BlogPost] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[BlogPost] ADD  CONSTRAINT [DF_BlogPost_Timestamp]  DEFAULT (getdate()) FOR [Timestamp]
GO

CREATE PROCEDURE BlogPost_InsertUpdate
(
	@ID int = NULL,
	@Title varchar(200),
	@Content varchar(MAX),
	@Author varchar(100)
)
AS
BEGIN
	IF @ID IS NULL
	BEGIN
	INSERT INTO BlogPost(Title, Content, Author) VALUES (@Title, @Content, @Author)
	END
	ELSE
	BEGIN
	UPDATE BlogPost SET Title=@Title, Content=@Content, Author=@Author
	WHERE ID=@ID
	END
END
GO
CREATE PROCEDURE BlogPost_GetList
AS
BEGIN
	SELECT *
	FROM BlogPost
	ORDER BY Timestamp DESC 
END