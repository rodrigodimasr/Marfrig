CREATE DATABASE Marfrig
USE [Marfrig]
GO
/****** Object:  Table [dbo].[Animal]    Script Date: 11/12/2022 23:44:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Animal](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CriadoEm] [datetime] NOT NULL,
	[Descricao] [nvarchar](max) NOT NULL,
	[Preco] [float] NULL,
 CONSTRAINT [PK_Animal] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompraGado]    Script Date: 11/12/2022 23:44:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompraGado](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CriadoEm] [datetime] NOT NULL,
	[DataEntrega] [datetime] NOT NULL,
	[IDPecuarista] [int] NULL,
	[IndicaImpresso] [bit] NULL,
 CONSTRAINT [PK_CompraGado] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompraGadoItem]    Script Date: 11/12/2022 23:44:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompraGadoItem](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CriadoEm] [datetime] NOT NULL,
	[IDAnimal] [int] NOT NULL,
	[IDCompraGado] [int] NOT NULL,
	[Quantidade] [int] NOT NULL,
 CONSTRAINT [PK_CompraGadoItem] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pecuarista]    Script Date: 11/12/2022 23:44:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pecuarista](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CriadoEm] [datetime] NOT NULL,
	[Nome] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Pecuarista] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Animal] ON 

INSERT [dbo].[Animal] ([ID], [CriadoEm], [Descricao], [Preco]) VALUES (3, CAST(N'2022-12-12T00:00:00.000' AS DateTime), N'Angus', 100)
INSERT [dbo].[Animal] ([ID], [CriadoEm], [Descricao], [Preco]) VALUES (4, CAST(N'2022-12-12T00:00:00.000' AS DateTime), N'Brahman', 100)
INSERT [dbo].[Animal] ([ID], [CriadoEm], [Descricao], [Preco]) VALUES (5, CAST(N'2022-12-12T00:00:00.000' AS DateTime), N'Brangus', 100)
SET IDENTITY_INSERT [dbo].[Animal] OFF
GO
SET IDENTITY_INSERT [dbo].[CompraGado] ON 

INSERT [dbo].[CompraGado] ([ID], [CriadoEm], [DataEntrega], [IDPecuarista], [IndicaImpresso]) VALUES (8, CAST(N'2022-12-11T21:48:02.190' AS DateTime), CAST(N'2022-11-11T00:00:00.000' AS DateTime), 1, 0)
INSERT [dbo].[CompraGado] ([ID], [CriadoEm], [DataEntrega], [IDPecuarista], [IndicaImpresso]) VALUES (9, CAST(N'2022-12-11T23:02:22.937' AS DateTime), CAST(N'2020-11-11T00:00:00.000' AS DateTime), 1, 0)
INSERT [dbo].[CompraGado] ([ID], [CriadoEm], [DataEntrega], [IDPecuarista], [IndicaImpresso]) VALUES (10, CAST(N'2022-12-11T23:03:18.317' AS DateTime), CAST(N'2022-02-11T00:00:00.000' AS DateTime), 2, 0)
SET IDENTITY_INSERT [dbo].[CompraGado] OFF
GO
SET IDENTITY_INSERT [dbo].[CompraGadoItem] ON 

INSERT [dbo].[CompraGadoItem] ([ID], [CriadoEm], [IDAnimal], [IDCompraGado], [Quantidade]) VALUES (12, CAST(N'2022-12-11T21:48:02.203' AS DateTime), 4, 8, 12)
INSERT [dbo].[CompraGadoItem] ([ID], [CriadoEm], [IDAnimal], [IDCompraGado], [Quantidade]) VALUES (13, CAST(N'2022-12-11T21:48:24.330' AS DateTime), 3, 8, 123)
INSERT [dbo].[CompraGadoItem] ([ID], [CriadoEm], [IDAnimal], [IDCompraGado], [Quantidade]) VALUES (14, CAST(N'2022-12-11T23:02:22.957' AS DateTime), 4, 9, 2)
INSERT [dbo].[CompraGadoItem] ([ID], [CriadoEm], [IDAnimal], [IDCompraGado], [Quantidade]) VALUES (15, CAST(N'2022-12-11T23:03:18.327' AS DateTime), 4, 10, 22)
SET IDENTITY_INSERT [dbo].[CompraGadoItem] OFF
GO
SET IDENTITY_INSERT [dbo].[Pecuarista] ON 

INSERT [dbo].[Pecuarista] ([ID], [CriadoEm], [Nome]) VALUES (1, CAST(N'2022-12-11T00:00:00.000' AS DateTime), N'Pecuarista A')
INSERT [dbo].[Pecuarista] ([ID], [CriadoEm], [Nome]) VALUES (2, CAST(N'2022-12-11T00:00:00.000' AS DateTime), N'Pecuarista B')
SET IDENTITY_INSERT [dbo].[Pecuarista] OFF
GO
ALTER TABLE [dbo].[CompraGado]  WITH CHECK ADD  CONSTRAINT [FK_CompraGado_Pecuarista] FOREIGN KEY([IDPecuarista])
REFERENCES [dbo].[Pecuarista] ([ID])
GO
ALTER TABLE [dbo].[CompraGado] CHECK CONSTRAINT [FK_CompraGado_Pecuarista]
GO
ALTER TABLE [dbo].[CompraGadoItem]  WITH CHECK ADD  CONSTRAINT [FK_CompraGadoItem_Animal] FOREIGN KEY([IDAnimal])
REFERENCES [dbo].[Animal] ([ID])
GO
ALTER TABLE [dbo].[CompraGadoItem] CHECK CONSTRAINT [FK_CompraGadoItem_Animal]
GO
ALTER TABLE [dbo].[CompraGadoItem]  WITH CHECK ADD  CONSTRAINT [FK_CompraGadoItem_CompraGado] FOREIGN KEY([IDCompraGado])
REFERENCES [dbo].[CompraGado] ([ID])
GO
ALTER TABLE [dbo].[CompraGadoItem] CHECK CONSTRAINT [FK_CompraGadoItem_CompraGado]
GO
