-- =============================================
-- Crear Base de Datos
-- =============================================
CREATE DATABASE IZUMIClientes;
GO

USE IZUMIClientes;
GO

-- =============================================
-- Tabla: TipoDocumento
-- =============================================
CREATE TABLE TipoDocumento (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    Activo BIT NOT NULL DEFAULT 1
);
GO

-- =============================================
-- Tabla: Planes   (ANTES: Plan)
-- =============================================
CREATE TABLE Planes (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Descripcion VARCHAR(250) NULL,
    Precio DECIMAL(18,2) NOT NULL,
    Activo BIT NOT NULL DEFAULT 1
);
GO

-- =============================================
-- Tabla: Cliente
-- =============================================
CREATE TABLE Cliente (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),

    TipoDocumentoId INT NOT NULL,
    NumeroDocumento VARCHAR(20) NOT NULL,

    FechaNacimiento DATE NOT NULL,

    PrimerNombre VARCHAR(100) NOT NULL,
    SegundoNombre VARCHAR(100) NULL,

    PrimerApellido VARCHAR(100) NOT NULL,
    SegundoApellido VARCHAR(100) NULL,

    Direccion VARCHAR(200) NOT NULL,
    Celular VARCHAR(20) NOT NULL,
    Email VARCHAR(150) NOT NULL,

    PlanId INT NOT NULL,

    FechaCreacion DATETIME2 NOT NULL DEFAULT SYSDATETIME(),

    Activo BIT NOT NULL DEFAULT 1,

    CONSTRAINT FK_Cliente_TipoDocumento 
        FOREIGN KEY (TipoDocumentoId) 
        REFERENCES TipoDocumento(Id),

    CONSTRAINT FK_Cliente_Planes 
        FOREIGN KEY (PlanId) 
        REFERENCES Planes(Id)
);
GO

-- =============================================
-- Restricciones adicionales
-- =============================================

CREATE UNIQUE INDEX UX_Cliente_NumeroDocumento 
ON Cliente (NumeroDocumento);

CREATE UNIQUE INDEX UX_Cliente_Email 
ON Cliente (Email);

CREATE INDEX IX_Cliente_TipoDocumentoId 
ON Cliente (TipoDocumentoId);

CREATE INDEX IX_Cliente_PlanId 
ON Cliente (PlanId);
GO

-- =============================================
-- Datos iniciales (Seed)
-- =============================================

INSERT INTO TipoDocumento (Nombre)
VALUES 
('Cédula de Ciudadanía'),
('Cédula de Extranjería'),
('Pasaporte');

INSERT INTO Planes (Nombre, Descripcion, Precio)
VALUES
('Plan Básico', 'Cobertura médica básica', 120000),
('Plan Estándar', 'Cobertura médica intermedia', 250000),
('Plan Premium', 'Cobertura médica completa', 450000);

GO