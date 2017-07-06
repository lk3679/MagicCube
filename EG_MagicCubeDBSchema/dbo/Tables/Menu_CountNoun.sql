CREATE TABLE [dbo].[Menu_CountNoun](
	[CountNounNo] [int] IDENTITY(1,1) NOT NULL,
	[CountNounName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Menu_CountNoun] PRIMARY KEY CLUSTERED 
(
	[CountNounNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Menu_CountNoun] ADD  CONSTRAINT [DF_Menu_CountNoun_CountNoun_Name]  DEFAULT ('') FOR [CountNounName]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'量詞編號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu_CountNoun', @level2type=N'COLUMN',@level2name=N'CountNounNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'量詞名稱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu_CountNoun', @level2type=N'COLUMN',@level2name=N'CountNounName'