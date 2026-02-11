USE [Test]
GO

/****** Object:  Table [dbo].[CollegeMaster]    Script Date: 24-01-2026 14:56:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CollegeMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Department] [nvarchar](50) NOT NULL,
	[Location] [nvarchar](50) NULL,
	[Phone] [nchar](10) NULL,
	[Gender] [nvarchar](10) NULL,
	[M1] [decimal](10, 2) NULL,
	[M2] [decimal](10, 2) NULL,
	[M3] [decimal](10, 2) NULL,
	[Total] [decimal](10, 2) NULL,
	[Grade] [nvarchar](2) NULL,
 CONSTRAINT [PK_CollegeMaster1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [Test]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookMaster](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Author] [nvarchar](50) NOT NULL,
	[ISBN] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_BookMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [Test]
GO

/****** Object:  Table [dbo].[BoysHostel]    Script Date: 24-01-2026 14:56:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BoysHostel](
	[Id] [int] NOT NULL,
	[RoomNo] [int] NOT NULL,
	[StudentId] [int] NOT NULL,
 CONSTRAINT [PK_BoysHostel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[BoysHostel]  WITH CHECK ADD  CONSTRAINT [FK_BoysHostel_CollegeMaster] FOREIGN KEY([StudentId])
REFERENCES [dbo].[CollegeMaster] ([Id])
GO

ALTER TABLE [dbo].[BoysHostel] CHECK CONSTRAINT [FK_BoysHostel_CollegeMaster]
GO

USE [Test]
GO

/****** Object:  Table [dbo].[GirlsHostel]    Script Date: 24-01-2026 14:57:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[GirlsHostel](
	[Id] [int] NOT NULL,
	[RoomNo] [int] NOT NULL,
	[StudentId] [int] NOT NULL,
 CONSTRAINT [PK_GirlsHostel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[GirlsHostel]  WITH CHECK ADD  CONSTRAINT [FK_GirlsHostel_CollegeMaster] FOREIGN KEY([StudentId])
REFERENCES [dbo].[CollegeMaster] ([Id])
GO

ALTER TABLE [dbo].[GirlsHostel] CHECK CONSTRAINT [FK_GirlsHostel_CollegeMaster]
GO

USE [Test]
GO

/****** Object:  Table [dbo].[Library]    Script Date: 24-01-2026 14:57:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Library](
	[Id] [int] NOT NULL,
	[StudentId] [int] NOT NULL,
	[IssueDate] [date] NOT NULL,
	[BookId] [int] NOT NULL,
 CONSTRAINT [PK_Library] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Library]  WITH CHECK ADD  CONSTRAINT [FK_Library_BookMaster] FOREIGN KEY([BookId])
REFERENCES [dbo].[BookMaster] ([Id])
GO

ALTER TABLE [dbo].[Library] CHECK CONSTRAINT [FK_Library_BookMaster]
GO

ALTER TABLE [dbo].[Library]  WITH CHECK ADD  CONSTRAINT [FK_Library_CollegeMaster] FOREIGN KEY([StudentId])
REFERENCES [dbo].[CollegeMaster] ([Id])
GO

ALTER TABLE [dbo].[Library] CHECK CONSTRAINT [FK_Library_CollegeMaster]
GO

