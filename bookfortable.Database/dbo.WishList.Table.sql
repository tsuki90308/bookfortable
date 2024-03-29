CREATE TABLE [WishList](
	[WishListId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](50) NULL,
	[ProductImage] [nvarchar](50) NULL,
	[ProductId] [int] NULL,
	[ProductDescribe] [nvarchar](500) NULL,
	[WishPrice] [money] NULL,
	[Address] [nvarchar](50) NULL,
	[MemberId] [int] NULL,
	[CreationDate] [datetime] NULL,
	[Remark] [nvarchar](500) NULL,
 CONSTRAINT [PK_WishList] PRIMARY KEY CLUSTERED 
(
	[WishListId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [WishList]  WITH CHECK ADD  CONSTRAINT [FK_WishList_Members] FOREIGN KEY([MemberId])
REFERENCES [Members] ([MemberId])
GO
ALTER TABLE [WishList] CHECK CONSTRAINT [FK_WishList_Members]
GO
ALTER TABLE [WishList]  WITH CHECK ADD  CONSTRAINT [FK_WishList_Product] FOREIGN KEY([ProductId])
REFERENCES [Product] ([ProductID])
GO
ALTER TABLE [WishList] CHECK CONSTRAINT [FK_WishList_Product]
GO
