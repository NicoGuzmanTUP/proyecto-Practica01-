use Facturacion

CREATE PROCEDURE SP_GUARDAR_ARTICULO
@nombre varchar(20),
@precio money
AS
BEGIN 
	insert into Articulos(nombre, precio_unitario) 
	values (@nombre, @precio)	
END

--
EXEC SP_GUARDAR_ARTICULO @nombre = 'desdeSql', @precio = 100.00;
--

CREATE PROCEDURE SP_NUEVA_FACTURA
@fecha datetime,
@forma_pago int,
@cliente
AS
BEGIN 
	insert into Facturas(fecha, forma_pago, cliente) 
	values (@fecha, @forma_pago, @cliente)	
END
--
EXEC SP_GUARDAR_ARTICULO @nombre = 'desdeSql', @precio = 100.00;


CREATE PROCEDURE SP_OBTENER_FORMAS_PAGOS
AS
BEGIN 
	SELECT * FROM formas_pagos
END
--
EXEC SP_OBTENER_FORMAS_PAGOS
--

