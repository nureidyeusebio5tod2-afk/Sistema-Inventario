CREATE DATABASE Inventario;
GO

USE Inventario;
GO

-- TABLA ROLES
CREATE TABLE Roles(
Id_Rol INT PRIMARY KEY IDENTITY(1,1),
Nombre_Rol VARCHAR(50) NOT NULL
);

-- TABLA USUARIOS
CREATE TABLE Usuarios(
Id_Usuario INT PRIMARY KEY IDENTITY(1,1),
Nombre VARCHAR(100) NOT NULL,
Username VARCHAR(50) NOT NULL,
Password VARCHAR(100) NOT NULL,
Id_Rol INT,
Fecha_Creación DATE DEFAULT GETDATE(),
Estado BIT DEFAULT 1,

FOREIGN KEY (Id_Rol) REFERENCES Roles(Id_Rol)
);

-- TABLA CATEGORIAS
CREATE TABLE Categorias (
Id_Categoria INT PRIMARY KEY IDENTITY(1,1),
Nombre VARCHAR(100) NOT NULL,
Estado BIT DEFAULT 1
);

-- TABLA PROVEEDORES (ANTES DE PRODUCTOS)
CREATE TABLE Proveedores (
Id_Proveedor INT PRIMARY KEY IDENTITY(1,1),
Nombre VARCHAR(100),
Telefono VARCHAR(20),
Correo VARCHAR(100),
Direccion VARCHAR(200),
Estado BIT DEFAULT 1
);

-- TABLA PRODUCTOS
CREATE TABLE Productos(
Id_Producto INT PRIMARY KEY IDENTITY(1,1),
Nombre VARCHAR(100) NOT NULL,
Precio DECIMAL(10,2),
Stock INT,
Id_Categoria INT,
Id_Proveedor INT,
Fecha_Ingreso DATE DEFAULT GETDATE(),
Modificado_Por INT,
Estado BIT DEFAULT 1,

FOREIGN KEY (Id_Categoria) REFERENCES Categorias(Id_Categoria),
FOREIGN KEY (Id_Proveedor) REFERENCES Proveedores(Id_Proveedor),
FOREIGN KEY (Modificado_Por) REFERENCES Usuarios(Id_Usuario)
);

-- TABLA MOVIMIENTOS
CREATE TABLE Movimientos (
Id_Movimiento INT PRIMARY KEY IDENTITY(1,1),
Tipo_Movimiento VARCHAR(20),
Fecha DATE DEFAULT GETDATE(),
Id_Usuario INT,
FOREIGN KEY (Id_Usuario) REFERENCES Usuarios(Id_Usuario)
);

-- TABLA DETALLE MOVIMIENTOS
CREATE TABLE Detalle_Movimientos (
Id_Detalle INT PRIMARY KEY IDENTITY(1,1),
Id_Movimiento INT,
Id_Producto INT,
Cantidad INT,
FOREIGN KEY (Id_Movimiento) REFERENCES Movimientos(Id_Movimiento),
FOREIGN KEY (Id_Producto) REFERENCES Productos(Id_Producto)
);

CREATE TABLE Cliente (
    Id_cliente INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,
    Direccion VARCHAR(150) NULL,
    Telefono VARCHAR(15) NULL,
    Correo VARCHAR(100) NULL,
    Estado_cliente VARCHAR(20) NOT NULL DEFAULT 'Activo'
);
GO

-- INSERT ROLES
INSERT INTO Roles (Nombre_Rol) VALUES
('Administrador'),
('Almacen'),
('Consulta');

-- INSERT USUARIOS
INSERT INTO Usuarios (Nombre, Username, Password, Id_Rol, Estado) VALUES
('Administrador Sistema','admin','54321',1,1),
('Empleado Almacen','almacen','54123',2,1),
('Usuario Consulta','consulta','051620',3,1);

-- INSERT CATEGORIAS
INSERT INTO Categorias (Nombre) VALUES
('Granos'),
('Bebidas'),
('Lacteos'),
('Dulces'),
('Snacks'),
('Condimentos'),
('Panaderia'),
('Conservas'),
('Cereales'),
('Otros');

-- INSERT PROVEEDORES
INSERT INTO Proveedores (Nombre, Telefono, Correo, Direccion, Estado) VALUES
('Distribuidora Central','809-555-1001','central@gmail.com','Santo Domingo',1),
('Alimentos del Caribe','809-555-1002','caribe@gmail.com','Santiago',1),
('Bebidas Nacionales','809-555-1003','bebidas@gmail.com','La Vega',1),
('Suplidores Unidos','809-555-1004','suplidores@gmail.com','San Cristobal',1),
('Importadora Lopez','809-555-1005','lopez@gmail.com','Santo Domingo Este',1),
('Comercial Martinez','809-555-1006','martinez@gmail.com','Puerto Plata',1),
('Distribuidora Garcia','809-555-1007','garcia@gmail.com','San Pedro',1),
('Productos del Norte','809-555-1008','norte@gmail.com','Moca',1),
('Mayorista Rodriguez','809-555-1009','rodriguez@gmail.com','Bonao',1),
('Comercial Santana','809-555-1010','santana@gmail.com','Higüey',1);

-- INSERT PRODUCTOS
INSERT INTO Productos (Nombre, Precio, Stock, Id_Categoria, Id_Proveedor, Modificado_Por, Estado) VALUES
('Arroz',20,50,1,1,1,1),
('Azucar',22,40,1,1,1,1),
('Leche',50,30,3,2,1,1),
('Cafe',100,15,1,3,1,1),
('Galletas',30,25,4,4,1,1),
('Refresco',40,35,2,3,1,1),
('Aceite',130,20,6,5,1,1),
('Harina',30,40,7,6,1,1),
('Chocolate',70,18,4,7,1,1),
('Sal',10,60,6,8,1,1);
GO

INSERT INTO Cliente (Nombre, Direccion, Telefono, Correo, Estado_cliente) VALUES
('Juan Pérez', 'Santo Domingo', '809-555-1111', 'juan@gmail.com', 'Activo'),
('María López', 'San Pedro', '809-555-2222', 'maria@gmail.com', 'Activo'),
('Carlos Méndez', 'La Romana', '809-555-3333', 'carlos@gmail.com', 'Activo'),
('Ana Rodríguez', 'Higüey', '809-555-4444', 'ana@gmail.com', 'Activo'),
('Pedro Martínez', 'Boca Chica', '809-555-5555', 'pedro@gmail.com', 'Activo');
GO

-- PROCEDIMIENTO PARA REGISTRAR USUARIO
CREATE PROCEDURE Sp_Registrar_Usuario
    @Nombre VARCHAR(100),
    @Username VARCHAR(50),
    @Password VARCHAR(100),
    @Id_Rol INT,
    @Estado BIT
AS
BEGIN
    INSERT INTO Usuarios (Nombre, Username, Password, Id_Rol, Estado)
    VALUES (@Nombre, @Username, @Password, @Id_Rol, @Estado);
END
GO


-- PROCEDIMIENTO PARA MOSTRAR USUARIOS
CREATE PROCEDURE Sp_Mostrar_Usuarios
AS
BEGIN
    SELECT U.Id_Usuario, U.Nombre, U.Username, R.Nombre_Rol, U.Estado
    FROM Usuarios U
    INNER JOIN Roles R ON U.Id_Rol = R.Id_Rol;
END
GO


-- PROCEDIMIENTO PARA INSERTAR PRODUCTOS
CREATE PROCEDURE Sp_Insertar_Producto
    @Nombre VARCHAR(100),
    @Precio DECIMAL(10,2),
    @Stock INT,
    @Id_Categoria INT,
    @Id_Proveedor INT,
    @Modificado_Por INT,
    @Estado BIT
AS
BEGIN
    INSERT INTO Productos(Nombre, Precio, Stock, Id_Categoria, Id_Proveedor, Fecha_Ingreso, Modificado_Por, Estado)
    VALUES(@Nombre,@Precio,@Stock,@Id_Categoria,@Id_Proveedor,GETDATE(),@Modificado_Por,@Estado);
END
GO


-- PROCEDIMIENTO PARA MOSTRAR PRODUCTOS
CREATE PROCEDURE Sp_Mostrar_Productos
AS
BEGIN
    SELECT 
        P.Id_Producto,
        P.Nombre,
        P.Precio,
        P.Stock,
        C.Nombre AS Categoria,
        PR.Nombre AS Proveedor
    FROM Productos P
    INNER JOIN Categorias C ON P.Id_Categoria = C.Id_Categoria
    INNER JOIN Proveedores PR ON P.Id_Proveedor = PR.Id_Proveedor;
END
GO


-- PROCEDIMIENTO PARA INSERTAR MOVIMIENTO
CREATE PROCEDURE Sp_Insertar_Movimiento
    @Tipo_Movimiento VARCHAR(20),
    @Id_Usuario INT
AS
BEGIN
    INSERT INTO Movimientos(Tipo_Movimiento, Fecha, Id_Usuario)
    VALUES(@Tipo_Movimiento, GETDATE(), @Id_Usuario);
END
GO


-- PROCEDIMIENTO PARA INSERTAR DETALLE DE MOVIMIENTO
CREATE PROCEDURE Sp_Insertar_Detalle_Movimiento
    @Id_Movimiento INT,
    @Id_Producto INT,
    @Cantidad INT
AS
BEGIN
    INSERT INTO Detalle_Movimientos(Id_Movimiento, Id_Producto, Cantidad)
    VALUES(@Id_Movimiento,@Id_Producto,@Cantidad);
END
GO


-- PROCEDIMIENTO PARA VER PRODUCTOS CON STOCK BAJO
CREATE PROCEDURE Sp_Stock_Bajo
AS
BEGIN
    SELECT Nombre, Stock
    FROM Productos
    WHERE Stock < 10;
END
GO

-- PROCEDIMIENTOS DE CATEGORIAS
CREATE PROCEDURE sp_InsertarCategoria
@Nombre VARCHAR(100)
AS
INSERT INTO Categorias (Nombre)
VALUES (@Nombre);


GO
CREATE PROCEDURE sp_ListarCategorias
AS
SELECT * 
FROM Categorias
WHERE Estado = 1;
GO


CREATE PROCEDURE sp_ActualizarCategoria
@Id_Categoria INT,
@Nombre VARCHAR(100)
AS
UPDATE Categorias
SET Nombre=@Nombre
WHERE Id_Categoria=@Id_Categoria;


GO
CREATE PROCEDURE sp_EliminarCategoria
@Id_Categoria INT
AS
BEGIN
    UPDATE Categorias
    SET Estado = 0
    WHERE Id_Categoria = @Id_Categoria
END
GO

CREATE PROCEDURE SP_ListarClientes
AS
BEGIN
    SELECT * FROM Cliente;
END;
GO

CREATE PROCEDURE SP_InsertarCliente
    @Nombre VARCHAR(100),
    @Direccion VARCHAR(150),
    @Telefono VARCHAR(15),
    @Correo VARCHAR(100)
AS
BEGIN
    INSERT INTO Cliente (Nombre, Direccion, Telefono, Correo)
    VALUES (@Nombre, @Direccion, @Telefono, @Correo);
END;
GO

CREATE PROCEDURE SP_ActualizarCliente
    @Id_cliente INT,
    @Nombre VARCHAR(100),
    @Direccion VARCHAR(150),
    @Telefono VARCHAR(15),
    @Correo VARCHAR(100),
    @Estado_cliente VARCHAR(20)
AS
BEGIN
    UPDATE Cliente
    SET Nombre = @Nombre,
        Direccion = @Direccion,
        Telefono = @Telefono,
        Correo = @Correo,
        Estado_cliente = @Estado_cliente
    WHERE Id_cliente = @Id_cliente;
END;
GO

CREATE PROCEDURE SP_EliminarCliente
    @Id_cliente INT
AS
BEGIN
    UPDATE Cliente
    SET Estado_cliente = 'Inactivo'
    WHERE Id_cliente = @Id_cliente;
END;
GO

CREATE PROCEDURE Sp_Mostrar_Proveedores
AS
BEGIN
    SELECT 
        Id_Proveedor,
        Nombre
    FROM Proveedores
    WHERE Estado = 1
END;
GO 

CREATE PROCEDURE Sp_Login
@Username VARCHAR(50),
@Password VARCHAR(100)
AS
BEGIN
    SELECT 
        Id_Usuario,
        Nombre,
        Username,
        Id_Rol
    FROM Usuarios
    WHERE Username = @Username 
    AND Password = @Password
    AND Estado = 1
END
GO

CREATE PROCEDURE sp_InsertarProducto
    @Nombre VARCHAR(100),
    @Precio DECIMAL(10,2),
    @Stock INT,
    @Id_Categoria INT,
    @Id_Proveedor INT
AS
BEGIN
    INSERT INTO Productos
    (Nombre, Precio, Stock, Id_Categoria, Id_Proveedor, Estado)
    VALUES
    (@Nombre, @Precio, @Stock, @Id_Categoria, @Id_Proveedor, 1)
END
GO

CREATE PROCEDURE sp_EliminarProducto
    @Id_Producto INT
AS
BEGIN
    DELETE FROM Productos
    WHERE Id_Producto = @Id_Producto
END
GO

CREATE PROCEDURE sp_ActualizarProducto
    @Id_Producto INT,
    @Nombre VARCHAR(100),
    @Precio DECIMAL(10,2),
    @Stock INT,
    @Id_Categoria INT,
    @Id_Proveedor INT
AS
BEGIN
    UPDATE Productos
    SET 
        Nombre = @Nombre,
        Precio = @Precio,
        Stock = @Stock,
        Id_Categoria = @Id_Categoria,
        Id_Proveedor = @Id_Proveedor
    WHERE Id_Producto = @Id_Producto
END
GO

ALTER PROCEDURE Sp_Mostrar_Productos
AS
BEGIN
    SELECT 
        P.Id_Producto,
        P.Nombre,
        P.Precio,
        P.Stock,
        P.Id_Categoria,   -- 🔥 ESTO FALTABA
        P.Id_Proveedor,   -- 🔥 ESTO FALTABA
        C.Nombre AS Categoria,
        PR.Nombre AS Proveedor
    FROM Productos P
    INNER JOIN Categorias C ON P.Id_Categoria = C.Id_Categoria
    INNER JOIN Proveedores PR ON P.Id_Proveedor = PR.Id_Proveedor;
END