CREATE TABLE [dbo].[ET_MASTER]
(
	[MASTER_No] INT IDENTITY(1,1) NOT NULL,
    [MATNR] VARCHAR(20) NOT NULL DEFAULT (''), 
    [ZZCT] NVARCHAR(200) NOT NULL DEFAULT (''), 
    [NAME1] NVARCHAR(50) NOT NULL DEFAULT (''), 
    [ZFPRESERVE_D] VARCHAR(10) NOT NULL DEFAULT (''), 
    [ZZSE] NVARCHAR(50) NOT NULL DEFAULT (''), 
    [LOCATION] NVARCHAR(20) NOT NULL DEFAULT (''), 
    [STATUS] NVARCHAR(20) NOT NULL DEFAULT (''), 
    [STPRS] VARCHAR(20) NOT NULL DEFAULT (''), 
    [NETPR] VARCHAR(20) NOT NULL DEFAULT (''), 
    [WAERS] VARCHAR(10) NOT NULL DEFAULT (''), 
    [ERDAT] VARCHAR(10) NOT NULL DEFAULT (''), 
    [UDATE] VARCHAR(10) NOT NULL DEFAULT (''), 
    [CreateTime] DATETIME NOT NULL DEFAULT (GETDATE()), 
    [IsNew] VARCHAR(5) NOT NULL DEFAULT (''), 
    [IsSync] VARCHAR(5) NOT NULL DEFAULT ('N'), 
    [SyncTime] DATETIME NULL, 
    [SyncUser] NVARCHAR(50) NOT NULL DEFAULT (''), 
    CONSTRAINT [PK_ET_MASTER] PRIMARY KEY ([MASTER_No])
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'SAP商品代碼',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ET_MASTER',
    @level2type = N'COLUMN',
    @level2name = N'MATNR'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'SAP商品名(作品名)',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ET_MASTER',
    @level2type = N'COLUMN',
    @level2name = N'ZZCT'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'SAP供應商(藝術家)名稱',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ET_MASTER',
    @level2type = N'COLUMN',
    @level2name = N'NAME1'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'年代',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ET_MASTER',
    @level2type = N'COLUMN',
    @level2name = N'ZFPRESERVE_D'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'尺寸',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ET_MASTER',
    @level2type = N'COLUMN',
    @level2name = N'ZZSE'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'庫別',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ET_MASTER',
    @level2type = N'COLUMN',
    @level2name = N'LOCATION'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'所有人',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ET_MASTER',
    @level2type = N'COLUMN',
    @level2name = N'STATUS'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'成本',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ET_MASTER',
    @level2type = N'COLUMN',
    @level2name = N'STPRS'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'定價',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ET_MASTER',
    @level2type = N'COLUMN',
    @level2name = N'NETPR'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'幣別',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ET_MASTER',
    @level2type = N'COLUMN',
    @level2name = N'WAERS'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'SAP建立日期',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ET_MASTER',
    @level2type = N'COLUMN',
    @level2name = N'ERDAT'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'SAP異動時間',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ET_MASTER',
    @level2type = N'COLUMN',
    @level2name = N'UDATE'
GO

GO

GO

EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'產生時間',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ET_MASTER',
    @level2type = N'COLUMN',
    @level2name = 'CreateTime'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'是否為新資料',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ET_MASTER',
    @level2type = N'COLUMN',
    @level2name = N'IsNew'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'是否已更新',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ET_MASTER',
    @level2type = N'COLUMN',
    @level2name = N'IsSync'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'更新時間',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ET_MASTER',
    @level2type = N'COLUMN',
    @level2name = N'SyncTime'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'更新者',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ET_MASTER',
    @level2type = N'COLUMN',
    @level2name = N'SyncUser'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'流水號',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ET_MASTER',
    @level2type = N'COLUMN',
    @level2name = N'MASTER_No'