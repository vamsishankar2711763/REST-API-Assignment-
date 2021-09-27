Create Table [dbo].[Actor](
[ActorId] [int] IDENTITY(1,1) NOT NULL,
[ActorName] [nvarchar](max) NULL,
[Bio] [nvarchar](max) NULL,
[DOB] datetime NULL,
[Gender] varchar(10) NULL,
CONSTRAINT [PK_Actor] PRIMARY KEY CLUSTERED
(
	[ActorId] ASC
	) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
	GO

Create Table [dbo].[Producer](
[ProducerId] [int] IDENTITY(1,1) NOT NULL,
[ProducerName] [nvarchar](max) NULL,
[DOB] datetime NULL,
[Company] [nvarchar](max) NULL,
[Gender] varchar(10) NULL,
CONSTRAINT [PK_Producer] PRIMARY KEY CLUSTERED
(
	[ProducerId] ASC
	) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
	GO


Create Table [dbo].[Movie](
[MovieId] [int] IDENTITY(1,1) NOT NULL,
[MovieName] [nvarchar](max) NULL,
[ReleaseDate] datetime NULL,
[Plot] [nvarchar](max) NULL,
[Poster] varbinary(max) NULL,
CONSTRAINT [PK_Movie] PRIMARY KEY CLUSTERED
(
	[MovieId] ASC
	) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
	GO

CREATE TABLE [dbo].[ActorMovie](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MovieId] [int] NULL,
	[ActorId] [int] NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ActorMovie]  WITH CHECK ADD FOREIGN KEY([ActorId])
REFERENCES [dbo].[Actor] ([ActorId])
GO

ALTER TABLE [dbo].[ActorMovie]  WITH CHECK ADD FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movie] ([MovieId])
GO


CREATE TABLE [dbo].[ProducerMovie](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MovieId] [int] NULL,
	[ProducerId] [int] NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ProducerMovie]  WITH CHECK ADD FOREIGN KEY([ProducerId])
REFERENCES [dbo].[Producer] ([ProducerId])
GO

ALTER TABLE [dbo].[ProducerMovie]  WITH CHECK ADD FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movie] ([MovieId])
GO
