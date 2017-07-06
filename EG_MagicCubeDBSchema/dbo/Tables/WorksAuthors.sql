CREATE TABLE [dbo].[WorksAuthors](
	[Works_Author_No] [int] IDENTITY(1,1) NOT NULL,
	[Works_No] [uniqueidentifier] NOT NULL,
	[Author_No] [int] NOT NULL,
 CONSTRAINT [PK_Works_Author] PRIMARY KEY CLUSTERED 
(
	[Works_Author_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[WorksAuthors]  WITH CHECK ADD  CONSTRAINT [FK_Works_Author_Author_List] FOREIGN KEY([Author_No])
REFERENCES [dbo].[Authors] ([AuthorsNo])
GO

ALTER TABLE [dbo].[WorksAuthors] CHECK CONSTRAINT [FK_Works_Author_Author_List]
GO
ALTER TABLE [dbo].[WorksAuthors]  WITH CHECK ADD  CONSTRAINT [FK_Works_Author_Works_List] FOREIGN KEY([Works_No])
REFERENCES [dbo].[Works] ([WorksNo])
GO

ALTER TABLE [dbo].[WorksAuthors] CHECK CONSTRAINT [FK_Works_Author_Works_List]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作品藝術家序號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorksAuthors', @level2type=N'COLUMN',@level2name=N'Works_Author_No'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作品序號,對應dbo.Works_List.Works_No' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorksAuthors', @level2type=N'COLUMN',@level2name=N'Works_No'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'藝術家序號,對應dbo.Author_List.Author_No' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorksAuthors', @level2type=N'COLUMN',@level2name=N'Author_No'