/*
--- Script para crear la base de datos pruebaTecnica ----

    CREATE DATABASE pruebaTecnica;
    GO
--------------------
 
---- Script para crear la tabla Usuarios ----------

    USE pruebaTecnica;
    GO

    CREATE TABLE Usuarios (
        Identificacion CHAR(20) PRIMARY KEY,
        Nombre VARCHAR(100) NOT NULL,
        FechaNacimiento DATETIME NOT NULL,
        Sexo CHAR(1) NOT NULL
    );

------------------------------------------------------

---- Procedimiento para insertar ---------------------

    CREATE PROCEDURE [dbo].[AgregarUsuario]
        @Identificacion CHAR(20),
        @Nombre VARCHAR(100),
        @FechaNacimiento DATETIME,
        @Sexo CHAR(1)
    AS
    BEGIN
        SET NOCOUNT ON;
    
        INSERT INTO Usuarios (Identificacion, Nombre, FechaNacimiento, Sexo)
        VALUES (@Identificacion, @Nombre, @FechaNacimiento, @Sexo);
    END

-------------------------------------------------------

---- Procedimiento para Actualizar -------------------

    CREATE PROCEDURE [dbo].[ModificarUsuario]
        @Identificacion CHAR(20),
        @Nombre VARCHAR(100),
        @FechaNacimiento DATETIME,
        @Sexo CHAR(1)
    AS
    BEGIN
        SET NOCOUNT ON;
    
        UPDATE Usuarios
        SET Nombre = @Nombre,
            FechaNacimiento = @FechaNacimiento,
            Sexo = @Sexo
        WHERE Identificacion = @Identificacion;
    END
-------------------------------------------------------

---- Procedimiento para Eliminar -------------------

    CREATE PROCEDURE [dbo].[EliminarUsuario]
        @Identificacion CHAR(20)
    AS
    BEGIN
        SET NOCOUNT ON;
    
        DELETE FROM Usuarios WHERE Identificacion = @Identificacion;
    END
-------------------------------------------------------


---- Procedimiento para Consultar un usuario -------------------

    CREATE PROCEDURE [dbo].[ObtenerUsuarioPorId]
        @Identificacion CHAR(20)
    AS
    BEGIN
        SET NOCOUNT ON;
    
        SELECT Identificacion, Nombre, FechaNacimiento, Sexo
        FROM Usuarios
        WHERE Identificacion = @Identificacion;
    END
-------------------------------------------------------

------ Procedimiento para consultar varios usuarios ------

      CREATE PROCEDURE [dbo].[ConsultarUsuarios]
    AS
    BEGIN
        SET NOCOUNT ON;
    
        SELECT Identificacion, Nombre, FechaNacimiento, Sexo
        FROM Usuarios;
    END

-------------------------------------------------------
 */