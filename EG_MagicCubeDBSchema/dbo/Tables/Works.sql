CREATE TABLE [dbo].[Works](
	[WorksNo] [uniqueidentifier] NOT NULL,
	[MaterialsID] [nvarchar](20) NOT NULL,
	[AuthorsNo] [int] NOT NULL,
	[WorksName] [nvarchar](200) NOT NULL,
	[YearStart] [smallint] NOT NULL,
	[YearEnd] [smallint] NOT NULL,
	[Remarks] [nvarchar](500) NOT NULL,
	[Cost] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[PricingDate] [datetime] NOT NULL,
	[GrossMargin] [float] NOT NULL,
	[Marketability] [float] NOT NULL,
	[Packageability] [float] NOT NULL,
	[Valuability] [float] NOT NULL,
	[Artisticability] [float] NOT NULL,
	[CreateUser] [nvarchar](50) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ModifyUser] [nvarchar](50) NOT NULL,
	[ModifyDate] [datetime] NULL,
	[Rating] VARCHAR(5) NOT NULL DEFAULT (''), 
	[IsDel] VARCHAR(5) NOT NULL DEFAULT (''), 

    CONSTRAINT [PK_Works_List] PRIMARY KEY CLUSTERED 
(
	[WorksNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Works] ADD  DEFAULT (newid()) FOR [WorksNo]
GO
ALTER TABLE [dbo].[Works] ADD  DEFAULT ('') FOR [MaterialsID]
GO
ALTER TABLE [dbo].[Works] ADD  DEFAULT ('') FOR [WorksName]
GO
ALTER TABLE [dbo].[Works] ADD  DEFAULT ((0)) FOR [YearStart]
GO
ALTER TABLE [dbo].[Works] ADD  DEFAULT ((0)) FOR [YearEnd]
GO
ALTER TABLE [dbo].[Works] ADD  DEFAULT ('') FOR [Remarks]
GO
ALTER TABLE [dbo].[Works] ADD  DEFAULT ((0)) FOR [Cost]
GO
ALTER TABLE [dbo].[Works] ADD  DEFAULT ((0)) FOR [Price]
GO
ALTER TABLE [dbo].[Works] ADD  DEFAULT ((0.0)) FOR [GrossMargin]
GO
ALTER TABLE [dbo].[Works] ADD  DEFAULT ((0.0)) FOR [Marketability]
GO
ALTER TABLE [dbo].[Works] ADD  DEFAULT ((0.0)) FOR [Packageability]
GO
ALTER TABLE [dbo].[Works] ADD  DEFAULT ((0.0)) FOR [Valuability]
GO
ALTER TABLE [dbo].[Works] ADD  DEFAULT ((0.0)) FOR [Artisticability]
GO
ALTER TABLE [dbo].[Works] ADD  DEFAULT ('') FOR [CreateUser]
GO
ALTER TABLE [dbo].[Works] ADD  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Works] ADD  DEFAULT ('') FOR [ModifyUser]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作品序號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works', @level2type=N'COLUMN',@level2name=N'WorksNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物料代碼,來至於SAP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works', @level2type=N'COLUMN',@level2name=N'MaterialsID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'藝術家,對應dbo.Author_List.Author_No' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works', @level2type=N'COLUMN',@level2name=N'AuthorsNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作品名稱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works', @level2type=N'COLUMN',@level2name=N'WorksName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作品起始年分' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works', @level2type=N'COLUMN',@level2name=N'YearStart'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作品結束年分' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works', @level2type=N'COLUMN',@level2name=N'YearEnd'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'備註' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works', @level2type=N'COLUMN',@level2name=N'Remarks'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'成本價' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works', @level2type=N'COLUMN',@level2name=N'Cost'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'定價' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works', @level2type=N'COLUMN',@level2name=N'Price'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'定價時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works', @level2type=N'COLUMN',@level2name=N'PricingDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'毛利率' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works', @level2type=N'COLUMN',@level2name=N'GrossMargin'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'市場性' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works', @level2type=N'COLUMN',@level2name=N'Marketability'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'包裹性' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works', @level2type=N'COLUMN',@level2name=N'Packageability'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'增值性' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works', @level2type=N'COLUMN',@level2name=N'Valuability'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'藝術性' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works', @level2type=N'COLUMN',@level2name=N'Artisticability'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'建立者' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works', @level2type=N'COLUMN',@level2name=N'CreateUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'建立時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works', @level2type=N'COLUMN',@level2name=N'CreateDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改者' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works', @level2type=N'COLUMN',@level2name=N'ModifyUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works', @level2type=N'COLUMN',@level2name=N'ModifyDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'是否刪除，Y:刪除',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Works',
    @level2type = N'COLUMN',
    @level2name = N'IsDel'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'等級',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Works',
    @level2type = N'COLUMN',
    @level2name = N'Rating'