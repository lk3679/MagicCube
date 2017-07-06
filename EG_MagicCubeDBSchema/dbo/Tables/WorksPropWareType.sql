CREATE TABLE [dbo].[WorksPropWareType](
	[WorksPropWareTypeNo] [int] IDENTITY(1,1) NOT NULL,
	[WorksNo] [uniqueidentifier] NOT NULL,
	[WareTypeNo] [int] NOT NULL,
 CONSTRAINT [PK_Works_Prop_WareType] PRIMARY KEY CLUSTERED 
(
	[WorksPropWareTypeNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[WorksPropWareType]  WITH CHECK ADD  CONSTRAINT [FK_Works_Prop_WareType_Menu_WareType] FOREIGN KEY([WareTypeNo])
REFERENCES [dbo].[Menu_WareType] ([WareTypeNo])
GO

ALTER TABLE [dbo].[WorksPropWareType] CHECK CONSTRAINT [FK_Works_Prop_WareType_Menu_WareType]
GO
ALTER TABLE [dbo].[WorksPropWareType]  WITH CHECK ADD  CONSTRAINT [FK_Works_Prop_WareType_Works_List] FOREIGN KEY([WorksNo])
REFERENCES [dbo].[Works] ([WorksNo])
GO

ALTER TABLE [dbo].[WorksPropWareType] CHECK CONSTRAINT [FK_Works_Prop_WareType_Works_List]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作品附加屬性_庫別' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorksPropWareType', @level2type=N'COLUMN',@level2name=N'WorksPropWareTypeNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作品序號,對應dbo.Works_List.Works_No' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorksPropWareType', @level2type=N'COLUMN',@level2name=N'WorksNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'附加屬性_庫別,對應dbo.Menu_WareType.WareType_No' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorksPropWareType', @level2type=N'COLUMN',@level2name=N'WareTypeNo'