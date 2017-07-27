CREATE TABLE [dbo].[Menu_Owner](
	[OwnerNo] [int] IDENTITY(1,1) NOT NULL,
	[OwnerName] [nvarchar](50) NOT NULL,
	[IsDel] VARCHAR(5) NOT NULL DEFAULT (''), 
 CONSTRAINT [PK_Menu_Owner] PRIMARY KEY CLUSTERED 
(
	[OwnerNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Menu_Owner] ADD  CONSTRAINT [DF_Menu_Owner_Owner_Name]  DEFAULT ('') FOR [OwnerName]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所有人編號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu_Owner', @level2type=N'COLUMN',@level2name=N'OwnerNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所有人名稱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu_Owner', @level2type=N'COLUMN',@level2name=N'OwnerName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'是否刪除，Y:刪除',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Menu_Owner',
    @level2type = N'COLUMN',
    @level2name = N'IsDel'