creacion de las tablas en la base Geopagos:

USE [Geopagos]
GO

/****** Object:  Table [dbo].[PaymentRequests]    Script Date: 9/4/2024 11:51:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PaymentRequests](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [nvarchar](255) NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[RequestDate] [datetime] NOT NULL,
	[IsConfirmed] [bit] NOT NULL,
	[ConfirmationDate] [datetime] NULL,
	[ClientType] [int] NULL,
	[Status] [int] NULL,
	[Type] [int] NULL,
PRIMARY KEY CLUSTERED 

*******************************************************************


USE [Geopagos]
GO

/****** Object:  Table [dbo].[ApprovedAuthorizations]    Script Date: 9/4/2024 11:50:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ApprovedAuthorizations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AuthorizationDate] [datetime] NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[ClientId] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO




