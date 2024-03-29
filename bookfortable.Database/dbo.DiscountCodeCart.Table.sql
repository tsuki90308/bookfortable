CREATE TABLE [DiscountCodeCart](
	[DiscountID] [int] IDENTITY(10000,1) NOT NULL,
	[DiscountCode] [nvarchar](50) NULL,
	[DiscountType] [nvarchar](10) NULL,
	[DiscountStart] [datetime] NULL,
	[DiscountEnd] [datetime] NULL,
	[isMemberDiscount] [bit] NULL,
	[isPartnerDiscount] [bit] NULL,
	[PartnerName] [nvarchar](30) NULL,
	[PartnerManager] [nvarchar](30) NULL,
	[PartnerManagerEmail] [nvarchar](50) NULL,
	[PartnerManagerPhone] [nvarchar](50) NULL,
	[isActivate] [bit] NULL,
	[DiscountPrice] [money] NULL,
	[DiscountNote] [nvarchar](100) NULL,
 CONSTRAINT [PK_DiscountCodeCart] PRIMARY KEY CLUSTERED 
(
	[DiscountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
