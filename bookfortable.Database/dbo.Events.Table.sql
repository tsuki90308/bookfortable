CREATE TABLE [Events](
	[EventID] [int] IDENTITY(1,1) NOT NULL,
	[EventName] [nvarchar](40) NULL,
	[EventDate] [datetime] NULL,
	[EventTypeID] [int] NULL,
	[EventAddress] [nvarchar](40) NULL,
	[EventhostID] [int] NOT NULL,
	[fIamgePath] [nvarchar](50) NULL,
	[Eventhost] [nvarchar](50) NULL,
	[EventType] [nchar](10) NULL,
 CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED 
(
	[EventID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [Events]  WITH CHECK ADD  CONSTRAINT [FK_Events_Employees] FOREIGN KEY([EventhostID])
REFERENCES [Employees] ([EmployeeId])
GO
ALTER TABLE [Events] CHECK CONSTRAINT [FK_Events_Employees]
GO
ALTER TABLE [Events]  WITH CHECK ADD  CONSTRAINT [FK_Events_EvenType] FOREIGN KEY([EventTypeID])
REFERENCES [EvenType] ([EvenTypeID])
GO
ALTER TABLE [Events] CHECK CONSTRAINT [FK_Events_EvenType]
GO
