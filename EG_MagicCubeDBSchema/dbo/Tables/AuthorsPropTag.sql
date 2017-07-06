CREATE TABLE [dbo].[AuthorsPropTag](
	[AuthorsPropTagNo] [int] IDENTITY(1,1) NOT NULL,
	[AuthorsNo] [int] NOT NULL,
	[AuthorsTagNo] [int] NOT NULL,
 CONSTRAINT [PK_Author_Prop_Tag] PRIMARY KEY CLUSTERED 
(
	[AuthorsPropTagNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AuthorsPropTag]  WITH CHECK ADD  CONSTRAINT [FK_Author_Prop_Tag_Author_List] FOREIGN KEY([AuthorsNo])
REFERENCES [dbo].[Authors] ([AuthorsNo])
GO

ALTER TABLE [dbo].[AuthorsPropTag] CHECK CONSTRAINT [FK_Author_Prop_Tag_Author_List]
GO
ALTER TABLE [dbo].[AuthorsPropTag]  WITH CHECK ADD  CONSTRAINT [FK_Author_Prop_Tag_Menu_AuthorTag] FOREIGN KEY([AuthorsTagNo])
REFERENCES [dbo].[Menu_AuthorsTag] ([AuthorsTagNo])
GO

ALTER TABLE [dbo].[AuthorsPropTag] CHECK CONSTRAINT [FK_Author_Prop_Tag_Menu_AuthorTag]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'藝術家附加屬性_標籤序號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuthorsPropTag', @level2type=N'COLUMN',@level2name=N'AuthorsPropTagNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'藝術家序號,對應dbo.Author_List.Author_No' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuthorsPropTag', @level2type=N'COLUMN',@level2name=N'AuthorsNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'附加屬性_標籤,對應dbo.Menu_AuthorTag.AuthorTag_No' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuthorsPropTag', @level2type=N'COLUMN',@level2name=N'AuthorsTagNo'