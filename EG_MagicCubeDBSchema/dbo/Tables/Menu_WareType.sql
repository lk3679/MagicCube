CREATE TABLE [dbo].[Menu_WareType](
	[WareTypeNo] [int] IDENTITY(1,1) NOT NULL,
	[WareTypeName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Menu_WareType] PRIMARY KEY CLUSTERED 
(
	[WareTypeNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Menu_WareType] ADD  CONSTRAINT [DF_Menu_WareType_WareType_Name]  DEFAULT ('') FOR [WareTypeName]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'庫別編號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu_WareType', @level2type=N'COLUMN',@level2name=N'WareTypeNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'庫別名稱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu_WareType', @level2type=N'COLUMN',@level2name=N'WareTypeName'