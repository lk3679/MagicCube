CREATE TABLE [dbo].[Menu_AuthorsTag](
	[AuthorsTagNo] [int] IDENTITY(1,1) NOT NULL,
	[AuthorsTagName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Menu_AuthorTag] PRIMARY KEY CLUSTERED 
(
	[AuthorsTagNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Menu_AuthorsTag] ADD  CONSTRAINT [DF_Menu_AuthorTag_AuthorTag_Name]  DEFAULT ('') FOR [AuthorsTagName]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'藝術家標籤編號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu_AuthorsTag', @level2type=N'COLUMN',@level2name=N'AuthorsTagNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'藝術家標籤名稱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu_AuthorsTag', @level2type=N'COLUMN',@level2name=N'AuthorsTagName'