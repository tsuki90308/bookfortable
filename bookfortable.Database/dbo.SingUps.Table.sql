CREATE TABLE [SingUps](
	[SignUpID] [int] IDENTITY(1,1) NOT NULL,
	[MemberID] [int] NULL,
	[EventId] [int] NULL,
	[EventName] [nvarchar](50) NULL,
	[EventDate] [datetime] NULL,
	[EventAddress] [nvarchar](50) NULL,
	[Eventhost] [nvarchar](50) NULL,
	[EventType] [nvarchar](50) NULL,
 CONSTRAINT [PK_SingUps] PRIMARY KEY CLUSTERED 
(
	[SignUpID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [SingUps]  WITH CHECK ADD  CONSTRAINT [FK_SingUps_Events] FOREIGN KEY([EventId])
REFERENCES [Events] ([EventID])
GO
ALTER TABLE [SingUps] CHECK CONSTRAINT [FK_SingUps_Events]
GO
ALTER TABLE [SingUps]  WITH CHECK ADD  CONSTRAINT [FK_SingUps_Members] FOREIGN KEY([MemberID])
REFERENCES [Members] ([MemberId])
GO
ALTER TABLE [SingUps] CHECK CONSTRAINT [FK_SingUps_Members]
GO
