CREATE TABLE [dbo].[WorksFiles](
	[WorksFilesNo] [bigint] IDENTITY(1,1) NOT NULL,
	[WorksNo] [uniqueidentifier] NOT NULL,
	[FileBase64Str] [varchar](max) NOT NULL DEFAULT (''),
 [File_o_Url] VARCHAR(500) NOT NULL DEFAULT (''), 
    [File_m_Url] VARCHAR(500) NOT NULL DEFAULT (''), 
    [File_s_Url] VARCHAR(500) NOT NULL DEFAULT (''), 
    CONSTRAINT [PK_Works_Files] PRIMARY KEY CLUSTERED 
(
	[WorksFilesNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[WorksFiles]  WITH CHECK ADD  CONSTRAINT [FK_Works_Files_Works_List] FOREIGN KEY([WorksNo])
REFERENCES [dbo].[Works] ([WorksNo])
GO

ALTER TABLE [dbo].[WorksFiles] CHECK CONSTRAINT [FK_Works_Files_Works_List]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'檔案序號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorksFiles', @level2type=N'COLUMN',@level2name=N'WorksFilesNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作品序號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorksFiles', @level2type=N'COLUMN',@level2name=N'WorksNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'小尺寸base64檔案編碼字串' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorksFiles', @level2type=N'COLUMN',@level2name=N'FileBase64Str'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'原始尺寸檔案url',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'WorksFiles',
    @level2type = N'COLUMN',
    @level2name = 'File_o_Url'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'小尺寸檔案url',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'WorksFiles',
    @level2type = N'COLUMN',
    @level2name = N'File_s_Url'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'中尺寸檔案url',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'WorksFiles',
    @level2type = N'COLUMN',
    @level2name = N'File_m_Url'