CREATE DATABASE [Facturacion]
GO
USE [Facturacion]
GO
/****** Object:  Table [dbo].[Articulos]    Script Date: 10/9/2024 10:03:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articulos](
	[id_articulo] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[precio_unitario] [money] NOT NULL,
 CONSTRAINT [PK_Articulos] PRIMARY KEY CLUSTERED 
(
	[id_articulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Detalles_facturas]    Script Date: 10/9/2024 10:03:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalles_facturas](
	[cod_detalle_factura] [int] NOT NULL,
	[id_articulo] [int] NOT NULL,
	[nro_factura] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
 CONSTRAINT [PK_Detalles_facturas] PRIMARY KEY CLUSTERED 
(
	[cod_detalle_factura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Facturas]    Script Date: 10/9/2024 10:03:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Facturas](
	[nroFactura] [int] NOT NULL,
	[fecha] [datetime] NOT NULL,
	[cliente] [varchar](50) NOT NULL,
	[forma_pago] [int] NULL,
 CONSTRAINT [PK_Facturas] PRIMARY KEY CLUSTERED 
(
	[nroFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[formas_pagos]    Script Date: 10/9/2024 10:03:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[formas_pagos](
	[id_forma_pago] [int] NOT NULL,
	[nombre] [varchar](50) NULL,
 CONSTRAINT [PK_formas_pagos] PRIMARY KEY CLUSTERED 
(
	[id_forma_pago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Detalles_facturas]  WITH CHECK ADD  CONSTRAINT [FK_Detalles_facturas_Articulos] FOREIGN KEY([id_articulo])
REFERENCES [dbo].[Articulos] ([id_articulo])
GO
ALTER TABLE [dbo].[Detalles_facturas] CHECK CONSTRAINT [FK_Detalles_facturas_Articulos]
GO
ALTER TABLE [dbo].[Detalles_facturas]  WITH CHECK ADD  CONSTRAINT [FK_Detalles_facturas_Facturas] FOREIGN KEY([nro_factura])
REFERENCES [dbo].[Facturas] ([nroFactura])
GO
ALTER TABLE [dbo].[Detalles_facturas] CHECK CONSTRAINT [FK_Detalles_facturas_Facturas]
GO
ALTER TABLE [dbo].[Facturas]  WITH CHECK ADD  CONSTRAINT [FK_Facturas_formas_pagos] FOREIGN KEY([forma_pago])
REFERENCES [dbo].[formas_pagos] ([id_forma_pago])
GO
ALTER TABLE [dbo].[Facturas] CHECK CONSTRAINT [FK_Facturas_formas_pagos]
GO
/****** Object:  StoredProcedure [dbo].[SP_GUARDAR_ARTICULO]    Script Date: 10/9/2024 10:03:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GUARDAR_ARTICULO]
@nombre varchar(20),
@precio money
AS
BEGIN 
	insert into Articulos(nombre, precio_unitario) 
	values (@nombre, @precio)	
END
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_MESTRO]    Script Date: 10/9/2024 10:03:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INSERTAR_MESTRO]
	@fecha datetime,
	@pago int,
	@cliente varchar(50),
	@nro int output
AS
BEGIN
	INSERT INTO Facturas(nroFactura, fecha, forma_pago, cliente) 
	VALUES (@nro, @fecha, @pago, @cliente);
	SET @nro = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_NUEVO_DETALLE]    Script Date: 10/9/2024 10:03:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INSERTAR_NUEVO_DETALLE]
	@cod_detalle_factura int,
	@id_articulo int,
	@cantidad int,
	@nro_factura int
AS
BEGIN
	INSERT INTO Detalles_facturas(cod_detalle_factura, id_articulo, cantidad, nro_factura) 
	VALUES (@cod_detalle_factura, @id_articulo, @cantidad, @nro_factura);
END
GO
/****** Object:  StoredProcedure [dbo].[SP_OBTENER_CANT_ARTICULOS]    Script Date: 10/9/2024 10:03:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_OBTENER_CANT_ARTICULOS]
AS
BEGIN
SELECT SUM(cantidad) 'cantidad' FROM Detalles_facturas
END
GO
/****** Object:  StoredProcedure [dbo].[SP_OBTENER_FACTURAS]    Script Date: 10/9/2024 10:03:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_OBTENER_FACTURAS]
AS
BEGIN
SELECT * FROM facturas
END
GO
/****** Object:  StoredProcedure [dbo].[SP_OBTENER_FORMAS_PAGOS]    Script Date: 10/9/2024 10:03:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_OBTENER_FORMAS_PAGOS]
AS
BEGIN 
	SELECT * FROM formas_pagos
END
GO
