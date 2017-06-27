/****** Object:  Table [dbo].[Author_List]    Script Date: 2017/6/27 上午 11:16:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Author_List](
	[Author_No] [int] IDENTITY(1,1) NOT NULL,
	[Materials_ID] [nvarchar](20) NOT NULL,
	[AuthorCName] [nvarchar](50) NOT NULL,
	[AuthorEName] [nvarchar](50) NOT NULL,
	[CreateUser] [nvarchar](50) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ModifyUser] [nvarchar](50) NOT NULL,
	[ModifyDate] [datetime] NULL,
 CONSTRAINT [PK_AuthorList] PRIMARY KEY CLUSTERED 
(
	[Author_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Author_Prop_Area]    Script Date: 2017/6/27 上午 11:16:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Author_Prop_Area](
	[AuthorPropArea_No] [int] IDENTITY(1,1) NOT NULL,
	[Author_No] [int] NOT NULL,
	[AuthorArea_No] [int] NOT NULL,
 CONSTRAINT [PK_Author_Prop_Area] PRIMARY KEY CLUSTERED 
(
	[AuthorPropArea_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Author_Prop_Tag]    Script Date: 2017/6/27 上午 11:16:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Author_Prop_Tag](
	[Author_Prop_Tag_No] [int] IDENTITY(1,1) NOT NULL,
	[Author_No] [int] NOT NULL,
	[AuthorArea_No] [int] NOT NULL,
 CONSTRAINT [PK_Author_Prop_Tag] PRIMARY KEY CLUSTERED 
(
	[Author_Prop_Tag_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu_AuthorArea]    Script Date: 2017/6/27 上午 11:16:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu_AuthorArea](
	[AuthorArea_No] [int] IDENTITY(1,1) NOT NULL,
	[AuthorArea_Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Menu_AuthorArea] PRIMARY KEY CLUSTERED 
(
	[AuthorArea_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu_AuthorTag]    Script Date: 2017/6/27 上午 11:16:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu_AuthorTag](
	[AuthorTag_No] [int] IDENTITY(1,1) NOT NULL,
	[AuthorTag_Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Menu_AuthorTag] PRIMARY KEY CLUSTERED 
(
	[AuthorTag_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu_CountNoun]    Script Date: 2017/6/27 上午 11:16:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu_CountNoun](
	[CountNoun_No] [int] IDENTITY(1,1) NOT NULL,
	[CountNoun_Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Menu_CountNoun] PRIMARY KEY CLUSTERED 
(
	[CountNoun_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu_Genre]    Script Date: 2017/6/27 上午 11:16:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu_Genre](
	[Genre_No] [int] IDENTITY(1,1) NOT NULL,
	[Genre_Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Menu_Genre] PRIMARY KEY CLUSTERED 
(
	[Genre_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu_Material]    Script Date: 2017/6/27 上午 11:16:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu_Material](
	[Material_No] [int] IDENTITY(1,1) NOT NULL,
	[Material_Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Menu_Material] PRIMARY KEY CLUSTERED 
(
	[Material_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu_Owner]    Script Date: 2017/6/27 上午 11:16:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu_Owner](
	[Owner_No] [int] IDENTITY(1,1) NOT NULL,
	[Owner_Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Menu_Owner] PRIMARY KEY CLUSTERED 
(
	[Owner_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu_Style]    Script Date: 2017/6/27 上午 11:16:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu_Style](
	[Style_No] [int] IDENTITY(1,1) NOT NULL,
	[Style_Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Menu_Style] PRIMARY KEY CLUSTERED 
(
	[Style_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu_WareType]    Script Date: 2017/6/27 上午 11:16:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu_WareType](
	[WareType_No] [int] IDENTITY(1,1) NOT NULL,
	[WareType_Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Menu_WareType] PRIMARY KEY CLUSTERED 
(
	[WareType_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Package_List]    Script Date: 2017/6/27 上午 11:16:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Package_List](
	[PG_No] [uniqueidentifier] NOT NULL,
	[PG_Name] [nvarchar](50) NOT NULL,
	[EndDate] [datetime] NULL,
	[PackingDate] [datetime] NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateUser] [nvarchar](50) NOT NULL,
	[ModifyUser] [nvarchar](50) NOT NULL,
	[ModifyDate] [datetime] NULL,
 CONSTRAINT [PK_PackageList] PRIMARY KEY CLUSTERED 
(
	[PG_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PackageItemList]    Script Date: 2017/6/27 上午 11:16:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PackageItemList](
	[PGItem_No] [bigint] IDENTITY(1,1) NOT NULL,
	[PG_No] [uniqueidentifier] NOT NULL,
	[Works_No] [uniqueidentifier] NOT NULL,
	[JoinDate] [datetime] NOT NULL,
	[DelDate] [datetime] NULL,
 CONSTRAINT [PK_PackageItemList] PRIMARY KEY CLUSTERED 
(
	[PGItem_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User_AccountList]    Script Date: 2017/6/27 上午 11:16:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_AccountList](
	[Account_No] [int] IDENTITY(1,1) NOT NULL,
	[Password] [nvarchar](500) NOT NULL,
	[Pwdself] [nvarchar](500) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Account_Role] [nvarchar](50) NOT NULL,
	[Account_Status] [nvarchar](50) NOT NULL,
	[Account_Note] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_User_AccountList] PRIMARY KEY CLUSTERED 
(
	[Account_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Works_Author]    Script Date: 2017/6/27 上午 11:16:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Works_Author](
	[Works_Author_No] [int] IDENTITY(1,1) NOT NULL,
	[Works_No] [uniqueidentifier] NOT NULL,
	[Author_No] [int] NOT NULL,
 CONSTRAINT [PK_Works_Author] PRIMARY KEY CLUSTERED 
(
	[Works_Author_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Works_List]    Script Date: 2017/6/27 上午 11:16:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Works_List](
	[Works_No] [uniqueidentifier] NOT NULL,
	[Materials_ID] [nvarchar](20) NOT NULL,
	[Author_No] [int] NOT NULL,
	[WorksName] [nvarchar](100) NOT NULL,
	[Year_Start] [smallint] NOT NULL,
	[Year_End] [smallint] NOT NULL,
	[Remarks] [nvarchar](500) NOT NULL,
	[Cost] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[PricingDate] [datetime] NOT NULL,
	[GrossMargin] [float] NOT NULL,
	[Marketability] [float] NOT NULL,
	[Packageability] [float] NOT NULL,
	[Valuability] [float] NOT NULL,
	[Artisticability] [float] NOT NULL,
	[CreateUser] [nvarchar](50) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ModifyUser] [nvarchar](50) NOT NULL,
	[ModifyDate] [datetime] NULL,
 CONSTRAINT [PK_Works_List] PRIMARY KEY CLUSTERED 
(
	[Works_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Works_Module_List]    Script Date: 2017/6/27 上午 11:16:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Works_Module_List](
	[Works_Module_No] [int] IDENTITY(1,1) NOT NULL,
	[Works_No] [uniqueidentifier] NOT NULL,
	[Material] [int] NOT NULL,
	[Measure] [nvarchar](50) NOT NULL,
	[Length] [float] NOT NULL,
	[Width] [float] NOT NULL,
	[High] [float] NOT NULL,
	[Deep] [float] NOT NULL,
	[TimeLength] [nvarchar](50) NOT NULL,
	[Amount] [int] NOT NULL,
	[CountNoun] [int] NOT NULL,
 CONSTRAINT [PK_Works_Module_List] PRIMARY KEY CLUSTERED 
(
	[Works_Module_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Works_Prop_Genre]    Script Date: 2017/6/27 上午 11:16:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Works_Prop_Genre](
	[Works_Prop_Genre_No] [int] IDENTITY(1,1) NOT NULL,
	[Works_No] [uniqueidentifier] NOT NULL,
	[Genre_No] [int] NOT NULL,
 CONSTRAINT [PK_Works_Prop_Genre] PRIMARY KEY CLUSTERED 
(
	[Works_Prop_Genre_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Works_Prop_Owner]    Script Date: 2017/6/27 上午 11:16:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Works_Prop_Owner](
	[Works_Prop_Owner_No] [int] IDENTITY(1,1) NOT NULL,
	[Works_No] [uniqueidentifier] NOT NULL,
	[Owner_No] [int] NOT NULL,
 CONSTRAINT [PK_Works_Prop_Owner] PRIMARY KEY CLUSTERED 
(
	[Works_Prop_Owner_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Works_Prop_Style]    Script Date: 2017/6/27 上午 11:16:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Works_Prop_Style](
	[Works_Prop_Style_No] [int] IDENTITY(1,1) NOT NULL,
	[Works_No] [uniqueidentifier] NOT NULL,
	[Style_No] [int] NOT NULL,
 CONSTRAINT [PK_Works_Prop_Style] PRIMARY KEY CLUSTERED 
(
	[Works_Prop_Style_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Works_Prop_WareType]    Script Date: 2017/6/27 上午 11:16:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Works_Prop_WareType](
	[Works_Prop_WareType_No] [int] IDENTITY(1,1) NOT NULL,
	[Works_No] [uniqueidentifier] NOT NULL,
	[WareType_No] [int] NOT NULL,
 CONSTRAINT [PK_Works_Prop_WareType] PRIMARY KEY CLUSTERED 
(
	[Works_Prop_WareType_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Author_List] ADD  DEFAULT ('') FOR [Materials_ID]
GO
ALTER TABLE [dbo].[Author_List] ADD  DEFAULT ('') FOR [AuthorCName]
GO
ALTER TABLE [dbo].[Author_List] ADD  DEFAULT ('') FOR [AuthorEName]
GO
ALTER TABLE [dbo].[Author_List] ADD  DEFAULT ('') FOR [CreateUser]
GO
ALTER TABLE [dbo].[Author_List] ADD  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Author_List] ADD  DEFAULT ('') FOR [ModifyUser]
GO
ALTER TABLE [dbo].[Menu_AuthorArea] ADD  CONSTRAINT [DF_Menu_AuthorArea_AuthorArea_Name]  DEFAULT ('') FOR [AuthorArea_Name]
GO
ALTER TABLE [dbo].[Menu_AuthorTag] ADD  CONSTRAINT [DF_Menu_AuthorTag_AuthorTag_Name]  DEFAULT ('') FOR [AuthorTag_Name]
GO
ALTER TABLE [dbo].[Menu_CountNoun] ADD  CONSTRAINT [DF_Menu_CountNoun_CountNoun_Name]  DEFAULT ('') FOR [CountNoun_Name]
GO
ALTER TABLE [dbo].[Menu_Genre] ADD  CONSTRAINT [DF_Menu_Genre_Genre_Name]  DEFAULT ('') FOR [Genre_Name]
GO
ALTER TABLE [dbo].[Menu_Material] ADD  CONSTRAINT [DF_Menu_Material_Material_Name]  DEFAULT ('') FOR [Material_Name]
GO
ALTER TABLE [dbo].[Menu_Owner] ADD  CONSTRAINT [DF_Menu_Owner_Owner_Name]  DEFAULT ('') FOR [Owner_Name]
GO
ALTER TABLE [dbo].[Menu_Style] ADD  CONSTRAINT [DF_Menu_Style_Style_Name]  DEFAULT ('') FOR [Style_Name]
GO
ALTER TABLE [dbo].[Menu_WareType] ADD  CONSTRAINT [DF_Menu_WareType_WareType_Name]  DEFAULT ('') FOR [WareType_Name]
GO
ALTER TABLE [dbo].[Package_List] ADD  CONSTRAINT [DF_PackageList_PG_No]  DEFAULT (newid()) FOR [PG_No]
GO
ALTER TABLE [dbo].[Package_List] ADD  CONSTRAINT [DF_PackageList_PG_Name]  DEFAULT ('') FOR [PG_Name]
GO
ALTER TABLE [dbo].[Package_List] ADD  CONSTRAINT [DF_PackageList_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Package_List] ADD  CONSTRAINT [DF_PackageList_CreateUser]  DEFAULT ('') FOR [CreateUser]
GO
ALTER TABLE [dbo].[Package_List] ADD  CONSTRAINT [DF_PackageList_ModifyUser]  DEFAULT ('') FOR [ModifyUser]
GO
ALTER TABLE [dbo].[PackageItemList] ADD  CONSTRAINT [DF_PackageItemList_JoinDate]  DEFAULT (getdate()) FOR [JoinDate]
GO
ALTER TABLE [dbo].[User_AccountList] ADD  CONSTRAINT [DF_User_AccountList_Password]  DEFAULT ('') FOR [Password]
GO
ALTER TABLE [dbo].[User_AccountList] ADD  CONSTRAINT [DF_User_AccountList_Pwdself]  DEFAULT ('') FOR [Pwdself]
GO
ALTER TABLE [dbo].[User_AccountList] ADD  CONSTRAINT [DF_User_AccountList_Name]  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[User_AccountList] ADD  CONSTRAINT [DF_User_AccountList_Account_Role]  DEFAULT ('') FOR [Account_Role]
GO
ALTER TABLE [dbo].[User_AccountList] ADD  CONSTRAINT [DF_User_AccountList_Account_Status]  DEFAULT ('') FOR [Account_Status]
GO
ALTER TABLE [dbo].[User_AccountList] ADD  CONSTRAINT [DF_User_AccountList_Account_Note]  DEFAULT ('') FOR [Account_Note]
GO
ALTER TABLE [dbo].[Works_List] ADD  DEFAULT (newid()) FOR [Works_No]
GO
ALTER TABLE [dbo].[Works_List] ADD  DEFAULT ('') FOR [Materials_ID]
GO
ALTER TABLE [dbo].[Works_List] ADD  DEFAULT ('') FOR [WorksName]
GO
ALTER TABLE [dbo].[Works_List] ADD  DEFAULT ((0)) FOR [Year_Start]
GO
ALTER TABLE [dbo].[Works_List] ADD  DEFAULT ((0)) FOR [Year_End]
GO
ALTER TABLE [dbo].[Works_List] ADD  DEFAULT ('') FOR [Remarks]
GO
ALTER TABLE [dbo].[Works_List] ADD  DEFAULT ((0)) FOR [Cost]
GO
ALTER TABLE [dbo].[Works_List] ADD  DEFAULT ((0)) FOR [Price]
GO
ALTER TABLE [dbo].[Works_List] ADD  DEFAULT ((0.0)) FOR [GrossMargin]
GO
ALTER TABLE [dbo].[Works_List] ADD  DEFAULT ((0.0)) FOR [Marketability]
GO
ALTER TABLE [dbo].[Works_List] ADD  DEFAULT ((0.0)) FOR [Packageability]
GO
ALTER TABLE [dbo].[Works_List] ADD  DEFAULT ((0.0)) FOR [Valuability]
GO
ALTER TABLE [dbo].[Works_List] ADD  DEFAULT ((0.0)) FOR [Artisticability]
GO
ALTER TABLE [dbo].[Works_List] ADD  DEFAULT ('') FOR [CreateUser]
GO
ALTER TABLE [dbo].[Works_List] ADD  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Works_List] ADD  DEFAULT ('') FOR [ModifyUser]
GO
ALTER TABLE [dbo].[Works_Module_List] ADD  CONSTRAINT [DF_Works_Module_List_NoMeasure]  DEFAULT ('') FOR [Measure]
GO
ALTER TABLE [dbo].[Works_Module_List] ADD  CONSTRAINT [DF_Works_Module_List_Length]  DEFAULT ((0.0)) FOR [Length]
GO
ALTER TABLE [dbo].[Works_Module_List] ADD  CONSTRAINT [DF_Works_Module_List_Width]  DEFAULT ((0.0)) FOR [Width]
GO
ALTER TABLE [dbo].[Works_Module_List] ADD  CONSTRAINT [DF_Works_Module_List_High]  DEFAULT ((0.0)) FOR [High]
GO
ALTER TABLE [dbo].[Works_Module_List] ADD  CONSTRAINT [DF_Works_Module_List_Deep]  DEFAULT ((0.0)) FOR [Deep]
GO
ALTER TABLE [dbo].[Works_Module_List] ADD  CONSTRAINT [DF_Works_Module_List_TimeLength]  DEFAULT ('') FOR [TimeLength]
GO
ALTER TABLE [dbo].[Works_Module_List] ADD  CONSTRAINT [DF_Table_1_amount]  DEFAULT ((0)) FOR [Amount]
GO
ALTER TABLE [dbo].[Author_Prop_Area]  WITH CHECK ADD  CONSTRAINT [FK_Author_Prop_Area_Author_List] FOREIGN KEY([Author_No])
REFERENCES [dbo].[Author_List] ([Author_No])
GO
ALTER TABLE [dbo].[Author_Prop_Area] CHECK CONSTRAINT [FK_Author_Prop_Area_Author_List]
GO
ALTER TABLE [dbo].[Author_Prop_Area]  WITH CHECK ADD  CONSTRAINT [FK_Author_Prop_Area_Menu_AuthorArea] FOREIGN KEY([AuthorArea_No])
REFERENCES [dbo].[Menu_AuthorArea] ([AuthorArea_No])
GO
ALTER TABLE [dbo].[Author_Prop_Area] CHECK CONSTRAINT [FK_Author_Prop_Area_Menu_AuthorArea]
GO
ALTER TABLE [dbo].[Author_Prop_Tag]  WITH CHECK ADD  CONSTRAINT [FK_Author_Prop_Tag_Author_List] FOREIGN KEY([Author_No])
REFERENCES [dbo].[Author_List] ([Author_No])
GO
ALTER TABLE [dbo].[Author_Prop_Tag] CHECK CONSTRAINT [FK_Author_Prop_Tag_Author_List]
GO
ALTER TABLE [dbo].[Author_Prop_Tag]  WITH CHECK ADD  CONSTRAINT [FK_Author_Prop_Tag_Menu_AuthorTag] FOREIGN KEY([AuthorArea_No])
REFERENCES [dbo].[Menu_AuthorTag] ([AuthorTag_No])
GO
ALTER TABLE [dbo].[Author_Prop_Tag] CHECK CONSTRAINT [FK_Author_Prop_Tag_Menu_AuthorTag]
GO
ALTER TABLE [dbo].[PackageItemList]  WITH CHECK ADD  CONSTRAINT [FK_PackageItemList_Package_List] FOREIGN KEY([PG_No])
REFERENCES [dbo].[Package_List] ([PG_No])
GO
ALTER TABLE [dbo].[PackageItemList] CHECK CONSTRAINT [FK_PackageItemList_Package_List]
GO
ALTER TABLE [dbo].[PackageItemList]  WITH CHECK ADD  CONSTRAINT [FK_PackageItemList_Works_List] FOREIGN KEY([Works_No])
REFERENCES [dbo].[Works_List] ([Works_No])
GO
ALTER TABLE [dbo].[PackageItemList] CHECK CONSTRAINT [FK_PackageItemList_Works_List]
GO
ALTER TABLE [dbo].[Works_Author]  WITH CHECK ADD  CONSTRAINT [FK_Works_Author_Author_List] FOREIGN KEY([Author_No])
REFERENCES [dbo].[Author_List] ([Author_No])
GO
ALTER TABLE [dbo].[Works_Author] CHECK CONSTRAINT [FK_Works_Author_Author_List]
GO
ALTER TABLE [dbo].[Works_Author]  WITH CHECK ADD  CONSTRAINT [FK_Works_Author_Works_List] FOREIGN KEY([Works_No])
REFERENCES [dbo].[Works_List] ([Works_No])
GO
ALTER TABLE [dbo].[Works_Author] CHECK CONSTRAINT [FK_Works_Author_Works_List]
GO
ALTER TABLE [dbo].[Works_Module_List]  WITH CHECK ADD  CONSTRAINT [FK_Works_Module_List_Menu_CountNoun] FOREIGN KEY([CountNoun])
REFERENCES [dbo].[Menu_CountNoun] ([CountNoun_No])
GO
ALTER TABLE [dbo].[Works_Module_List] CHECK CONSTRAINT [FK_Works_Module_List_Menu_CountNoun]
GO
ALTER TABLE [dbo].[Works_Module_List]  WITH CHECK ADD  CONSTRAINT [FK_Works_Module_List_Menu_Material] FOREIGN KEY([Material])
REFERENCES [dbo].[Menu_Material] ([Material_No])
GO
ALTER TABLE [dbo].[Works_Module_List] CHECK CONSTRAINT [FK_Works_Module_List_Menu_Material]
GO
ALTER TABLE [dbo].[Works_Module_List]  WITH CHECK ADD  CONSTRAINT [FK_Works_Module_List_Works_List] FOREIGN KEY([Works_No])
REFERENCES [dbo].[Works_List] ([Works_No])
GO
ALTER TABLE [dbo].[Works_Module_List] CHECK CONSTRAINT [FK_Works_Module_List_Works_List]
GO
ALTER TABLE [dbo].[Works_Prop_Genre]  WITH CHECK ADD  CONSTRAINT [FK_Works_Prop_Genre_Menu_Genre] FOREIGN KEY([Genre_No])
REFERENCES [dbo].[Menu_Genre] ([Genre_No])
GO
ALTER TABLE [dbo].[Works_Prop_Genre] CHECK CONSTRAINT [FK_Works_Prop_Genre_Menu_Genre]
GO
ALTER TABLE [dbo].[Works_Prop_Genre]  WITH CHECK ADD  CONSTRAINT [FK_Works_Prop_Genre_Works_List] FOREIGN KEY([Works_No])
REFERENCES [dbo].[Works_List] ([Works_No])
GO
ALTER TABLE [dbo].[Works_Prop_Genre] CHECK CONSTRAINT [FK_Works_Prop_Genre_Works_List]
GO
ALTER TABLE [dbo].[Works_Prop_Owner]  WITH CHECK ADD  CONSTRAINT [FK_Works_Prop_Owner_Menu_Owner] FOREIGN KEY([Owner_No])
REFERENCES [dbo].[Menu_Owner] ([Owner_No])
GO
ALTER TABLE [dbo].[Works_Prop_Owner] CHECK CONSTRAINT [FK_Works_Prop_Owner_Menu_Owner]
GO
ALTER TABLE [dbo].[Works_Prop_Owner]  WITH CHECK ADD  CONSTRAINT [FK_Works_Prop_Owner_Works_List] FOREIGN KEY([Works_No])
REFERENCES [dbo].[Works_List] ([Works_No])
GO
ALTER TABLE [dbo].[Works_Prop_Owner] CHECK CONSTRAINT [FK_Works_Prop_Owner_Works_List]
GO
ALTER TABLE [dbo].[Works_Prop_Style]  WITH CHECK ADD  CONSTRAINT [FK_Works_Prop_Style_Menu_Style] FOREIGN KEY([Style_No])
REFERENCES [dbo].[Menu_Style] ([Style_No])
GO
ALTER TABLE [dbo].[Works_Prop_Style] CHECK CONSTRAINT [FK_Works_Prop_Style_Menu_Style]
GO
ALTER TABLE [dbo].[Works_Prop_Style]  WITH CHECK ADD  CONSTRAINT [FK_Works_Prop_Style_Works_List] FOREIGN KEY([Works_No])
REFERENCES [dbo].[Works_List] ([Works_No])
GO
ALTER TABLE [dbo].[Works_Prop_Style] CHECK CONSTRAINT [FK_Works_Prop_Style_Works_List]
GO
ALTER TABLE [dbo].[Works_Prop_WareType]  WITH CHECK ADD  CONSTRAINT [FK_Works_Prop_WareType_Menu_WareType] FOREIGN KEY([WareType_No])
REFERENCES [dbo].[Menu_WareType] ([WareType_No])
GO
ALTER TABLE [dbo].[Works_Prop_WareType] CHECK CONSTRAINT [FK_Works_Prop_WareType_Menu_WareType]
GO
ALTER TABLE [dbo].[Works_Prop_WareType]  WITH CHECK ADD  CONSTRAINT [FK_Works_Prop_WareType_Works_List] FOREIGN KEY([Works_No])
REFERENCES [dbo].[Works_List] ([Works_No])
GO
ALTER TABLE [dbo].[Works_Prop_WareType] CHECK CONSTRAINT [FK_Works_Prop_WareType_Works_List]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'藝術家序號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Author_List', @level2type=N'COLUMN',@level2name=N'Author_No'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物料代碼,來至於SAP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Author_List', @level2type=N'COLUMN',@level2name=N'Materials_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'藝術家中文名稱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Author_List', @level2type=N'COLUMN',@level2name=N'AuthorCName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'藝術家外文名稱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Author_List', @level2type=N'COLUMN',@level2name=N'AuthorEName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'建立者' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Author_List', @level2type=N'COLUMN',@level2name=N'CreateUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'建立時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Author_List', @level2type=N'COLUMN',@level2name=N'CreateDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改者' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Author_List', @level2type=N'COLUMN',@level2name=N'ModifyUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Author_List', @level2type=N'COLUMN',@level2name=N'ModifyDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'藝術家附加屬性_區域序號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Author_Prop_Area', @level2type=N'COLUMN',@level2name=N'AuthorPropArea_No'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'藝術家序號,對應dbo.Author_List.Author_No' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Author_Prop_Area', @level2type=N'COLUMN',@level2name=N'Author_No'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'附加屬性_區域,對應dbo.Menu_AuthorArea.AuthorArea_No' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Author_Prop_Area', @level2type=N'COLUMN',@level2name=N'AuthorArea_No'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'藝術家附加屬性_標籤序號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Author_Prop_Tag', @level2type=N'COLUMN',@level2name=N'Author_Prop_Tag_No'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'藝術家序號,對應dbo.Author_List.Author_No' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Author_Prop_Tag', @level2type=N'COLUMN',@level2name=N'Author_No'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'附加屬性_標籤,對應dbo.Menu_AuthorTag.AuthorTag_No' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Author_Prop_Tag', @level2type=N'COLUMN',@level2name=N'AuthorArea_No'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'藝術家區域編號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu_AuthorArea', @level2type=N'COLUMN',@level2name=N'AuthorArea_No'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'藝術家區域名稱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu_AuthorArea', @level2type=N'COLUMN',@level2name=N'AuthorArea_Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'藝術家標籤編號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu_AuthorTag', @level2type=N'COLUMN',@level2name=N'AuthorTag_No'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'藝術家標籤名稱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu_AuthorTag', @level2type=N'COLUMN',@level2name=N'AuthorTag_Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'量詞編號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu_CountNoun', @level2type=N'COLUMN',@level2name=N'CountNoun_No'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'量詞名稱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu_CountNoun', @level2type=N'COLUMN',@level2name=N'CountNoun_Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'類型編號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu_Genre', @level2type=N'COLUMN',@level2name=N'Genre_No'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'類型名稱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu_Genre', @level2type=N'COLUMN',@level2name=N'Genre_Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'媒材編號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu_Material', @level2type=N'COLUMN',@level2name=N'Material_No'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'媒材名稱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu_Material', @level2type=N'COLUMN',@level2name=N'Material_Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所有人編號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu_Owner', @level2type=N'COLUMN',@level2name=N'Owner_No'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所有人名稱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu_Owner', @level2type=N'COLUMN',@level2name=N'Owner_Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'風格編號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu_Style', @level2type=N'COLUMN',@level2name=N'Style_No'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'風格名稱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu_Style', @level2type=N'COLUMN',@level2name=N'Style_Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'庫別編號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu_WareType', @level2type=N'COLUMN',@level2name=N'WareType_No'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'庫別名稱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu_WareType', @level2type=N'COLUMN',@level2name=N'WareType_Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'包裝序號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Package_List', @level2type=N'COLUMN',@level2name=N'PG_No'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'包裝名稱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Package_List', @level2type=N'COLUMN',@level2name=N'PG_Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'到期時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Package_List', @level2type=N'COLUMN',@level2name=N'EndDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'打包時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Package_List', @level2type=N'COLUMN',@level2name=N'PackingDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'建立時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Package_List', @level2type=N'COLUMN',@level2name=N'CreateDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'建立者' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Package_List', @level2type=N'COLUMN',@level2name=N'CreateUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改者' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Package_List', @level2type=N'COLUMN',@level2name=N'ModifyUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Package_List', @level2type=N'COLUMN',@level2name=N'ModifyDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'包裝項目序號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PackageItemList', @level2type=N'COLUMN',@level2name=N'PGItem_No'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'包裝序號,對應dbo.Package_List.PG_No' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PackageItemList', @level2type=N'COLUMN',@level2name=N'PG_No'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作品序號,對應dbo.Works_List.Works_No' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PackageItemList', @level2type=N'COLUMN',@level2name=N'Works_No'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'加入日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PackageItemList', @level2type=N'COLUMN',@level2name=N'JoinDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'刪除日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PackageItemList', @level2type=N'COLUMN',@level2name=N'DelDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'使用者帳號序號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User_AccountList', @level2type=N'COLUMN',@level2name=N'Account_No'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密碼' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User_AccountList', @level2type=N'COLUMN',@level2name=N'Password'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密碼self' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User_AccountList', @level2type=N'COLUMN',@level2name=N'Pwdself'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'使用者名稱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User_AccountList', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'帳號角色' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User_AccountList', @level2type=N'COLUMN',@level2name=N'Account_Role'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'帳號狀態' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User_AccountList', @level2type=N'COLUMN',@level2name=N'Account_Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'帳號備註' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User_AccountList', @level2type=N'COLUMN',@level2name=N'Account_Note'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作品藝術家序號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works_Author', @level2type=N'COLUMN',@level2name=N'Works_Author_No'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作品序號,對應dbo.Works_List.Works_No' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works_Author', @level2type=N'COLUMN',@level2name=N'Works_No'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'藝術家序號,對應dbo.Author_List.Author_No' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works_Author', @level2type=N'COLUMN',@level2name=N'Author_No'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作品序號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works_List', @level2type=N'COLUMN',@level2name=N'Works_No'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物料代碼,來至於SAP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works_List', @level2type=N'COLUMN',@level2name=N'Materials_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'藝術家,對應dbo.Author_List.Author_No' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works_List', @level2type=N'COLUMN',@level2name=N'Author_No'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作品名稱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works_List', @level2type=N'COLUMN',@level2name=N'WorksName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作品起始年分' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works_List', @level2type=N'COLUMN',@level2name=N'Year_Start'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作品結束年分' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works_List', @level2type=N'COLUMN',@level2name=N'Year_End'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'備註' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works_List', @level2type=N'COLUMN',@level2name=N'Remarks'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'成本價' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works_List', @level2type=N'COLUMN',@level2name=N'Cost'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'定價' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works_List', @level2type=N'COLUMN',@level2name=N'Price'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'定價時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works_List', @level2type=N'COLUMN',@level2name=N'PricingDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'毛利率' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works_List', @level2type=N'COLUMN',@level2name=N'GrossMargin'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'市場性' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works_List', @level2type=N'COLUMN',@level2name=N'Marketability'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'包裹性' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works_List', @level2type=N'COLUMN',@level2name=N'Packageability'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'增值性' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works_List', @level2type=N'COLUMN',@level2name=N'Valuability'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'藝術性' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works_List', @level2type=N'COLUMN',@level2name=N'Artisticability'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'建立者' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works_List', @level2type=N'COLUMN',@level2name=N'CreateUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'建立時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works_List', @level2type=N'COLUMN',@level2name=N'CreateDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改者' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works_List', @level2type=N'COLUMN',@level2name=N'ModifyUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works_List', @level2type=N'COLUMN',@level2name=N'ModifyDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'組件序號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works_Module_List', @level2type=N'COLUMN',@level2name=N'Works_Module_No'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作品' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works_Module_List', @level2type=N'COLUMN',@level2name=N'Works_No'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'媒材' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works_Module_List', @level2type=N'COLUMN',@level2name=N'Material'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否測量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works_Module_List', @level2type=N'COLUMN',@level2name=N'Measure'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'長' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works_Module_List', @level2type=N'COLUMN',@level2name=N'Length'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'寬' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works_Module_List', @level2type=N'COLUMN',@level2name=N'Width'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'高' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works_Module_List', @level2type=N'COLUMN',@level2name=N'High'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'深' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works_Module_List', @level2type=N'COLUMN',@level2name=N'Deep'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'時間長度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works_Module_List', @level2type=N'COLUMN',@level2name=N'TimeLength'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'數量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works_Module_List', @level2type=N'COLUMN',@level2name=N'Amount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'量詞' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works_Module_List', @level2type=N'COLUMN',@level2name=N'CountNoun'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作品附加屬性_類型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works_Prop_Genre', @level2type=N'COLUMN',@level2name=N'Works_Prop_Genre_No'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作品序號,對應dbo.Works_List.Works_No' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works_Prop_Genre', @level2type=N'COLUMN',@level2name=N'Works_No'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'附加屬性類別,對應dbo.Menu_Genre.Genre_No' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works_Prop_Genre', @level2type=N'COLUMN',@level2name=N'Genre_No'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作品附加屬性_所有人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works_Prop_Owner', @level2type=N'COLUMN',@level2name=N'Works_Prop_Owner_No'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作品序號,對應dbo.Works_List.Works_No' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works_Prop_Owner', @level2type=N'COLUMN',@level2name=N'Works_No'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'附加屬性_所有人,對應dbo.Menu_Owner.Owner_No' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works_Prop_Owner', @level2type=N'COLUMN',@level2name=N'Owner_No'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作品附加屬性_風格' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works_Prop_Style', @level2type=N'COLUMN',@level2name=N'Works_Prop_Style_No'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作品序號,對應dbo.Works_List.Works_No' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works_Prop_Style', @level2type=N'COLUMN',@level2name=N'Works_No'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'附加屬性_風格,對應dbo.Menu_Style.Style_No' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works_Prop_Style', @level2type=N'COLUMN',@level2name=N'Style_No'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作品附加屬性_庫別' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works_Prop_WareType', @level2type=N'COLUMN',@level2name=N'Works_Prop_WareType_No'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作品序號,對應dbo.Works_List.Works_No' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works_Prop_WareType', @level2type=N'COLUMN',@level2name=N'Works_No'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'附加屬性_庫別,對應dbo.Menu_WareType.WareType_No' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Works_Prop_WareType', @level2type=N'COLUMN',@level2name=N'WareType_No'
GO
