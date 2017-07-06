CREATE TABLE [dbo].[WorksPropStyle](
	[WorksPropStyleNo] [int] IDENTITY(1,1) NOT NULL,
	[WorksNo] [uniqueidentifier] NOT NULL,
	[StyleNo] [int] NOT NULL,
 CONSTRAINT [PK_Works_Prop_Style] PRIMARY KEY CLUSTERED 
(
	[WorksPropStyleNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[WorksPropStyle]  WITH CHECK ADD  CONSTRAINT [FK_Works_Prop_Style_Menu_Style] FOREIGN KEY([StyleNo])
REFERENCES [dbo].[Menu_Style] ([StyleNo])
GO

ALTER TABLE [dbo].[WorksPropStyle] CHECK CONSTRAINT [FK_Works_Prop_Style_Menu_Style]
GO
ALTER TABLE [dbo].[WorksPropStyle]  WITH CHECK ADD  CONSTRAINT [FK_Works_Prop_Style_Works_List] FOREIGN KEY([WorksNo])
REFERENCES [dbo].[Works] ([WorksNo])
GO

ALTER TABLE [dbo].[WorksPropStyle] CHECK CONSTRAINT [FK_Works_Prop_Style_Works_List]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作品附加屬性_風格' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorksPropStyle', @level2type=N'COLUMN',@level2name=N'WorksPropStyleNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作品序號,對應dbo.Works_List.Works_No' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorksPropStyle', @level2type=N'COLUMN',@level2name=N'WorksNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'附加屬性_風格,對應dbo.Menu_Style.Style_No' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorksPropStyle', @level2type=N'COLUMN',@level2name=N'StyleNo'