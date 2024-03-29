CREATE TABLE [PickingOrder](
	[PKOID] [int] IDENTITY(1,1) NOT NULL,
	[PKOramd] [nvarchar](50) NULL,
	[OrderListID] [int] NULL,
	[OrderDetailsID] [int] NULL,
	[ProductID] [int] NULL,
	[EmployeeID] [int] NULL,
	[TempBoxID] [int] NULL,
	[PriceRange] [money] NULL,
 CONSTRAINT [PK_PickingOrder] PRIMARY KEY CLUSTERED 
(
	[PKOID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [PickingOrder]  WITH CHECK ADD  CONSTRAINT [FK_PickingOrder_Employees] FOREIGN KEY([EmployeeID])
REFERENCES [Employees] ([EmployeeId])
GO
ALTER TABLE [PickingOrder] CHECK CONSTRAINT [FK_PickingOrder_Employees]
GO
ALTER TABLE [PickingOrder]  WITH CHECK ADD  CONSTRAINT [FK_PickingOrder_OrderDetails] FOREIGN KEY([OrderDetailsID])
REFERENCES [OrderDetails] ([ODID])
GO
ALTER TABLE [PickingOrder] CHECK CONSTRAINT [FK_PickingOrder_OrderDetails]
GO
ALTER TABLE [PickingOrder]  WITH CHECK ADD  CONSTRAINT [FK_PickingOrder_PickingOrder] FOREIGN KEY([OrderListID])
REFERENCES [OrderList] ([OID])
GO
ALTER TABLE [PickingOrder] CHECK CONSTRAINT [FK_PickingOrder_PickingOrder]
GO
ALTER TABLE [PickingOrder]  WITH CHECK ADD  CONSTRAINT [FK_PickingOrder_Product] FOREIGN KEY([ProductID])
REFERENCES [Product] ([ProductID])
GO
ALTER TABLE [PickingOrder] CHECK CONSTRAINT [FK_PickingOrder_Product]
GO
ALTER TABLE [PickingOrder]  WITH CHECK ADD  CONSTRAINT [FK_PickingOrder_TempBox] FOREIGN KEY([TempBoxID])
REFERENCES [TempBox] ([BoxID])
GO
ALTER TABLE [PickingOrder] CHECK CONSTRAINT [FK_PickingOrder_TempBox]
GO
