CREATE TABLE [dbo].[Menu_AuthorsArea](
	[AuthorsAreaNo] [int] IDENTITY(1,1) NOT NULL,
	[AuthorsAreaName] [nvarchar](50) NOT NULL,
	[IsDel] VARCHAR(5) NOT NULL DEFAULT (''), 
 CONSTRAINT [PK_Menu_AuthorArea] PRIMARY KEY CLUSTERED 
(
	[AuthorsAreaNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Menu_AuthorsArea] ADD  CONSTRAINT [DF_Menu_AuthorArea_AuthorArea_Name]  DEFAULT ('') FOR [AuthorsAreaName]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'藝術家區域編號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu_AuthorsArea', @level2type=N'COLUMN',@level2name=N'AuthorsAreaNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'藝術家區域名稱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu_AuthorsArea', @level2type=N'COLUMN',@level2name=N'AuthorsAreaName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'是否刪除，Y:刪除',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Menu_AuthorsArea',
    @level2type = N'COLUMN',
    @level2name = N'IsDel'