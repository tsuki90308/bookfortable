CREATE TABLE [OrderDetails](
	[ODID] [int] IDENTITY(10000,1) NOT NULL,
	[OrderDetailID] [nvarchar](40) NULL,
	[TempBoxID] [int] NULL,
	[BookTag2string] [nvarchar](255) NULL,
	[ProductAmount] [int] NULL,
	[Price] [money] NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[ODID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_TempBox] FOREIGN KEY([TempBoxID])
REFERENCES [TempBox] ([BoxID])
GO
ALTER TABLE [OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_TempBox]
GO
