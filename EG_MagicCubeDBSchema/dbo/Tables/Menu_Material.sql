CREATE TABLE [dbo].[Menu_Material](
	[MaterialNo] [int] IDENTITY(1,1) NOT NULL,
	[MaterialName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Menu_Material] PRIMARY KEY CLUSTERED 
(
	[MaterialNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Menu_Material] ADD  CONSTRAINT [DF_Menu_Material_Material_Name]  DEFAULT ('') FOR [MaterialName]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'媒材編號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu_Material', @level2type=N'COLUMN',@level2name=N'MaterialNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'媒材名稱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu_Material', @level2type=N'COLUMN',@level2name=N'MaterialName'