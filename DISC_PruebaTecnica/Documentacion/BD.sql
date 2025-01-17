USE [PruebaTecnica]
GO
/****** Object:  Table [dbo].[CategoriaProducto]    Script Date: 31/10/2024 04:43:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoriaProducto](
	[idCategoria] [int] IDENTITY(1,1) NOT NULL,
	[nombreCategoria] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 31/10/2024 04:43:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[idCliente] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellidos] [varchar](50) NOT NULL,
	[DNI] [varchar](15) NOT NULL,
	[direccion] [varchar](100) NULL,
	[fechaNacimiento] [date] NULL,
	[activo] [bit] NULL,
	[correoElectronico] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleOrden]    Script Date: 31/10/2024 04:43:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleOrden](
	[idDetalle] [int] IDENTITY(1,1) NOT NULL,
	[precioCompra] [decimal](10, 2) NOT NULL,
	[cantidad] [int] NOT NULL,
	[idOrden] [int] NULL,
	[idProducto] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstadoEnvio]    Script Date: 31/10/2024 04:43:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstadoEnvio](
	[idEstado] [int] IDENTITY(1,1) NOT NULL,
	[nombreEstado] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idEstado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orden]    Script Date: 31/10/2024 04:43:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orden](
	[idOrden] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [date] NOT NULL,
	[idEstado] [int] NOT NULL,
	[total] [decimal](10, 2) NOT NULL,
	[idCliente] [int] NULL,
	[idSucursal] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idOrden] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 31/10/2024 04:43:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[idProducto] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[codigo] [varchar](20) NOT NULL,
	[descripcion] [text] NULL,
	[precioUnitario] [decimal](10, 2) NOT NULL,
	[activo] [bit] NULL,
	[idCategoria] [int] NOT NULL,
	[idProveedor] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedor]    Script Date: 31/10/2024 04:43:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedor](
	[idProveedor] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[NIF] [varchar](15) NOT NULL,
	[direccion] [varchar](100) NULL,
	[activo] [bit] NULL,
	[telefono] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[idProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PuestoUsuario]    Script Date: 31/10/2024 04:43:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PuestoUsuario](
	[idPuesto] [int] IDENTITY(1,1) NOT NULL,
	[nombrePuesto] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idPuesto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RolUsuario]    Script Date: 31/10/2024 04:43:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolUsuario](
	[idRol] [int] IDENTITY(1,1) NOT NULL,
	[nombreRol] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sucursal]    Script Date: 31/10/2024 04:43:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sucursal](
	[idSucursal] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[direccion] [varchar](100) NULL,
	[telefono] [varchar](20) NULL,
	[activo] [bit] NULL,
	[idGerente] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idSucursal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 31/10/2024 04:43:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[usuario] [varchar](50) NOT NULL,
	[password] [varchar](250) NOT NULL,
	[email] [varchar](250) NOT NULL,
	[activo] [bit] NULL,
	[fechaCreacion] [date] NULL,
	[idRol] [int] NOT NULL,
	[idPuesto] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CategoriaProducto] ON 

INSERT [dbo].[CategoriaProducto] ([idCategoria], [nombreCategoria]) VALUES (1, N'Electrónica')
INSERT [dbo].[CategoriaProducto] ([idCategoria], [nombreCategoria]) VALUES (2, N'Ropa')
INSERT [dbo].[CategoriaProducto] ([idCategoria], [nombreCategoria]) VALUES (3, N'Juguetes')
INSERT [dbo].[CategoriaProducto] ([idCategoria], [nombreCategoria]) VALUES (4, N'Hogar')
INSERT [dbo].[CategoriaProducto] ([idCategoria], [nombreCategoria]) VALUES (5, N'Belleza')
INSERT [dbo].[CategoriaProducto] ([idCategoria], [nombreCategoria]) VALUES (6, N'Deportes')
INSERT [dbo].[CategoriaProducto] ([idCategoria], [nombreCategoria]) VALUES (7, N'Libros')
INSERT [dbo].[CategoriaProducto] ([idCategoria], [nombreCategoria]) VALUES (8, N'Muebles')
INSERT [dbo].[CategoriaProducto] ([idCategoria], [nombreCategoria]) VALUES (9, N'Automotriz')
INSERT [dbo].[CategoriaProducto] ([idCategoria], [nombreCategoria]) VALUES (10, N'Alimentos')
SET IDENTITY_INSERT [dbo].[CategoriaProducto] OFF
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 

INSERT [dbo].[Cliente] ([idCliente], [nombre], [apellidos], [DNI], [direccion], [fechaNacimiento], [activo], [correoElectronico]) VALUES (1, N'Juan', N'Perez', N'1234567890', N'Calle 1', CAST(N'1990-01-01' AS Date), 1, N'juan.perez@mail.com')
INSERT [dbo].[Cliente] ([idCliente], [nombre], [apellidos], [DNI], [direccion], [fechaNacimiento], [activo], [correoElectronico]) VALUES (2, N'Maria', N'Garcia', N'0987654321', N'Calle 2', CAST(N'1992-02-02' AS Date), 1, N'maria.garcia@mail.com')
INSERT [dbo].[Cliente] ([idCliente], [nombre], [apellidos], [DNI], [direccion], [fechaNacimiento], [activo], [correoElectronico]) VALUES (3, N'Luis', N'Martinez', N'1122334455', N'Calle 3', CAST(N'1985-03-03' AS Date), 1, N'luis.martinez@mail.com')
INSERT [dbo].[Cliente] ([idCliente], [nombre], [apellidos], [DNI], [direccion], [fechaNacimiento], [activo], [correoElectronico]) VALUES (4, N'Ana', N'Lopez', N'2233445566', N'Calle 4', CAST(N'1988-04-04' AS Date), 1, N'ana.lopez@mail.com')
INSERT [dbo].[Cliente] ([idCliente], [nombre], [apellidos], [DNI], [direccion], [fechaNacimiento], [activo], [correoElectronico]) VALUES (5, N'Carlos', N'Sanchez', N'3344556677', N'Calle 5', CAST(N'1995-05-05' AS Date), 1, N'carlos.sanchez@mail.com')
INSERT [dbo].[Cliente] ([idCliente], [nombre], [apellidos], [DNI], [direccion], [fechaNacimiento], [activo], [correoElectronico]) VALUES (6, N'Elena', N'Torres', N'4455667788', N'Calle 6', CAST(N'1991-06-06' AS Date), 1, N'elena.torres@mail.com')
INSERT [dbo].[Cliente] ([idCliente], [nombre], [apellidos], [DNI], [direccion], [fechaNacimiento], [activo], [correoElectronico]) VALUES (7, N'Jorge', N'Ramos', N'5566778899', N'Calle 7', CAST(N'1987-07-07' AS Date), 1, N'jorge.ramos@mail.com')
INSERT [dbo].[Cliente] ([idCliente], [nombre], [apellidos], [DNI], [direccion], [fechaNacimiento], [activo], [correoElectronico]) VALUES (8, N'Sofia', N'Mendoza', N'6677889900', N'Calle 8', CAST(N'1994-08-08' AS Date), 1, N'sofia.mendoza@mail.com')
INSERT [dbo].[Cliente] ([idCliente], [nombre], [apellidos], [DNI], [direccion], [fechaNacimiento], [activo], [correoElectronico]) VALUES (9, N'Miguel', N'Castro', N'7788990011', N'Calle 9', CAST(N'1989-09-09' AS Date), 1, N'miguel.castro@mail.com')
INSERT [dbo].[Cliente] ([idCliente], [nombre], [apellidos], [DNI], [direccion], [fechaNacimiento], [activo], [correoElectronico]) VALUES (10, N'Laura', N'Ortiz', N'8899001122', N'Calle 10', CAST(N'1993-10-10' AS Date), 1, N'laura.ortiz@mail.com')
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[DetalleOrden] ON 

INSERT [dbo].[DetalleOrden] ([idDetalle], [precioCompra], [cantidad], [idOrden], [idProducto]) VALUES (3, CAST(1050.20 AS Decimal(10, 2)), 4, 2, 1)
INSERT [dbo].[DetalleOrden] ([idDetalle], [precioCompra], [cantidad], [idOrden], [idProducto]) VALUES (4, CAST(250.30 AS Decimal(10, 2)), 6, 2, 2)
INSERT [dbo].[DetalleOrden] ([idDetalle], [precioCompra], [cantidad], [idOrden], [idProducto]) VALUES (5, CAST(700.15 AS Decimal(10, 2)), 3, 2, 3)
INSERT [dbo].[DetalleOrden] ([idDetalle], [precioCompra], [cantidad], [idOrden], [idProducto]) VALUES (6, CAST(1230.50 AS Decimal(10, 2)), 2, 2, 4)
INSERT [dbo].[DetalleOrden] ([idDetalle], [precioCompra], [cantidad], [idOrden], [idProducto]) VALUES (7, CAST(450.99 AS Decimal(10, 2)), 8, 2, 6)
INSERT [dbo].[DetalleOrden] ([idDetalle], [precioCompra], [cantidad], [idOrden], [idProducto]) VALUES (8, CAST(1500.75 AS Decimal(10, 2)), 1, 3, 4)
INSERT [dbo].[DetalleOrden] ([idDetalle], [precioCompra], [cantidad], [idOrden], [idProducto]) VALUES (9, CAST(890.25 AS Decimal(10, 2)), 2, 4, 1)
INSERT [dbo].[DetalleOrden] ([idDetalle], [precioCompra], [cantidad], [idOrden], [idProducto]) VALUES (10, CAST(210.50 AS Decimal(10, 2)), 3, 4, 3)
INSERT [dbo].[DetalleOrden] ([idDetalle], [precioCompra], [cantidad], [idOrden], [idProducto]) VALUES (11, CAST(700.10 AS Decimal(10, 2)), 5, 4, 7)
INSERT [dbo].[DetalleOrden] ([idDetalle], [precioCompra], [cantidad], [idOrden], [idProducto]) VALUES (12, CAST(300.80 AS Decimal(10, 2)), 4, 4, 9)
INSERT [dbo].[DetalleOrden] ([idDetalle], [precioCompra], [cantidad], [idOrden], [idProducto]) VALUES (13, CAST(765.20 AS Decimal(10, 2)), 7, 5, 5)
INSERT [dbo].[DetalleOrden] ([idDetalle], [precioCompra], [cantidad], [idOrden], [idProducto]) VALUES (14, CAST(450.40 AS Decimal(10, 2)), 1, 5, 8)
INSERT [dbo].[DetalleOrden] ([idDetalle], [precioCompra], [cantidad], [idOrden], [idProducto]) VALUES (15, CAST(345.60 AS Decimal(10, 2)), 9, 6, 1)
INSERT [dbo].[DetalleOrden] ([idDetalle], [precioCompra], [cantidad], [idOrden], [idProducto]) VALUES (16, CAST(105.25 AS Decimal(10, 2)), 4, 6, 2)
INSERT [dbo].[DetalleOrden] ([idDetalle], [precioCompra], [cantidad], [idOrden], [idProducto]) VALUES (17, CAST(985.75 AS Decimal(10, 2)), 3, 6, 4)
INSERT [dbo].[DetalleOrden] ([idDetalle], [precioCompra], [cantidad], [idOrden], [idProducto]) VALUES (18, CAST(1290.60 AS Decimal(10, 2)), 6, 6, 5)
INSERT [dbo].[DetalleOrden] ([idDetalle], [precioCompra], [cantidad], [idOrden], [idProducto]) VALUES (19, CAST(455.99 AS Decimal(10, 2)), 7, 6, 8)
INSERT [dbo].[DetalleOrden] ([idDetalle], [precioCompra], [cantidad], [idOrden], [idProducto]) VALUES (20, CAST(1050.20 AS Decimal(10, 2)), 8, 6, 10)
INSERT [dbo].[DetalleOrden] ([idDetalle], [precioCompra], [cantidad], [idOrden], [idProducto]) VALUES (21, CAST(475.50 AS Decimal(10, 2)), 10, 7, 2)
INSERT [dbo].[DetalleOrden] ([idDetalle], [precioCompra], [cantidad], [idOrden], [idProducto]) VALUES (22, CAST(1250.10 AS Decimal(10, 2)), 5, 7, 6)
INSERT [dbo].[DetalleOrden] ([idDetalle], [precioCompra], [cantidad], [idOrden], [idProducto]) VALUES (23, CAST(555.75 AS Decimal(10, 2)), 3, 7, 9)
INSERT [dbo].[DetalleOrden] ([idDetalle], [precioCompra], [cantidad], [idOrden], [idProducto]) VALUES (24, CAST(700.80 AS Decimal(10, 2)), 6, 8, 1)
INSERT [dbo].[DetalleOrden] ([idDetalle], [precioCompra], [cantidad], [idOrden], [idProducto]) VALUES (25, CAST(645.10 AS Decimal(10, 2)), 8, 8, 2)
INSERT [dbo].[DetalleOrden] ([idDetalle], [precioCompra], [cantidad], [idOrden], [idProducto]) VALUES (26, CAST(500.25 AS Decimal(10, 2)), 2, 8, 5)
INSERT [dbo].[DetalleOrden] ([idDetalle], [precioCompra], [cantidad], [idOrden], [idProducto]) VALUES (27, CAST(320.30 AS Decimal(10, 2)), 1, 8, 7)
INSERT [dbo].[DetalleOrden] ([idDetalle], [precioCompra], [cantidad], [idOrden], [idProducto]) VALUES (28, CAST(1550.45 AS Decimal(10, 2)), 11, 9, 3)
INSERT [dbo].[DetalleOrden] ([idDetalle], [precioCompra], [cantidad], [idOrden], [idProducto]) VALUES (29, CAST(720.20 AS Decimal(10, 2)), 9, 9, 10)
INSERT [dbo].[DetalleOrden] ([idDetalle], [precioCompra], [cantidad], [idOrden], [idProducto]) VALUES (30, CAST(1425.35 AS Decimal(10, 2)), 14, 10, 8)
INSERT [dbo].[DetalleOrden] ([idDetalle], [precioCompra], [cantidad], [idOrden], [idProducto]) VALUES (31, CAST(230.40 AS Decimal(10, 2)), 12, 11, 1)
INSERT [dbo].[DetalleOrden] ([idDetalle], [precioCompra], [cantidad], [idOrden], [idProducto]) VALUES (32, CAST(500.50 AS Decimal(10, 2)), 5, 11, 2)
INSERT [dbo].[DetalleOrden] ([idDetalle], [precioCompra], [cantidad], [idOrden], [idProducto]) VALUES (33, CAST(860.75 AS Decimal(10, 2)), 7, 11, 3)
INSERT [dbo].[DetalleOrden] ([idDetalle], [precioCompra], [cantidad], [idOrden], [idProducto]) VALUES (34, CAST(915.10 AS Decimal(10, 2)), 2, 11, 6)
INSERT [dbo].[DetalleOrden] ([idDetalle], [precioCompra], [cantidad], [idOrden], [idProducto]) VALUES (35, CAST(730.60 AS Decimal(10, 2)), 3, 11, 10)
SET IDENTITY_INSERT [dbo].[DetalleOrden] OFF
GO
SET IDENTITY_INSERT [dbo].[EstadoEnvio] ON 

INSERT [dbo].[EstadoEnvio] ([idEstado], [nombreEstado]) VALUES (1, N'Pendiente')
INSERT [dbo].[EstadoEnvio] ([idEstado], [nombreEstado]) VALUES (2, N'Enviado')
INSERT [dbo].[EstadoEnvio] ([idEstado], [nombreEstado]) VALUES (3, N'Entregado')
SET IDENTITY_INSERT [dbo].[EstadoEnvio] OFF
GO
SET IDENTITY_INSERT [dbo].[Orden] ON 

INSERT [dbo].[Orden] ([idOrden], [fecha], [idEstado], [total], [idCliente], [idSucursal]) VALUES (2, CAST(N'2024-01-01' AS Date), 1, CAST(1000.00 AS Decimal(10, 2)), 1, 3)
INSERT [dbo].[Orden] ([idOrden], [fecha], [idEstado], [total], [idCliente], [idSucursal]) VALUES (3, CAST(N'2024-02-01' AS Date), 2, CAST(1500.00 AS Decimal(10, 2)), 2, 3)
INSERT [dbo].[Orden] ([idOrden], [fecha], [idEstado], [total], [idCliente], [idSucursal]) VALUES (4, CAST(N'2024-03-01' AS Date), 3, CAST(2000.00 AS Decimal(10, 2)), 3, 3)
INSERT [dbo].[Orden] ([idOrden], [fecha], [idEstado], [total], [idCliente], [idSucursal]) VALUES (5, CAST(N'2024-04-01' AS Date), 3, CAST(2500.00 AS Decimal(10, 2)), 4, 2)
INSERT [dbo].[Orden] ([idOrden], [fecha], [idEstado], [total], [idCliente], [idSucursal]) VALUES (6, CAST(N'2024-05-01' AS Date), 1, CAST(3000.00 AS Decimal(10, 2)), 5, 2)
INSERT [dbo].[Orden] ([idOrden], [fecha], [idEstado], [total], [idCliente], [idSucursal]) VALUES (7, CAST(N'2024-06-01' AS Date), 1, CAST(3500.00 AS Decimal(10, 2)), 6, 2)
INSERT [dbo].[Orden] ([idOrden], [fecha], [idEstado], [total], [idCliente], [idSucursal]) VALUES (8, CAST(N'2024-07-01' AS Date), 1, CAST(4000.00 AS Decimal(10, 2)), 7, 2)
INSERT [dbo].[Orden] ([idOrden], [fecha], [idEstado], [total], [idCliente], [idSucursal]) VALUES (9, CAST(N'2024-08-01' AS Date), 2, CAST(4500.00 AS Decimal(10, 2)), 8, 3)
INSERT [dbo].[Orden] ([idOrden], [fecha], [idEstado], [total], [idCliente], [idSucursal]) VALUES (10, CAST(N'2024-09-01' AS Date), 3, CAST(5000.00 AS Decimal(10, 2)), 9, 2)
INSERT [dbo].[Orden] ([idOrden], [fecha], [idEstado], [total], [idCliente], [idSucursal]) VALUES (11, CAST(N'2024-10-01' AS Date), 1, CAST(5500.00 AS Decimal(10, 2)), 10, 3)
SET IDENTITY_INSERT [dbo].[Orden] OFF
GO
SET IDENTITY_INSERT [dbo].[Producto] ON 

INSERT [dbo].[Producto] ([idProducto], [nombre], [codigo], [descripcion], [precioUnitario], [activo], [idCategoria], [idProveedor]) VALUES (1, N'Producto1', N'P001', N'Descripcion del Producto1', CAST(100.50 AS Decimal(10, 2)), 1, 1, 1)
INSERT [dbo].[Producto] ([idProducto], [nombre], [codigo], [descripcion], [precioUnitario], [activo], [idCategoria], [idProveedor]) VALUES (2, N'Producto2', N'P002', N'Descripcion del Producto2', CAST(200.75 AS Decimal(10, 2)), 1, 2, 2)
INSERT [dbo].[Producto] ([idProducto], [nombre], [codigo], [descripcion], [precioUnitario], [activo], [idCategoria], [idProveedor]) VALUES (3, N'Producto3', N'P003', N'Descripcion del Producto3', CAST(150.00 AS Decimal(10, 2)), 1, 3, 3)
INSERT [dbo].[Producto] ([idProducto], [nombre], [codigo], [descripcion], [precioUnitario], [activo], [idCategoria], [idProveedor]) VALUES (4, N'Producto4', N'P004', N'Descripcion del Producto4', CAST(300.90 AS Decimal(10, 2)), 1, 4, 4)
INSERT [dbo].[Producto] ([idProducto], [nombre], [codigo], [descripcion], [precioUnitario], [activo], [idCategoria], [idProveedor]) VALUES (5, N'Producto5', N'P005', N'Descripcion del Producto5', CAST(250.25 AS Decimal(10, 2)), 1, 5, 5)
INSERT [dbo].[Producto] ([idProducto], [nombre], [codigo], [descripcion], [precioUnitario], [activo], [idCategoria], [idProveedor]) VALUES (6, N'Producto6', N'P006', N'Descripcion del Producto6', CAST(175.35 AS Decimal(10, 2)), 1, 6, 6)
INSERT [dbo].[Producto] ([idProducto], [nombre], [codigo], [descripcion], [precioUnitario], [activo], [idCategoria], [idProveedor]) VALUES (7, N'Producto7', N'P007', N'Descripcion del Producto7', CAST(225.80 AS Decimal(10, 2)), 1, 7, 7)
INSERT [dbo].[Producto] ([idProducto], [nombre], [codigo], [descripcion], [precioUnitario], [activo], [idCategoria], [idProveedor]) VALUES (8, N'Producto8', N'P008', N'Descripcion del Producto8', CAST(180.40 AS Decimal(10, 2)), 1, 8, 8)
INSERT [dbo].[Producto] ([idProducto], [nombre], [codigo], [descripcion], [precioUnitario], [activo], [idCategoria], [idProveedor]) VALUES (9, N'Producto9', N'P009', N'Descripcion del Producto9', CAST(275.60 AS Decimal(10, 2)), 1, 9, 9)
INSERT [dbo].[Producto] ([idProducto], [nombre], [codigo], [descripcion], [precioUnitario], [activo], [idCategoria], [idProveedor]) VALUES (10, N'Producto10', N'P010', N'Descripcion del Producto10', CAST(350.00 AS Decimal(10, 2)), 1, 10, 10)
SET IDENTITY_INSERT [dbo].[Producto] OFF
GO
SET IDENTITY_INSERT [dbo].[Proveedor] ON 

INSERT [dbo].[Proveedor] ([idProveedor], [nombre], [NIF], [direccion], [activo], [telefono]) VALUES (1, N'Proveedor1', N'A12345678', N'Direccion 1', 1, N'123456789')
INSERT [dbo].[Proveedor] ([idProveedor], [nombre], [NIF], [direccion], [activo], [telefono]) VALUES (2, N'Proveedor2', N'B23456789', N'Direccion 2', 1, N'234567890')
INSERT [dbo].[Proveedor] ([idProveedor], [nombre], [NIF], [direccion], [activo], [telefono]) VALUES (3, N'Proveedor3', N'C34567890', N'Direccion 3', 1, N'345678901')
INSERT [dbo].[Proveedor] ([idProveedor], [nombre], [NIF], [direccion], [activo], [telefono]) VALUES (4, N'Proveedor4', N'D45678901', N'Direccion 4', 1, N'456789012')
INSERT [dbo].[Proveedor] ([idProveedor], [nombre], [NIF], [direccion], [activo], [telefono]) VALUES (5, N'Proveedor5', N'E56789012', N'Direccion 5', 1, N'567890123')
INSERT [dbo].[Proveedor] ([idProveedor], [nombre], [NIF], [direccion], [activo], [telefono]) VALUES (6, N'Proveedor6', N'F67890123', N'Direccion 6', 1, N'678901234')
INSERT [dbo].[Proveedor] ([idProveedor], [nombre], [NIF], [direccion], [activo], [telefono]) VALUES (7, N'Proveedor7', N'G78901234', N'Direccion 7', 1, N'789012345')
INSERT [dbo].[Proveedor] ([idProveedor], [nombre], [NIF], [direccion], [activo], [telefono]) VALUES (8, N'Proveedor8', N'H89012345', N'Direccion 8', 1, N'890123456')
INSERT [dbo].[Proveedor] ([idProveedor], [nombre], [NIF], [direccion], [activo], [telefono]) VALUES (9, N'Proveedor9', N'I90123456', N'Direccion 9', 1, N'901234567')
INSERT [dbo].[Proveedor] ([idProveedor], [nombre], [NIF], [direccion], [activo], [telefono]) VALUES (10, N'Proveedor10', N'J01234567', N'Direccion 10', 1, N'012345678')
SET IDENTITY_INSERT [dbo].[Proveedor] OFF
GO
SET IDENTITY_INSERT [dbo].[PuestoUsuario] ON 

INSERT [dbo].[PuestoUsuario] ([idPuesto], [nombrePuesto]) VALUES (1, N'Administrador')
INSERT [dbo].[PuestoUsuario] ([idPuesto], [nombrePuesto]) VALUES (2, N'Gerente')
INSERT [dbo].[PuestoUsuario] ([idPuesto], [nombrePuesto]) VALUES (3, N'Vendedor')
SET IDENTITY_INSERT [dbo].[PuestoUsuario] OFF
GO
SET IDENTITY_INSERT [dbo].[RolUsuario] ON 

INSERT [dbo].[RolUsuario] ([idRol], [nombreRol]) VALUES (1, N'Administrador')
INSERT [dbo].[RolUsuario] ([idRol], [nombreRol]) VALUES (2, N'Usuario')
SET IDENTITY_INSERT [dbo].[RolUsuario] OFF
GO
SET IDENTITY_INSERT [dbo].[Sucursal] ON 

INSERT [dbo].[Sucursal] ([idSucursal], [nombre], [direccion], [telefono], [activo], [idGerente]) VALUES (2, N'Sucursal1', N'Direccion Sucursal 1', N'123456789', 1, 3)
INSERT [dbo].[Sucursal] ([idSucursal], [nombre], [direccion], [telefono], [activo], [idGerente]) VALUES (3, N'Sucursal2', N'Direccion Sucursal 2', N'234567890', 1, 8)
SET IDENTITY_INSERT [dbo].[Sucursal] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([idUsuario], [usuario], [password], [email], [activo], [fechaCreacion], [idRol], [idPuesto]) VALUES (2, N'user1', N'3173554c424ee410eef1a3942d8995545c8ad033bdf07f70b9f701702218a6b2', N'email1@email.com', 1, CAST(N'2024-10-31' AS Date), 1, 1)
INSERT [dbo].[Usuario] ([idUsuario], [usuario], [password], [email], [activo], [fechaCreacion], [idRol], [idPuesto]) VALUES (3, N'user2', N'3173554c424ee410eef1a3942d8995545c8ad033bdf07f70b9f701702218a6b2', N'email2@email.com', 1, CAST(N'2024-10-31' AS Date), 2, 2)
INSERT [dbo].[Usuario] ([idUsuario], [usuario], [password], [email], [activo], [fechaCreacion], [idRol], [idPuesto]) VALUES (4, N'user3', N'3173554c424ee410eef1a3942d8995545c8ad033bdf07f70b9f701702218a6b2', N'email3@email.com', 1, CAST(N'2024-10-31' AS Date), 2, 3)
INSERT [dbo].[Usuario] ([idUsuario], [usuario], [password], [email], [activo], [fechaCreacion], [idRol], [idPuesto]) VALUES (5, N'user4', N'3173554c424ee410eef1a3942d8995545c8ad033bdf07f70b9f701702218a6b2', N'email4@email.com', 1, CAST(N'2024-10-31' AS Date), 2, 3)
INSERT [dbo].[Usuario] ([idUsuario], [usuario], [password], [email], [activo], [fechaCreacion], [idRol], [idPuesto]) VALUES (6, N'user5', N'3173554c424ee410eef1a3942d8995545c8ad033bdf07f70b9f701702218a6b2', N'email5@email.com', 1, CAST(N'2024-10-31' AS Date), 2, 3)
INSERT [dbo].[Usuario] ([idUsuario], [usuario], [password], [email], [activo], [fechaCreacion], [idRol], [idPuesto]) VALUES (7, N'user6', N'3173554c424ee410eef1a3942d8995545c8ad033bdf07f70b9f701702218a6b2', N'email6@email.com', 1, CAST(N'2024-10-31' AS Date), 1, 1)
INSERT [dbo].[Usuario] ([idUsuario], [usuario], [password], [email], [activo], [fechaCreacion], [idRol], [idPuesto]) VALUES (8, N'Luis Carbajal Herna', N'3173554c424ee410eef1a3942d8995545c8ad033bdf07f70b9f701702218a6b2', N'l@lmd33.com', 1, CAST(N'2024-10-31' AS Date), 1, 1)
INSERT [dbo].[Usuario] ([idUsuario], [usuario], [password], [email], [activo], [fechaCreacion], [idRol], [idPuesto]) VALUES (9, N'user8', N'3173554c424ee410eef1a3942d8995545c8ad033bdf07f70b9f701702218a6b2', N'email8@email.com', 1, CAST(N'2024-10-31' AS Date), 2, 3)
INSERT [dbo].[Usuario] ([idUsuario], [usuario], [password], [email], [activo], [fechaCreacion], [idRol], [idPuesto]) VALUES (10, N'user9', N'3173554c424ee410eef1a3942d8995545c8ad033bdf07f70b9f701702218a6b2', N'email9@email.com', 1, CAST(N'2024-10-31' AS Date), 2, 3)
INSERT [dbo].[Usuario] ([idUsuario], [usuario], [password], [email], [activo], [fechaCreacion], [idRol], [idPuesto]) VALUES (11, N'user10', N'3173554c424ee410eef1a3942d8995545c8ad033bdf07f70b9f701702218a6b2', N'email10@email.com', 1, CAST(N'2024-10-31' AS Date), 2, 3)
INSERT [dbo].[Usuario] ([idUsuario], [usuario], [password], [email], [activo], [fechaCreacion], [idRol], [idPuesto]) VALUES (12, N'Luis Carbajal', N'3173554c424ee410eef1a3942d8995545c8ad033bdf07f70b9f701702218a6b2', N'l@l.com', 1, CAST(N'2024-10-31' AS Date), 1, 1)
INSERT [dbo].[Usuario] ([idUsuario], [usuario], [password], [email], [activo], [fechaCreacion], [idRol], [idPuesto]) VALUES (16, N'Luis Carbajal H', N'3173554c424ee410eef1a3942d8995545c8ad033bdf07f70b9f701702218a6b2', N'l@lm.com', 1, CAST(N'2024-10-31' AS Date), 1, 1)
INSERT [dbo].[Usuario] ([idUsuario], [usuario], [password], [email], [activo], [fechaCreacion], [idRol], [idPuesto]) VALUES (17, N'Luis Carbajal He', N'3173554c424ee410eef1a3942d8995545c8ad033bdf07f70b9f701702218a6b2', N'l@lm2.com', 1, CAST(N'2024-10-31' AS Date), 1, 1)
INSERT [dbo].[Usuario] ([idUsuario], [usuario], [password], [email], [activo], [fechaCreacion], [idRol], [idPuesto]) VALUES (18, N'Luis Carbajal Her', N'3173554c424ee410eef1a3942d8995545c8ad033bdf07f70b9f701702218a6b2', N'l@lm3.com', 1, CAST(N'2024-10-31' AS Date), 1, 1)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Cliente__ED1E3B6E7F6DD186]    Script Date: 31/10/2024 04:43:02 p. m. ******/
ALTER TABLE [dbo].[Cliente] ADD UNIQUE NONCLUSTERED 
(
	[correoElectronico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Producto__40F9A206BED3B4CB]    Script Date: 31/10/2024 04:43:02 p. m. ******/
ALTER TABLE [dbo].[Producto] ADD UNIQUE NONCLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Proveedo__C7DEC3303888DE5D]    Script Date: 31/10/2024 04:43:02 p. m. ******/
ALTER TABLE [dbo].[Proveedor] ADD UNIQUE NONCLUSTERED 
(
	[NIF] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Usuario__9AFF8FC652E8327A]    Script Date: 31/10/2024 04:43:02 p. m. ******/
ALTER TABLE [dbo].[Usuario] ADD UNIQUE NONCLUSTERED 
(
	[usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DetalleOrden]  WITH CHECK ADD FOREIGN KEY([idOrden])
REFERENCES [dbo].[Orden] ([idOrden])
GO
ALTER TABLE [dbo].[DetalleOrden]  WITH CHECK ADD FOREIGN KEY([idProducto])
REFERENCES [dbo].[Producto] ([idProducto])
GO
ALTER TABLE [dbo].[Orden]  WITH CHECK ADD FOREIGN KEY([idCliente])
REFERENCES [dbo].[Cliente] ([idCliente])
GO
ALTER TABLE [dbo].[Orden]  WITH CHECK ADD FOREIGN KEY([idEstado])
REFERENCES [dbo].[EstadoEnvio] ([idEstado])
GO
ALTER TABLE [dbo].[Orden]  WITH CHECK ADD FOREIGN KEY([idSucursal])
REFERENCES [dbo].[Sucursal] ([idSucursal])
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD FOREIGN KEY([idCategoria])
REFERENCES [dbo].[CategoriaProducto] ([idCategoria])
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD FOREIGN KEY([idProveedor])
REFERENCES [dbo].[Proveedor] ([idProveedor])
GO
ALTER TABLE [dbo].[Sucursal]  WITH CHECK ADD FOREIGN KEY([idGerente])
REFERENCES [dbo].[Usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD FOREIGN KEY([idPuesto])
REFERENCES [dbo].[PuestoUsuario] ([idPuesto])
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD FOREIGN KEY([idRol])
REFERENCES [dbo].[RolUsuario] ([idRol])
GO
