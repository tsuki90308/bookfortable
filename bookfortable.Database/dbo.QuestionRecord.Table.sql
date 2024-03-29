CREATE TABLE [QuestionRecord](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemberID] [int] NULL,
	[ResultID] [int] NULL,
	[Date] [date] NULL,
 CONSTRAINT [PK_QuestionRecord] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [QuestionRecord]  WITH CHECK ADD  CONSTRAINT [FK_QuestionRecord_Members] FOREIGN KEY([MemberID])
REFERENCES [Members] ([MemberId])
GO
ALTER TABLE [QuestionRecord] CHECK CONSTRAINT [FK_QuestionRecord_Members]
GO
ALTER TABLE [QuestionRecord]  WITH CHECK ADD  CONSTRAINT [FK_QuestionRecord_Result] FOREIGN KEY([ResultID])
REFERENCES [Result] ([ResultID])
GO
ALTER TABLE [QuestionRecord] CHECK CONSTRAINT [FK_QuestionRecord_Result]
GO
