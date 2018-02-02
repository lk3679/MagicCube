CREATE TABLE [dbo].[ET_VENDOR]
(
	[VENDOR_No] INT IDENTITY(1,1) NOT NULL,
    [NAME1] NVARCHAR(50) NOT NULL DEFAULT (''), 
    [LIFNR] VARCHAR(10) NOT NULL DEFAULT (''), 
    [SORTL] NVARCHAR(50) NOT NULL DEFAULT (''), 
    [LAND1] VARCHAR(10) NOT NULL DEFAULT (''), 
    [ERDAT] VARCHAR(10) NOT NULL DEFAULT (''), 
    [UDATE] VARCHAR(10) NOT NULL DEFAULT (''), 
    [CreateTime] DATETIME NOT NULL DEFAULT (GETDATE()), 
    [IsNew] VARCHAR(5) NOT NULL DEFAULT (''), 
    [IsSync] VARCHAR(5) NOT NULL DEFAULT ('N'), 
    [SyncTime] DATETIME NULL, 
    [SyncUser] NVARCHAR(50) NOT NULL DEFAULT (''), 
    CONSTRAINT [PK_ET_VENDOR] PRIMARY KEY ([VENDOR_No]) 
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'流水號',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ET_VENDOR',
    @level2type = N'COLUMN',
    @level2name = N'VENDOR_No'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'SAP建立日期',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ET_VENDOR',
    @level2type = N'COLUMN',
    @level2name = N'ERDAT'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'SAP異動時間',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ET_VENDOR',
    @level2type = N'COLUMN',
    @level2name = N'UDATE'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'SAP供應商(藝術家)編號',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ET_VENDOR',
    @level2type = N'COLUMN',
    @level2name = N'LIFNR'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'SAP供應商(藝術家)名稱',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ET_VENDOR',
    @level2type = N'COLUMN',
    @level2name = N'NAME1'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'SAP供應商(藝術家)名稱別名',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ET_VENDOR',
    @level2type = N'COLUMN',
    @level2name = N'SORTL'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'區域國別',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ET_VENDOR',
    @level2type = N'COLUMN',
    @level2name = N'LAND1'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'產生時間',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ET_VENDOR',
    @level2type = N'COLUMN',
    @level2name = N'CreateTime'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'是否為新資料',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ET_VENDOR',
    @level2type = N'COLUMN',
    @level2name = N'IsNew'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'是否已更新',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ET_VENDOR',
    @level2type = N'COLUMN',
    @level2name = N'IsSync'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'更新時間',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ET_VENDOR',
    @level2type = N'COLUMN',
    @level2name = N'SyncTime'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'更新者',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ET_VENDOR',
    @level2type = N'COLUMN',
    @level2name = N'SyncUser'