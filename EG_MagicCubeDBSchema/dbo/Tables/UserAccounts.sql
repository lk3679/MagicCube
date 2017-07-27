CREATE TABLE [dbo].[UserAccounts](
	[UserAccountsNo] [int] IDENTITY(1,1) NOT NULL,
	[UserAccount] [nvarchar](50) NOT NULL DEFAULT (''),
	[Password] [nvarchar](500) NOT NULL,
	[Pwdself] [nvarchar](500) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[RoleNo] [int] NOT NULL,
	[AccountStatus] [nvarchar](50) NOT NULL,
	[AccountNote] [nvarchar](500) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateUser] [nvarchar](50) NOT NULL,
	[ModifyUser] [nvarchar](50) NOT NULL,
	[ModifyDate] [datetime] NULL,
	[IsDel] VARCHAR(5) NOT NULL DEFAULT (''), 
 CONSTRAINT [PK_User_AccountList] PRIMARY KEY CLUSTERED 
(
	[UserAccountsNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[UserAccounts]  WITH CHECK ADD  CONSTRAINT [FK_UserAccounts_UserAccountRoles] FOREIGN KEY([RoleNo])
REFERENCES [dbo].[UserAccountRoles] ([RoleNo])
GO

ALTER TABLE [dbo].[UserAccounts] CHECK CONSTRAINT [FK_UserAccounts_UserAccountRoles]
GO
ALTER TABLE [dbo].[UserAccounts] ADD  CONSTRAINT [DF_User_AccountList_Password]  DEFAULT ('') FOR [Password]
GO
ALTER TABLE [dbo].[UserAccounts] ADD  CONSTRAINT [DF_User_AccountList_Pwdself]  DEFAULT ('') FOR [Pwdself]
GO
ALTER TABLE [dbo].[UserAccounts] ADD  CONSTRAINT [DF_User_AccountList_Name]  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[UserAccounts] ADD  CONSTRAINT [DF_User_AccountList_Account_Status]  DEFAULT ('') FOR [AccountStatus]
GO
ALTER TABLE [dbo].[UserAccounts] ADD  CONSTRAINT [DF_User_AccountList_Account_Note]  DEFAULT ('') FOR [AccountNote]
GO
ALTER TABLE [dbo].[UserAccounts] ADD  CONSTRAINT [DF_UserAccounts_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[UserAccounts] ADD  CONSTRAINT [DF_UserAccounts_CreateUser]  DEFAULT ('') FOR [CreateUser]
GO
ALTER TABLE [dbo].[UserAccounts] ADD  CONSTRAINT [DF_UserAccounts_ModifyUser]  DEFAULT ('') FOR [ModifyUser]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'使用者帳號序號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserAccounts', @level2type=N'COLUMN',@level2name=N'UserAccountsNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密碼' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserAccounts', @level2type=N'COLUMN',@level2name=N'Password'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密碼self' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserAccounts', @level2type=N'COLUMN',@level2name=N'Pwdself'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'使用者名稱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserAccounts', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'帳號角色' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserAccounts', @level2type=N'COLUMN',@level2name=N'RoleNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'帳號狀態' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserAccounts', @level2type=N'COLUMN',@level2name=N'AccountStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'帳號備註' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserAccounts', @level2type=N'COLUMN',@level2name=N'AccountNote'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'使用者帳號',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'UserAccounts',
    @level2type = N'COLUMN',
    @level2name = N'UserAccount'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'是否刪除，Y:刪除',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'UserAccounts',
    @level2type = N'COLUMN',
    @level2name = N'IsDel'