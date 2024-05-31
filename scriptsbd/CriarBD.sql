/****** SCRIPT REDUNDANTE - PROGRAMA CRIA A PRÓPRIA BASE DE DADOS ******/














/****** Object:  Database [Projeto_2_Ano]    Script Date: 22/05/2024 17:40:10 ******/
CREATE DATABASE [Projeto_2_Ano]
  

USE Projeto_2_Ano
GO

/****** Object:  Table [dbo].[users]    Script Date: 22/05/2024 17:36:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NOT NULL,
	[password] [varchar](64) NOT NULL,
	[username] [varchar](100) NOT NULL,
 CONSTRAINT [Pk_users_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



USE Projeto_2_Ano
GO

/****** Object:  Table [dbo].[bank_accounts]    Script Date: 22/05/2024 17:36:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[bank_accounts](
	[userid] [int] NOT NULL,
	[pin] [varchar](64) NOT NULL,
	[saldo] [float] NOT NULL,
	[IBAN] [int] NOT NULL,
 CONSTRAINT [Pk_bankaccounts_userid] PRIMARY KEY CLUSTERED 
(
	[userid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[bank_accounts] ADD  CONSTRAINT [defo_bank_accounts_saldo]  DEFAULT ((0.00)) FOR [saldo]
GO

ALTER TABLE [dbo].[bank_accounts] ADD  CONSTRAINT [defo_bank_accounts_IBAN]  DEFAULT ((1300000000000000.)) FOR [IBAN]
GO

ALTER TABLE [dbo].[bank_accounts]  WITH CHECK ADD  CONSTRAINT [Fk_bankuid] FOREIGN KEY([userid])
REFERENCES [dbo].[users] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[bank_accounts] CHECK CONSTRAINT [Fk_bankuid]
GO

USE Projeto_2_Ano
GO

/****** Object:  Table [dbo].[bank_transactions]    Script Date: 22/05/2024 17:36:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[bank_transactions](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userid] [int] NOT NULL,
	[time] [datetime] NOT NULL,
	[name] [varchar](250) NOT NULL,
	[variation] [float] NOT NULL,
	[finalbalance] [float] NOT NULL,
 CONSTRAINT [Pk_banktransactions_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[bank_transactions] ADD  CONSTRAINT [defo_bank_transactions_time]  DEFAULT (getdate()) FOR [time]
GO

ALTER TABLE [dbo].[bank_transactions]  WITH CHECK ADD  CONSTRAINT [FK_banktransuid] FOREIGN KEY([userid])
REFERENCES [dbo].[bank_accounts] ([userid])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[bank_transactions] CHECK CONSTRAINT [FK_banktransuid]
GO

USE Projeto_2_Ano
GO


USE [Projeto_2_Ano]
GO

/****** Object:  Table [dbo].[shop_categories]    Script Date: 23/05/2024 09:04:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[shop_categories](
	[name] [varchar](100) NOT NULL,
	[id] [int] NOT NULL,
 CONSTRAINT [Pk_shop_categories_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO





USE [Projeto_2_Ano]
GO

/****** Object:  Table [dbo].[shop_products]    Script Date: 23/05/2024 09:05:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[shop_products](
	[idprod] [int] IDENTITY(1,1) NOT NULL,
	[idcat] [int] NOT NULL,
	[catpos] [int] NOT NULL,
	[name] [varchar](100) NOT NULL,
	[description] [varchar](500) NULL,
	[stock] [int] NOT NULL,
	[price] [float] NOT NULL,
 CONSTRAINT [Pk_produtos_idpr] PRIMARY KEY CLUSTERED 
(
	[idprod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[shop_products]  WITH CHECK ADD  CONSTRAINT [fk_idcat] FOREIGN KEY([idcat])
REFERENCES [dbo].[shop_categories] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[shop_products] CHECK CONSTRAINT [fk_idcat]
GO





