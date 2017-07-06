CREATE TABLE [dbo].[WorksPropGenre](
	[WorksPropGenreNo] [int] IDENTITY(1,1) NOT NULL,
	[WorksNo] [uniqueidentifier] NOT NULL,
	[GenreNo] [int] NOT NULL,
 CONSTRAINT [PK_Works_Prop_Genre] PRIMARY KEY CLUSTERED 
(
	[WorksPropGenreNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[WorksPropGenre]  WITH CHECK ADD  CONSTRAINT [FK_Works_Prop_Genre_Menu_Genre] FOREIGN KEY([GenreNo])
REFERENCES [dbo].[Menu_Genre] ([GenreNo])
GO

ALTER TABLE [dbo].[WorksPropGenre] CHECK CONSTRAINT [FK_Works_Prop_Genre_Menu_Genre]
GO
ALTER TABLE [dbo].[WorksPropGenre]  WITH CHECK ADD  CONSTRAINT [FK_Works_Prop_Genre_Works_List] FOREIGN KEY([WorksNo])
REFERENCES [dbo].[Works] ([WorksNo])
GO

ALTER TABLE [dbo].[WorksPropGenre] CHECK CONSTRAINT [FK_Works_Prop_Genre_Works_List]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作品附加屬性_類型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorksPropGenre', @level2type=N'COLUMN',@level2name=N'WorksPropGenreNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作品序號,對應dbo.Works_List.Works_No' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorksPropGenre', @level2type=N'COLUMN',@level2name=N'WorksNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'附加屬性類別,對應dbo.Menu_Genre.Genre_No' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorksPropGenre', @level2type=N'COLUMN',@level2name=N'GenreNo'