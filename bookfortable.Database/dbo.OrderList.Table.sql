CREATE TABLE [OrderList](
	[OID] [int] IDENTITY(10000,1) NOT NULL,
	[OIDramd] [nvarchar](50) NULL,
	[OrderDetailID] [int] NULL,
	[OrderDate] [datetime] NULL,
	[isMember] [bit] NULL,
	[MemberID] [int] NULL,
	[PayDate] [datetime] NULL,
	[isPayed] [bit] NULL,
	[OrderTotal] [money] NULL,
	[ShippingTimeReq] [nvarchar](40) NULL,
	[OrderState] [nvarchar](20) NULL,
	[ShippingMethod] [nvarchar](50) NULL,
	[is711Pay] [bit] NULL,
	[Store711] [nvarchar](50) NULL,
	[CustomerName] [nvarchar](50) NULL,
	[CustomerPhone] [nvarchar](50) NULL,
	[CustomerEmail] [nvarchar](50) NULL,
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
	[OrderListNote] [nvarchar](255) NULL,
 CONSTRAINT [PK_OrderList] PRIMARY KEY CLUSTERED 
(
	[OID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [OrderList]  WITH CHECK ADD  CONSTRAINT [FK_OrderList_Members] FOREIGN KEY([MemberID])
REFERENCES [Members] ([MemberId])
GO
ALTER TABLE [OrderList] CHECK CONSTRAINT [FK_OrderList_Members]
GO
ALTER TABLE [OrderList]  WITH CHECK ADD  CONSTRAINT [FK_OrderList_OrderDetails] FOREIGN KEY([OrderDetailID])
REFERENCES [OrderDetails] ([ODID])
GO
ALTER TABLE [OrderList] CHECK CONSTRAINT [FK_OrderList_OrderDetails]
GO
ALTER TABLE [OrderList]  WITH CHECK ADD  CONSTRAINT [FK_OrderList_OrderList] FOREIGN KEY([OID])
REFERENCES [OrderList] ([OID])
GO
ALTER TABLE [OrderList] CHECK CONSTRAINT [FK_OrderList_OrderList]
GO
