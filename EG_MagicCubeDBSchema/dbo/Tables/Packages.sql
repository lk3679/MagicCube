CREATE TABLE [dbo].[Packages](
	[PackagesNo] [uniqueidentifier] NOT NULL,
	[PackagesName] [nvarchar](50) NOT NULL,
	[EndDate] [datetime] NULL,
	[PackingDate] [datetime] NULL,
	[SearchJson] [nvarchar](500) NOT NULL,
	[PackagesMemo] [nvarchar](500) NOT NULL,
	[CreateUser] [nvarchar](50) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ModifyUser] [nvarchar](50) NOT NULL,
	[ModifyDate] [datetime] NULL,
 CONSTRAINT [PK_PackageList] PRIMARY KEY CLUSTERED 
(
	[PackagesNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Packages] ADD  CONSTRAINT [DF_PackageList_PG_No]  DEFAULT (newid()) FOR [PackagesNo]
GO
ALTER TABLE [dbo].[Packages] ADD  CONSTRAINT [DF_PackageList_PG_Name]  DEFAULT ('') FOR [PackagesName]
GO
ALTER TABLE [dbo].[Packages] ADD  CONSTRAINT [DF_PackageList_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Packages] ADD  CONSTRAINT [DF_PackageList_CreateUser]  DEFAULT ('') FOR [CreateUser]
GO
ALTER TABLE [dbo].[Packages] ADD  CONSTRAINT [DF_PackageList_ModifyUser]  DEFAULT ('') FOR [ModifyUser]
GO
ALTER TABLE [dbo].[Packages] ADD  CONSTRAINT [DF_Package_List_SearchJson]  DEFAULT ('') FOR [SearchJson]
GO
ALTER TABLE [dbo].[Packages] ADD  CONSTRAINT [DF_Packages_Memo]  DEFAULT ('') FOR [PackagesMemo]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'包裝序號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Packages', @level2type=N'COLUMN',@level2name=N'PackagesNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'包裝名稱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Packages', @level2type=N'COLUMN',@level2name=N'PackagesName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'到期時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Packages', @level2type=N'COLUMN',@level2name=N'EndDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'打包時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Packages', @level2type=N'COLUMN',@level2name=N'PackingDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'建立時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Packages', @level2type=N'COLUMN',@level2name=N'CreateDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'建立者' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Packages', @level2type=N'COLUMN',@level2name=N'CreateUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改者' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Packages', @level2type=N'COLUMN',@level2name=N'ModifyUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Packages', @level2type=N'COLUMN',@level2name=N'ModifyDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'搜尋條件Json' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Packages', @level2type=N'COLUMN',@level2name=N'SearchJson'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'備註' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Packages', @level2type=N'COLUMN',@level2name=N'PackagesMemo'