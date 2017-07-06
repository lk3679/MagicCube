CREATE TABLE [dbo].[Menu_Style](
	[StyleNo] [int] IDENTITY(1,1) NOT NULL,
	[StyleName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Menu_Style] PRIMARY KEY CLUSTERED 
(
	[StyleNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Menu_Style] ADD  CONSTRAINT [DF_Menu_Style_Style_Name]  DEFAULT ('') FOR [StyleName]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'風格編號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu_Style', @level2type=N'COLUMN',@level2name=N'StyleNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'風格名稱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu_Style', @level2type=N'COLUMN',@level2name=N'StyleName'