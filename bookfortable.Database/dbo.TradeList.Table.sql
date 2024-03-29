CREATE TABLE [TradeList](
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
ALTER TABLE [TradeList]  WITH CHECK ADD  CONSTRAINT [FK_TradeList_Members] FOREIGN KEY([MemberId])
REFERENCES [Members] ([MemberId])
GO
ALTER TABLE [TradeList] CHECK CONSTRAINT [FK_TradeList_Members]
GO
ALTER TABLE [TradeList]  WITH CHECK ADD  CONSTRAINT [FK_TradeList_Product] FOREIGN KEY([ProductId])
REFERENCES [Product] ([ProductID])
GO
ALTER TABLE [TradeList] CHECK CONSTRAINT [FK_TradeList_Product]
GO
