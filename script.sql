USE [Final]
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 2024/1/19 下午 04:19:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Addresses](
	[AddressId] [int] IDENTITY(1,1) NOT NULL,
	[aRegioncode] [int] NOT NULL,
	[aAddress] [nvarchar](100) NOT NULL,
	[MemberId] [int] NOT NULL,
 CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED 
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookTag]    Script Date: 2024/1/19 下午 04:19:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookTag](
	[BtagId] [int] NOT NULL,
	[BtagName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_BookTag] PRIMARY KEY CLUSTERED 
(
	[BtagId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DiscountCodeCart]    Script Date: 2024/1/19 下午 04:19:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiscountCodeCart](
	[DiscountID] [int] IDENTITY(10000,1) NOT NULL,
	[DiscountCode] [nvarchar](50) NULL,
	[DiscountType] [nvarchar](10) NULL,
	[DiscountStart] [datetime] NULL,
	[DiscountEnd] [datetime] NULL,
	[isMemberDiscount] [int] NULL,
	[isPartnerDiscount] [int] NULL,
	[PartnerName] [nvarchar](30) NULL,
	[PartnerManager] [nvarchar](30) NULL,
	[PartnerManagerEmail] [varchar](50) NULL,
	[PartnerManagerPhone] [varchar](10) NULL,
	[isActivate] [int] NULL,
	[DiscountPrice] [money] NULL,
	[DiscountNote] [nvarchar](100) NULL,
 CONSTRAINT [PK_DiscountCodeCart] PRIMARY KEY CLUSTERED 
(
	[DiscountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 2024/1/19 下午 04:19:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[eName] [nvarchar](50) NOT NULL,
	[ePassword] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Events]    Script Date: 2024/1/19 下午 04:19:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Events](
	[EventID] [int] IDENTITY(1,1) NOT NULL,
	[EventName] [nvarchar](40) NULL,
	[EventDate] [datetime] NULL,
	[EventTypeID] [int] NULL,
	[EventAddress] [nvarchar](40) NULL,
	[EventhostID] [int] NOT NULL,
 CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED 
(
	[EventID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EvenType]    Script Date: 2024/1/19 下午 04:19:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EvenType](
	[EvenTypeID] [int] IDENTITY(1,1) NOT NULL,
	[EvenTypeName] [nvarchar](40) NULL,
 CONSTRAINT [PK_EvenType] PRIMARY KEY CLUSTERED 
(
	[EvenTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Members]    Script Date: 2024/1/19 下午 04:19:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Members](
	[MemberId] [int] IDENTITY(1,1) NOT NULL,
	[mAccount] [nvarchar](50) NOT NULL,
	[mPassword] [nvarchar](50) NOT NULL,
	[mName] [nvarchar](50) NOT NULL,
	[mMail] [nvarchar](50) NULL,
	[mFilepic] [nvarchar](100) NULL,
	[mCarrier] [nvarchar](50) NULL,
	[mPoints] [int] NULL,
 CONSTRAINT [PK_Members] PRIMARY KEY CLUSTERED 
(
	[MemberId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Message]    Script Date: 2024/1/19 下午 04:19:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Message](
	[MessageId] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[MemberId] [int] NULL,
	[MessageDate] [datetime] NULL,
	[Message] [nvarchar](500) NULL,
 CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED 
(
	[MessageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MyCoupons]    Script Date: 2024/1/19 下午 04:19:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MyCoupons](
	[McId] [int] IDENTITY(1,1) NOT NULL,
	[DicountId] [int] NOT NULL,
	[MemberId] [int] NOT NULL,
 CONSTRAINT [PK_MyCoupons] PRIMARY KEY CLUSTERED 
(
	[McId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 2024/1/19 下午 04:19:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[ODID] [int] IDENTITY(10000,1) NOT NULL,
	[OrderDetailID] [nvarchar](40) NULL,
	[ProductID] [int] NULL,
	[ProductAmount] [int] NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[ODID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderList]    Script Date: 2024/1/19 下午 04:19:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderList](
	[OID] [int] IDENTITY(10000,1) NOT NULL,
	[OIDramd] [nvarchar](50) NULL,
	[OrderDetailID] [int] NULL,
	[OrderDate] [datetime] NULL,
	[isMember] [int] NULL,
	[MemberID] [int] NULL,
	[PayDate] [datetime] NULL,
	[isPayed] [int] NULL,
	[OrderTotal] [money] NULL,
	[ShippingTimeReq] [nvarchar](40) NULL,
	[OrderState] [nvarchar](20) NULL,
	[ShippingMethod] [nvarchar](50) NULL,
	[is711Pay] [int] NULL,
	[Store711] [nvarchar](50) NULL,
	[CustomerName] [nvarchar](50) NULL,
	[CustomerPhone] [varchar](10) NULL,
	[CustomerEmail] [varchar](50) NULL,
	[CustomerAdd1] [nvarchar](5) NULL,
	[CustomerAdd2] [nvarchar](7) NULL,
	[CustomerAdd3] [nvarchar](50) NULL,
	[ShippingName] [nvarchar](5) NULL,
	[ShippingPhone] [nchar](10) NULL,
	[ShippingAdd1] [nvarchar](5) NULL,
	[ShippingAdd2] [nvarchar](7) NULL,
	[ShippingAdd3] [nvarchar](50) NULL,
	[PHinvoice] [nvarchar](10) NULL,
	[CPinvoice] [nchar](10) NULL,
	[CPtitle] [nvarchar](30) NULL,
	[PayMethod] [nvarchar](5) NULL,
	[DiscountCode] [nvarchar](50) NULL,
	[DiscountPrice] [money] NULL,
	[ShippingFeed] [money] NULL,
	[Points] [int] NULL,
	[OrderListNote] [nvarchar](50) NULL,
 CONSTRAINT [PK_OrderList] PRIMARY KEY CLUSTERED 
(
	[OID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 2024/1/19 下午 04:19:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](50) NULL,
	[SupplierID] [nvarchar](50) NULL,
	[ProductPhoto] [nvarchar](50) NULL,
	[Description] [nvarchar](400) NULL,
	[UnitPrice] [money] NULL,
	[UnitsInStock] [int] NULL,
	[VersionInfo] [nvarchar](50) NULL,
	[PublicationDate] [date] NULL,
	[SellingPrice] [money] NULL,
	[ISBN] [nvarchar](50) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Relation]    Script Date: 2024/1/19 下午 04:19:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Relation](
	[SortId] [int] IDENTITY(1,1) NOT NULL,
	[Product_Id] [int] NOT NULL,
	[BookTag_Id] [int] NOT NULL,
 CONSTRAINT [PK_Relation] PRIMARY KEY CLUSTERED 
(
	[SortId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SingUps]    Script Date: 2024/1/19 下午 04:19:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SingUps](
	[SignUpID] [int] IDENTITY(1,1) NOT NULL,
	[MemberID] [int] NULL,
	[EventId] [int] NULL,
 CONSTRAINT [PK_SingUps] PRIMARY KEY CLUSTERED 
(
	[SignUpID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TradeList]    Script Date: 2024/1/19 下午 04:19:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TradeList](
	[TradeListId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](50) NULL,
	[ProductImage] [nvarchar](50) NULL,
	[ProductId] [int] NULL,
	[ProductDescribe] [nvarchar](500) NULL,
	[Address] [nvarchar](50) NULL,
	[MemberId] [int] NULL,
	[State] [nvarchar](50) NULL,
	[Remark] [nvarchar](500) NULL,
 CONSTRAINT [PK_TradeList] PRIMARY KEY CLUSTERED 
(
	[TradeListId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WishList]    Script Date: 2024/1/19 下午 04:19:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WishList](
	[WishListId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](50) NULL,
	[ProductImage] [nvarchar](50) NULL,
	[ProductId] [int] NULL,
	[ProductDescribe] [nvarchar](500) NULL,
	[WishPrice] [money] NULL,
	[Address] [nvarchar](50) NULL,
	[MemberId] [int] NULL,
	[CreationDate] [date] NULL,
	[Remark] [nvarchar](500) NULL,
 CONSTRAINT [PK_WishList] PRIMARY KEY CLUSTERED 
(
	[WishListId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[BookTag] ([BtagId], [BtagName]) VALUES (1, N'旅遊')
INSERT [dbo].[BookTag] ([BtagId], [BtagName]) VALUES (2, N'飲食')
INSERT [dbo].[BookTag] ([BtagId], [BtagName]) VALUES (3, N'歷史')
INSERT [dbo].[BookTag] ([BtagId], [BtagName]) VALUES (4, N'科幻')
INSERT [dbo].[BookTag] ([BtagId], [BtagName]) VALUES (5, N'心理')
INSERT [dbo].[BookTag] ([BtagId], [BtagName]) VALUES (6, N'商業')
GO
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([EmployeeId], [eName], [ePassword]) VALUES (1, N'sp', N'eee')
INSERT [dbo].[Employees] ([EmployeeId], [eName], [ePassword]) VALUES (2, N'wee', N'ewwe')
INSERT [dbo].[Employees] ([EmployeeId], [eName], [ePassword]) VALUES (3, N'dsd', N'weww')
SET IDENTITY_INSERT [dbo].[Employees] OFF
GO
SET IDENTITY_INSERT [dbo].[Events] ON 

INSERT [dbo].[Events] ([EventID], [EventName], [EventDate], [EventTypeID], [EventAddress], [EventhostID]) VALUES (1, N'二手書交換', CAST(N'2024-01-01T00:00:00.000' AS DateTime), 1, N'高雄市前金區中正四路211號8號樓之1', 1)
INSERT [dbo].[Events] ([EventID], [EventName], [EventDate], [EventTypeID], [EventAddress], [EventhostID]) VALUES (2, N'二手書收購', CAST(N'2024-02-01T00:00:00.000' AS DateTime), 2, N'高雄市前金區中正四路211號8號樓之1', 2)
INSERT [dbo].[Events] ([EventID], [EventName], [EventDate], [EventTypeID], [EventAddress], [EventhostID]) VALUES (3, N'親子說故事', CAST(N'2024-03-01T00:00:00.000' AS DateTime), 3, N'高雄市前金區中正四路211號8號樓之1', 3)
SET IDENTITY_INSERT [dbo].[Events] OFF
GO
SET IDENTITY_INSERT [dbo].[EvenType] ON 

INSERT [dbo].[EvenType] ([EvenTypeID], [EvenTypeName]) VALUES (1, N'二手書交換')
INSERT [dbo].[EvenType] ([EvenTypeID], [EvenTypeName]) VALUES (2, N'二手書收購')
INSERT [dbo].[EvenType] ([EvenTypeID], [EvenTypeName]) VALUES (3, N'親子說故事')
SET IDENTITY_INSERT [dbo].[EvenType] OFF
GO
SET IDENTITY_INSERT [dbo].[Members] ON 

INSERT [dbo].[Members] ([MemberId], [mAccount], [mPassword], [mName], [mMail], [mFilepic], [mCarrier], [mPoints]) VALUES (2, N'1', N'3', N'2', N'2', N'2', N'6', 6)
INSERT [dbo].[Members] ([MemberId], [mAccount], [mPassword], [mName], [mMail], [mFilepic], [mCarrier], [mPoints]) VALUES (3, N'6', N'5', N'6', N'5', N'65', N'90', 5)
INSERT [dbo].[Members] ([MemberId], [mAccount], [mPassword], [mName], [mMail], [mFilepic], [mCarrier], [mPoints]) VALUES (6, N'5', N'6', N'5', N'5', N'5', N'5', 5)
SET IDENTITY_INSERT [dbo].[Members] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ProductID], [ProductName], [SupplierID], [ProductPhoto], [Description], [UnitPrice], [UnitsInStock], [VersionInfo], [PublicationDate], [SellingPrice], [ISBN]) VALUES (1, N'日本地方鐵道之旅：88條美景路線&深度鐵道旅遊提案 日本鐵道系列', N'人人出版', NULL, N'規格：平裝 / 256頁 / 18 x 26 x 1.5 cm / 普通級 / 全彩印刷 / 初版', 600.0000, 20, N'初版', CAST(N'2023-06-25' AS Date), 474.0000, N'9789864613366')
INSERT [dbo].[Product] ([ProductID], [ProductName], [SupplierID], [ProductPhoto], [Description], [UnitPrice], [UnitsInStock], [VersionInfo], [PublicationDate], [SellingPrice], [ISBN]) VALUES (2, N'
!上頁
下頁

選書
馬斯克傳：唯一不設限、全公開傳記', N'天下雜誌', NULL, N'規格：軟精裝 / 832頁 / 15 x 21.5 x 4.16 cm / 普通級 / 單色印刷 / 初版', 1080.0000, 20, N'初版', CAST(N'2023-09-27' AS Date), 853.0000, N'9789863989202')
INSERT [dbo].[Product] ([ProductID], [ProductName], [SupplierID], [ProductPhoto], [Description], [UnitPrice], [UnitsInStock], [VersionInfo], [PublicationDate], [SellingPrice], [ISBN]) VALUES (3, N'心流：高手都在研究的最優體驗心理學', N'行路 ', NULL, N'規格：平裝 / 368頁 / 17 x 22.5 x 2.5 cm / 普通級 / 單色印刷 / 再版', 580.0000, 20, N'再版', CAST(N'2023-02-15' AS Date), 382.0000, N'9786267244036')
INSERT [dbo].[Product] ([ProductID], [ProductName], [SupplierID], [ProductPhoto], [Description], [UnitPrice], [UnitsInStock], [VersionInfo], [PublicationDate], [SellingPrice], [ISBN]) VALUES (4, N'敘事塔羅：運用塔羅圖像展開與自我對話的生命敘事，讓身心靈在困境中成長，走出屬於自己的幸福之道', N'地平線文化', NULL, N'規格：平裝 / 368頁 / 14.8 x 21 x 1.8 cm / 普通級 / 部份全彩 / 初版', 450.0000, 20, N'初版', CAST(N'2024-01-08' AS Date), 355.0000, N'9786269767991
')
INSERT [dbo].[Product] ([ProductID], [ProductName], [SupplierID], [ProductPhoto], [Description], [UnitPrice], [UnitsInStock], [VersionInfo], [PublicationDate], [SellingPrice], [ISBN]) VALUES (5, N'在阿卡西紀錄中發現你的靈魂道路', N'黃裳元吉', NULL, N'規格：平裝 / 250頁 / 15 x 21 x 1.25 cm / 普通級 / 雙色印刷 / 初版', 380.0000, 20, N'初版', CAST(N'2017-12-10' AS Date), 266.0000, N'9789869472241')
INSERT [dbo].[Product] ([ProductID], [ProductName], [SupplierID], [ProductPhoto], [Description], [UnitPrice], [UnitsInStock], [VersionInfo], [PublicationDate], [SellingPrice], [ISBN]) VALUES (6, N'日本百味散步帳：四季都好吃的一期一繪', N'時報出版', NULL, N'規格：平裝 / 224頁 / 14.8 x 21 x 1.32 cm / 普通級 / 全彩印刷 / 初版', 480.0000, 20, N'初版', CAST(N'2023-11-14' AS Date), 379.0000, N'9786263744240')
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[Relation] ON 

INSERT [dbo].[Relation] ([SortId], [Product_Id], [BookTag_Id]) VALUES (1, 1, 1)
INSERT [dbo].[Relation] ([SortId], [Product_Id], [BookTag_Id]) VALUES (2, 2, 2)
INSERT [dbo].[Relation] ([SortId], [Product_Id], [BookTag_Id]) VALUES (3, 3, 3)
INSERT [dbo].[Relation] ([SortId], [Product_Id], [BookTag_Id]) VALUES (4, 4, 4)
INSERT [dbo].[Relation] ([SortId], [Product_Id], [BookTag_Id]) VALUES (5, 5, 5)
INSERT [dbo].[Relation] ([SortId], [Product_Id], [BookTag_Id]) VALUES (6, 6, 6)
SET IDENTITY_INSERT [dbo].[Relation] OFF
GO
ALTER TABLE [dbo].[Addresses]  WITH CHECK ADD  CONSTRAINT [FK_Addresses_Members] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Members] ([MemberId])
GO
ALTER TABLE [dbo].[Addresses] CHECK CONSTRAINT [FK_Addresses_Members]
GO
ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_Events_Employees] FOREIGN KEY([EventhostID])
REFERENCES [dbo].[Employees] ([EmployeeId])
GO
ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_Events_Employees]
GO
ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_Events_EvenType] FOREIGN KEY([EventTypeID])
REFERENCES [dbo].[EvenType] ([EvenTypeID])
GO
ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_Events_EvenType]
GO
ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [FK_Message_Members] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Members] ([MemberId])
GO
ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [FK_Message_Members]
GO
ALTER TABLE [dbo].[MyCoupons]  WITH CHECK ADD  CONSTRAINT [FK_MyCoupons_DiscountCodeCart] FOREIGN KEY([DicountId])
REFERENCES [dbo].[DiscountCodeCart] ([DiscountID])
GO
ALTER TABLE [dbo].[MyCoupons] CHECK CONSTRAINT [FK_MyCoupons_DiscountCodeCart]
GO
ALTER TABLE [dbo].[MyCoupons]  WITH CHECK ADD  CONSTRAINT [FK_MyCoupons_Members] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Members] ([MemberId])
GO
ALTER TABLE [dbo].[MyCoupons] CHECK CONSTRAINT [FK_MyCoupons_Members]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Product]
GO
ALTER TABLE [dbo].[OrderList]  WITH CHECK ADD  CONSTRAINT [FK_OrderList_Members] FOREIGN KEY([MemberID])
REFERENCES [dbo].[Members] ([MemberId])
GO
ALTER TABLE [dbo].[OrderList] CHECK CONSTRAINT [FK_OrderList_Members]
GO
ALTER TABLE [dbo].[OrderList]  WITH CHECK ADD  CONSTRAINT [FK_OrderList_OrderDetails] FOREIGN KEY([OrderDetailID])
REFERENCES [dbo].[OrderDetails] ([ODID])
GO
ALTER TABLE [dbo].[OrderList] CHECK CONSTRAINT [FK_OrderList_OrderDetails]
GO
ALTER TABLE [dbo].[Relation]  WITH CHECK ADD  CONSTRAINT [FK_Relation_BookTag] FOREIGN KEY([BookTag_Id])
REFERENCES [dbo].[BookTag] ([BtagId])
GO
ALTER TABLE [dbo].[Relation] CHECK CONSTRAINT [FK_Relation_BookTag]
GO
ALTER TABLE [dbo].[Relation]  WITH CHECK ADD  CONSTRAINT [FK_Relation_Product] FOREIGN KEY([Product_Id])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[Relation] CHECK CONSTRAINT [FK_Relation_Product]
GO
ALTER TABLE [dbo].[SingUps]  WITH CHECK ADD  CONSTRAINT [FK_SingUps_Events] FOREIGN KEY([EventId])
REFERENCES [dbo].[Events] ([EventID])
GO
ALTER TABLE [dbo].[SingUps] CHECK CONSTRAINT [FK_SingUps_Events]
GO
ALTER TABLE [dbo].[SingUps]  WITH CHECK ADD  CONSTRAINT [FK_SingUps_Members] FOREIGN KEY([MemberID])
REFERENCES [dbo].[Members] ([MemberId])
GO
ALTER TABLE [dbo].[SingUps] CHECK CONSTRAINT [FK_SingUps_Members]
GO
ALTER TABLE [dbo].[TradeList]  WITH CHECK ADD  CONSTRAINT [FK_TradeList_Members] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Members] ([MemberId])
GO
ALTER TABLE [dbo].[TradeList] CHECK CONSTRAINT [FK_TradeList_Members]
GO
ALTER TABLE [dbo].[TradeList]  WITH CHECK ADD  CONSTRAINT [FK_TradeList_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[TradeList] CHECK CONSTRAINT [FK_TradeList_Product]
GO
ALTER TABLE [dbo].[WishList]  WITH CHECK ADD  CONSTRAINT [FK_WishList_Members] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Members] ([MemberId])
GO
ALTER TABLE [dbo].[WishList] CHECK CONSTRAINT [FK_WishList_Members]
GO
ALTER TABLE [dbo].[WishList]  WITH CHECK ADD  CONSTRAINT [FK_WishList_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[WishList] CHECK CONSTRAINT [FK_WishList_Product]
GO
