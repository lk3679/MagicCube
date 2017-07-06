CREATE TABLE [dbo].[PackageItems](
	[PackageItemsNo] [bigint] IDENTITY(1,1) NOT NULL,
	[PackagesNo] [uniqueidentifier] NOT NULL,
	[WorksNo] [uniqueidentifier] NOT NULL,
	[JoinDate] [datetime] NOT NULL,
	[DelDate] [datetime] NULL,
	[IsJoin] [varchar](1) NOT NULL,
 CONSTRAINT [PK_PackageItemList] PRIMARY KEY CLUSTERED 
(
	[PackageItemsNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[PackageItems]  WITH CHECK ADD  CONSTRAINT [FK_PackageItemList_Package_List] FOREIGN KEY([PackagesNo])
REFERENCES [dbo].[Packages] ([PackagesNo])
GO

ALTER TABLE [dbo].[PackageItems] CHECK CONSTRAINT [FK_PackageItemList_Package_List]
GO
ALTER TABLE [dbo].[PackageItems]  WITH CHECK ADD  CONSTRAINT [FK_PackageItemList_Works_List] FOREIGN KEY([WorksNo])
REFERENCES [dbo].[Works] ([WorksNo])
GO

ALTER TABLE [dbo].[PackageItems] CHECK CONSTRAINT [FK_PackageItemList_Works_List]
GO
ALTER TABLE [dbo].[PackageItems] ADD  CONSTRAINT [DF_PackageItemList_JoinDate]  DEFAULT (getdate()) FOR [JoinDate]
GO
ALTER TABLE [dbo].[PackageItems] ADD  CONSTRAINT [DF_PackageItemList_IsJoin]  DEFAULT ('') FOR [IsJoin]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'包裝項目序號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PackageItems', @level2type=N'COLUMN',@level2name=N'PackageItemsNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'包裝序號,對應dbo.Package_List.PG_No' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PackageItems', @level2type=N'COLUMN',@level2name=N'PackagesNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作品序號,對應dbo.Works_List.Works_No' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PackageItems', @level2type=N'COLUMN',@level2name=N'WorksNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'加入日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PackageItems', @level2type=N'COLUMN',@level2name=N'JoinDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'刪除日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PackageItems', @level2type=N'COLUMN',@level2name=N'DelDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否加入包裝' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PackageItems', @level2type=N'COLUMN',@level2name=N'IsJoin'