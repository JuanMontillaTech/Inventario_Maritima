USE [InvMaritima]
GO
/****** Object:  Table [dbo].[Almacen]    Script Date: 5/6/2020 12:55:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Almacen](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [nvarchar](max) NOT NULL,
	[ubicacion] [nvarchar](max) NULL,
	[Capacidad] [nvarchar](max) NULL,
 CONSTRAINT [PK_Almacen] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Articulo]    Script Date: 5/6/2020 12:55:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articulo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](max) NULL,
	[Descripcion] [nvarchar](max) NULL,
 CONSTRAINT [PK_Articulo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invenatrio]    Script Date: 5/6/2020 12:55:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invenatrio](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idalmacen] [int] NOT NULL,
	[idarticulo] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
 CONSTRAINT [PK_Invenatrio] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Loginvenatario]    Script Date: 5/6/2020 12:55:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Loginvenatario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idubicacion] [int] NOT NULL,
	[idarticulo] [int] NOT NULL,
	[detalle] [nvarchar](max) NULL,
	[fecha] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Loginvenatario] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Precio]    Script Date: 5/6/2020 12:55:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Precio](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[precio] [decimal](18, 2) NOT NULL,
	[idArticulo] [int] NULL,
 CONSTRAINT [PK_Precio] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Almacen] ON 

INSERT [dbo].[Almacen] ([id], [descripcion], [ubicacion], [Capacidad]) VALUES (2, N'Almacen De gomas', N'Haina', N'15')
INSERT [dbo].[Almacen] ([id], [descripcion], [ubicacion], [Capacidad]) VALUES (4, N'Base Naval', N'San andres', N'152')
SET IDENTITY_INSERT [dbo].[Almacen] OFF
SET IDENTITY_INSERT [dbo].[Articulo] ON 

INSERT [dbo].[Articulo] ([id], [nombre], [Descripcion]) VALUES (3, N'Telefono', NULL)
INSERT [dbo].[Articulo] ([id], [nombre], [Descripcion]) VALUES (4, N'Zapatos', NULL)
SET IDENTITY_INSERT [dbo].[Articulo] OFF
SET IDENTITY_INSERT [dbo].[Loginvenatario] ON 

INSERT [dbo].[Loginvenatario] ([id], [idubicacion], [idarticulo], [detalle], [fecha]) VALUES (1, 2, 3, N'El Articulo Televisicion Entro en el Almacen Base 01 la fecha 5/5/2020 3:41:41 AM', CAST(N'2020-05-05T03:41:41.2997880' AS DateTime2))
INSERT [dbo].[Loginvenatario] ([id], [idubicacion], [idarticulo], [detalle], [fecha]) VALUES (2, 2, 2, N'El Articulo Gary articulos Salio en el Almacen Base 01 la fecha 5/5/2020 4:08:40 AM', CAST(N'2020-05-05T04:08:40.5330489' AS DateTime2))
INSERT [dbo].[Loginvenatario] ([id], [idubicacion], [idarticulo], [detalle], [fecha]) VALUES (3, 2, 2, N'El Articulo Gary articulos Salio en el Almacen Base 01 la fecha 5/5/2020 4:08:41 AM', CAST(N'2020-05-05T04:08:41.2359807' AS DateTime2))
INSERT [dbo].[Loginvenatario] ([id], [idubicacion], [idarticulo], [detalle], [fecha]) VALUES (4, 4, 2, N'El Articulo Gary articulos Salio en el Almacen Base Naval la fecha 5/5/2020 4:09:30 AM', CAST(N'2020-05-05T04:09:29.9964589' AS DateTime2))
INSERT [dbo].[Loginvenatario] ([id], [idubicacion], [idarticulo], [detalle], [fecha]) VALUES (5, 4, 2, N'El Articulo Gary articulos Salio en el Almacen Base Naval la fecha 5/5/2020 4:09:30 AM', CAST(N'2020-05-05T04:09:30.2803633' AS DateTime2))
INSERT [dbo].[Loginvenatario] ([id], [idubicacion], [idarticulo], [detalle], [fecha]) VALUES (6, 4, 3, N'El Articulo Telefono Salio en el Almacen Base Naval la fecha 5/6/2020 12:20:26 AM', CAST(N'2020-05-06T00:20:26.7194379' AS DateTime2))
INSERT [dbo].[Loginvenatario] ([id], [idubicacion], [idarticulo], [detalle], [fecha]) VALUES (7, 2, 3, N'El Articulo Telefono Entro en el Almacen Almacen De gomas la fecha 5/6/2020 12:21:09 AM', CAST(N'2020-05-06T00:21:09.6446095' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Loginvenatario] OFF
