CREATE TABLE [dbo].[AuthorsPropArea](
	[AuthorsPropAreaNo] [int] IDENTITY(1,1) NOT NULL,
	[AuthorsNo] [int] NOT NULL,
	[AuthorsAreaNo] [int] NOT NULL,
 CONSTRAINT [PK_Author_Prop_Area] PRIMARY KEY CLUSTERED 
(
	[AuthorsPropAreaNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AuthorsPropArea]  WITH CHECK ADD  CONSTRAINT [FK_Author_Prop_Area_Author_List] FOREIGN KEY([AuthorsNo])
REFERENCES [dbo].[Authors] ([AuthorsNo])
GO

ALTER TABLE [dbo].[AuthorsPropArea] CHECK CONSTRAINT [FK_Author_Prop_Area_Author_List]
GO
ALTER TABLE [dbo].[AuthorsPropArea]  WITH CHECK ADD  CONSTRAINT [FK_Author_Prop_Area_Menu_AuthorArea] FOREIGN KEY([AuthorsAreaNo])
REFERENCES [dbo].[Menu_AuthorsArea] ([AuthorsAreaNo])
GO

ALTER TABLE [dbo].[AuthorsPropArea] CHECK CONSTRAINT [FK_Author_Prop_Area_Menu_AuthorArea]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'藝術家附加屬性_區域序號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuthorsPropArea', @level2type=N'COLUMN',@level2name=N'AuthorsPropAreaNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'藝術家序號,對應dbo.Author_List.Author_No' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuthorsPropArea', @level2type=N'COLUMN',@level2name=N'AuthorsNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'附加屬性_區域,對應dbo.Menu_AuthorArea.AuthorArea_No' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuthorsPropArea', @level2type=N'COLUMN',@level2name=N'AuthorsAreaNo'