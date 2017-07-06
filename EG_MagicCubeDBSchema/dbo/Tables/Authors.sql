CREATE TABLE [dbo].[Authors](
	[AuthorsNo] [int] IDENTITY(1,1) NOT NULL,
	[MaterialsID] [nvarchar](20) NOT NULL,
	[AuthorsCName] [nvarchar](50) NOT NULL,
	[AuthorsEName] [nvarchar](50) NOT NULL,
	[CreateUser] [nvarchar](50) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ModifyUser] [nvarchar](50) NOT NULL,
	[ModifyDate] [datetime] NULL,
 CONSTRAINT [PK_AuthorList] PRIMARY KEY CLUSTERED 
(
	[AuthorsNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Authors] ADD  DEFAULT ('') FOR [MaterialsID]
GO
ALTER TABLE [dbo].[Authors] ADD  DEFAULT ('') FOR [AuthorsCName]
GO
ALTER TABLE [dbo].[Authors] ADD  DEFAULT ('') FOR [AuthorsEName]
GO
ALTER TABLE [dbo].[Authors] ADD  DEFAULT ('') FOR [CreateUser]
GO
ALTER TABLE [dbo].[Authors] ADD  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Authors] ADD  DEFAULT ('') FOR [ModifyUser]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'藝術家序號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Authors', @level2type=N'COLUMN',@level2name=N'AuthorsNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物料代碼,來至於SAP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Authors', @level2type=N'COLUMN',@level2name=N'MaterialsID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'藝術家中文名稱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Authors', @level2type=N'COLUMN',@level2name=N'AuthorsCName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'藝術家外文名稱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Authors', @level2type=N'COLUMN',@level2name=N'AuthorsEName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'建立者' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Authors', @level2type=N'COLUMN',@level2name=N'CreateUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'建立時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Authors', @level2type=N'COLUMN',@level2name=N'CreateDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改者' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Authors', @level2type=N'COLUMN',@level2name=N'ModifyUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Authors', @level2type=N'COLUMN',@level2name=N'ModifyDate'