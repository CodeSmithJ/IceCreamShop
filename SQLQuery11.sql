USE [IceCreamShop]
GO

/****** Object:  Table [dbo].[OrderView]    Script Date: 7/10/2021 11:40:54 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OrderView_save](
	[OrderViewId] [int] NOT NULL,
	[IceCreamOrderId] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[FlavorName] [nvarchar](max) NULL,
	[FlavorPrice] [float] NOT NULL,
	[ToppingPrice] [float] NOT NULL,
	[Price] [float] NOT NULL,
	[CustomerName] [nvarchar](max) NULL,
	[Payment] [nvarchar](max) NULL,
	[ToppingName] [nvarchar](max) NULL,
) 
GO



