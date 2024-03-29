CREATE TABLE [TempBox](
	[BoxID] [int] IDENTITY(1,1) NOT NULL,
	[BookTag2string] [nvarchar](255) NULL,
	[PriceRange] [money] NULL,
	[MemberID] [int] NULL,
	[CustomerPhone] [nvarchar](50) NULL,
	[CustomerEmail] [nvarchar](50) NULL,
	[BuildDate] [datetime] NULL,
 CONSTRAINT [PK_TempBox] PRIMARY KEY CLUSTERED 
(
	[BoxID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [TempBox]  WITH CHECK ADD  CONSTRAINT [FK_TempBox_Members] FOREIGN KEY([MemberID])
REFERENCES [Members] ([MemberId])
GO
ALTER TABLE [TempBox] CHECK CONSTRAINT [FK_TempBox_Members]
GO
