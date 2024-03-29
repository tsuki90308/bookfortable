CREATE TABLE [Message](
	[MessageId] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[MemberId] [int] NULL,
	[MessageDate] [datetime] NULL,
	[Message] [nvarchar](500) NULL,
 CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED 
(
	[MessageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [Message]  WITH CHECK ADD  CONSTRAINT [FK_Message_Members] FOREIGN KEY([MemberId])
REFERENCES [Members] ([MemberId])
GO
ALTER TABLE [Message] CHECK CONSTRAINT [FK_Message_Members]
GO
