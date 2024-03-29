CREATE TABLE [Members](
	[MemberId] [int] IDENTITY(1,1) NOT NULL,
	[mAccount] [nvarchar](50) NOT NULL,
	[mPassword] [nvarchar](50) NOT NULL,
	[mName] [nvarchar](50) NOT NULL,
	[mMail] [nvarchar](50) NULL,
	[mFilepic] [nvarchar](100) NULL,
	[mCarrier] [nvarchar](50) NULL,
	[mPoints] [int] NULL,
	[mSubscription] [bit] NULL,
 CONSTRAINT [PK_Members] PRIMARY KEY CLUSTERED 
(
	[MemberId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
