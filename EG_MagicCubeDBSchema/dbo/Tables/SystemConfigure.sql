CREATE TABLE [dbo].[SystemConfigure]
(
	[ConfigureNo] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ConfigureName] NVARCHAR(50) NULL, 
    [ConfigureValue] NVARCHAR(MAX) NULL
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'參數名稱',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SystemConfigure',
    @level2type = N'COLUMN',
    @level2name = N'ConfigureName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'參數值',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SystemConfigure',
    @level2type = N'COLUMN',
    @level2name = N'ConfigureValue'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'參數序號',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SystemConfigure',
    @level2type = N'COLUMN',
    @level2name = N'ConfigureNo'