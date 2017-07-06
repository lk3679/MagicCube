CREATE TABLE [dbo].[WorksPropOwner](
	[WorksPropOwnerNo] [int] IDENTITY(1,1) NOT NULL,
	[WorksNo] [uniqueidentifier] NOT NULL,
	[OwnerNo] [int] NOT NULL,
 CONSTRAINT [PK_Works_Prop_Owner] PRIMARY KEY CLUSTERED 
(
	[WorksPropOwnerNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[WorksPropOwner]  WITH CHECK ADD  CONSTRAINT [FK_Works_Prop_Owner_Menu_Owner] FOREIGN KEY([OwnerNo])
REFERENCES [dbo].[Menu_Owner] ([OwnerNo])
GO

ALTER TABLE [dbo].[WorksPropOwner] CHECK CONSTRAINT [FK_Works_Prop_Owner_Menu_Owner]
GO
ALTER TABLE [dbo].[WorksPropOwner]  WITH CHECK ADD  CONSTRAINT [FK_Works_Prop_Owner_Works_List] FOREIGN KEY([WorksNo])
REFERENCES [dbo].[Works] ([WorksNo])
GO

ALTER TABLE [dbo].[WorksPropOwner] CHECK CONSTRAINT [FK_Works_Prop_Owner_Works_List]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作品附加屬性_所有人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorksPropOwner', @level2type=N'COLUMN',@level2name=N'WorksPropOwnerNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作品序號,對應dbo.Works_List.Works_No' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorksPropOwner', @level2type=N'COLUMN',@level2name=N'WorksNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'附加屬性_所有人,對應dbo.Menu_Owner.Owner_No' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorksPropOwner', @level2type=N'COLUMN',@level2name=N'OwnerNo'