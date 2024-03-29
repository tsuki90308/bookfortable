CREATE TABLE [Product](
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
