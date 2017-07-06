CREATE TABLE [dbo].[WorksModules](
	[WorksModulesNo] [int] IDENTITY(1,1) NOT NULL,
	[WorksNo] [uniqueidentifier] NOT NULL,
	[Material] [int] NOT NULL,
	[Measure] [nvarchar](50) NOT NULL,
	[Length] [float] NOT NULL,
	[Width] [float] NOT NULL,
	[High] [float] NOT NULL,
	[Deep] [float] NOT NULL,
	[TimeLength] [nvarchar](50) NOT NULL,
	[Amount] [int] NOT NULL,
	[CountNoun] [int] NOT NULL,
 CONSTRAINT [PK_Works_Module_List] PRIMARY KEY CLUSTERED 
(
	[WorksModulesNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[WorksModules]  WITH CHECK ADD  CONSTRAINT [FK_Works_Module_List_Menu_CountNoun] FOREIGN KEY([CountNoun])
REFERENCES [dbo].[Menu_CountNoun] ([CountNounNo])
GO

ALTER TABLE [dbo].[WorksModules] CHECK CONSTRAINT [FK_Works_Module_List_Menu_CountNoun]
GO
ALTER TABLE [dbo].[WorksModules]  WITH CHECK ADD  CONSTRAINT [FK_Works_Module_List_Menu_Material] FOREIGN KEY([Material])
REFERENCES [dbo].[Menu_Material] ([MaterialNo])
GO

ALTER TABLE [dbo].[WorksModules] CHECK CONSTRAINT [FK_Works_Module_List_Menu_Material]
GO
ALTER TABLE [dbo].[WorksModules]  WITH CHECK ADD  CONSTRAINT [FK_Works_Module_List_Works_List] FOREIGN KEY([WorksNo])
REFERENCES [dbo].[Works] ([WorksNo])
GO

ALTER TABLE [dbo].[WorksModules] CHECK CONSTRAINT [FK_Works_Module_List_Works_List]
GO
ALTER TABLE [dbo].[WorksModules] ADD  CONSTRAINT [DF_Works_Module_List_NoMeasure]  DEFAULT ('') FOR [Measure]
GO
ALTER TABLE [dbo].[WorksModules] ADD  CONSTRAINT [DF_Works_Module_List_Length]  DEFAULT ((0.0)) FOR [Length]
GO
ALTER TABLE [dbo].[WorksModules] ADD  CONSTRAINT [DF_Works_Module_List_Width]  DEFAULT ((0.0)) FOR [Width]
GO
ALTER TABLE [dbo].[WorksModules] ADD  CONSTRAINT [DF_Works_Module_List_High]  DEFAULT ((0.0)) FOR [High]
GO
ALTER TABLE [dbo].[WorksModules] ADD  CONSTRAINT [DF_Works_Module_List_Deep]  DEFAULT ((0.0)) FOR [Deep]
GO
ALTER TABLE [dbo].[WorksModules] ADD  CONSTRAINT [DF_Works_Module_List_TimeLength]  DEFAULT ('') FOR [TimeLength]
GO
ALTER TABLE [dbo].[WorksModules] ADD  CONSTRAINT [DF_Table_1_amount]  DEFAULT ((0)) FOR [Amount]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'組件序號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorksModules', @level2type=N'COLUMN',@level2name=N'WorksModulesNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作品' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorksModules', @level2type=N'COLUMN',@level2name=N'WorksNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'媒材' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorksModules', @level2type=N'COLUMN',@level2name=N'Material'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否測量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorksModules', @level2type=N'COLUMN',@level2name=N'Measure'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'長' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorksModules', @level2type=N'COLUMN',@level2name=N'Length'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'寬' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorksModules', @level2type=N'COLUMN',@level2name=N'Width'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'高' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorksModules', @level2type=N'COLUMN',@level2name=N'High'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'深' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorksModules', @level2type=N'COLUMN',@level2name=N'Deep'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'時間長度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorksModules', @level2type=N'COLUMN',@level2name=N'TimeLength'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'數量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorksModules', @level2type=N'COLUMN',@level2name=N'Amount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'量詞' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorksModules', @level2type=N'COLUMN',@level2name=N'CountNoun'