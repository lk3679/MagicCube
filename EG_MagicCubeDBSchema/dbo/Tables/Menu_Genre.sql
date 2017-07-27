CREATE TABLE [dbo].[Menu_Genre](
	[GenreNo] [int] IDENTITY(1,1) NOT NULL,
	[GenreName] [nvarchar](50) NOT NULL,
	[IsDel] VARCHAR(5) NOT NULL DEFAULT (''), 
 CONSTRAINT [PK_Menu_Genre] PRIMARY KEY CLUSTERED 
(
	[GenreNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Menu_Genre] ADD  CONSTRAINT [DF_Menu_Genre_Genre_Name]  DEFAULT ('') FOR [GenreName]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'類型編號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu_Genre', @level2type=N'COLUMN',@level2name=N'GenreNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'類型名稱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu_Genre', @level2type=N'COLUMN',@level2name=N'GenreName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'是否刪除，Y:刪除',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Menu_Genre',
    @level2type = N'COLUMN',
    @level2name = N'IsDel'