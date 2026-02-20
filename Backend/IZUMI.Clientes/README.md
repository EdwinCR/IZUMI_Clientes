# ?? IZUMI - Sistema de Gestión de Clientes

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-12.0-239120?logo=c-sharp)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![Entity Framework](https://img.shields.io/badge/Entity%20Framework-9.0-512BD4)](https://docs.microsoft.com/en-us/ef/)
[![Tests](https://img.shields.io/badge/Tests-29%20Passing-success)](https://xunit.net/)
[![License](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)

> Sistema empresarial de gestión de clientes desarrollado con arquitectura limpia y mejores prácticas de desarrollo.

---

## ?? Tabla de Contenidos

- [Descripción](#-descripción)
- [Características](#-características)
- [Arquitectura](#-arquitectura)
- [Tecnologías](#-tecnologías)
- [Requisitos Previos](#-requisitos-previos)
- [Instalación](#-instalación)
- [Configuración](#?-configuración)
- [Uso](#-uso)
- [Endpoints API](#-endpoints-api)
- [Pruebas](#-pruebas)
- [Estructura del Proyecto](#-estructura-del-proyecto)
- [Contribución](#-contribución)
- [Licencia](#-licencia)

---

## ?? Descripción

**IZUMI.Clientes** es una API RESTful robusta para la gestión integral de clientes, planes y tipos de documento. Diseñada siguiendo los principios de **Clean Architecture** y **Domain-Driven Design (DDD)**, garantiza escalabilidad, mantenibilidad y testabilidad.

### ?? Objetivo

Proporcionar un sistema eficiente y escalable para la administración de información de clientes, con soporte para paginación, validaciones de negocio y operaciones CRUD completas.

---

## ? Características

### ?? Funcionalidades Principales

- ? **Gestión Completa de Clientes** (CRUD)
  - Crear, leer, actualizar y eliminar (soft delete)
  - Validación de duplicados por documento
  - Búsqueda por ID

- ?? **Paginación Eficiente**
  - Paginación a nivel de base de datos
  - Optimización de rendimiento con `Skip` y `Take`
  - Metadata de paginación (total páginas, registros, etc.)

- ?? **Catálogos**
  - Gestión de Planes
  - Tipos de Documento
  - Relaciones entre entidades

- ??? **Validaciones de Negocio**
  - Validación de documentos únicos
  - Validación de existencia antes de operaciones
  - Manejo robusto de errores

- ?? **Búsquedas Avanzadas**
  - Por ID de cliente
  - Por tipo y número de documento
  - Lista completa con relaciones

### ?? Características Técnicas

- **Arquitectura Limpia** - Separación clara de responsabilidades
- **Inyección de Dependencias** - Desacoplamiento de componentes
- **AutoMapper** - Mapeo automático entre DTOs y Entidades
- **Entity Framework Core** - ORM moderno con SQL Server
- **Swagger/OpenAPI** - Documentación interactiva
- **Logging** - Registro de errores y operaciones
- **CORS** - Configurado para aplicaciones frontend

---

## ??? Arquitectura

El proyecto sigue los principios de **Clean Architecture** con separación en capas:

```
???????????????????????????????????????????????
?         IZUMI.Clientes.Api (Capa de         ?
?              Presentación)                   ?
?   - Controllers                              ?
?   - Middleware                               ?
?   - Swagger Configuration                    ?
???????????????????????????????????????????????
               ?
???????????????????????????????????????????????
?    IZUMI.Clientes.Application (Capa de      ?
?            Aplicación)                       ?
?   - Use Cases                                ?
?   - DTOs                                     ?
?   - Profiles (AutoMapper)                    ?
?   - Interfaces                               ?
???????????????????????????????????????????????
               ?
???????????????????????????????????????????????
?      IZUMI.Clientes.Domain (Capa de         ?
?              Dominio)                        ?
?   - Entities                                 ?
?   - Services                                 ?
?   - Repository Interfaces                    ?
?   - Business Logic                           ?
???????????????????????????????????????????????
               ?
???????????????????????????????????????????????
?   IZUMI.Clientes.Infrastructure (Capa de    ?
?          Infraestructura)                    ?
?   - DbContext                                ?
?   - Repositories                             ?
?   - Data Models                              ?
?   - Migrations                               ?
???????????????????????????????????????????????
```

### Principios Aplicados

- ? **Separation of Concerns** - Cada capa tiene una responsabilidad específica
- ? **Dependency Inversion** - Las dependencias apuntan hacia el dominio
- ? **Single Responsibility** - Cada clase tiene una única razón de cambio
- ? **Interface Segregation** - Interfaces específicas y cohesivas
- ? **Repository Pattern** - Abstracción de acceso a datos
- ? **Unit of Work Pattern** - Gestión de transacciones

---

## ??? Tecnologías

### Backend

| Tecnología | Versión | Propósito |
|------------|---------|-----------|
| **.NET** | 8.0 | Framework principal |
| **C#** | 12.0 | Lenguaje de programación |
| **Entity Framework Core** | 9.0.0 | ORM y acceso a datos |
| **SQL Server** | 2019+ | Base de datos |
| **AutoMapper** | 16.0.0 | Mapeo objeto-objeto |
| **Swashbuckle** | 6.6.2 | Documentación API |

### Testing

| Tecnología | Versión | Propósito |
|------------|---------|-----------|
| **xUnit** | 2.9.2 | Framework de pruebas |
| **Moq** | 4.20.72 | Mocking framework |
| **FluentAssertions** | 8.8.0 | Assertions expresivas |

---

## ?? Requisitos Previos

Antes de comenzar, asegúrate de tener instalado:

- ? [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) o superior
- ? [SQL Server 2019+](https://www.microsoft.com/sql-server/sql-server-downloads) o SQL Server Express
- ? [Visual Studio 2022](https://visualstudio.microsoft.com/) o [VS Code](https://code.visualstudio.com/)
- ? [Git](https://git-scm.com/)

### Opcional

- [SQL Server Management Studio (SSMS)](https://docs.microsoft.com/sql/ssms/download-sql-server-management-studio-ssms)
- [Postman](https://www.postman.com/) para pruebas de API

---

## ?? Instalación

### 1. Clonar el Repositorio

```bash
git clone https://github.com/tu-usuario/IZUMI.Clientes.git
cd IZUMI.Clientes
```

### 2. Restaurar Paquetes

```bash
dotnet restore
```

### 3. Configurar Base de Datos

Edita el archivo `appsettings.json` en el proyecto `IZUMI.Clientes.Api`:

```json
{
  "ConnectionStrings": {
    "SqlserverConnection": "Server=localhost;Database=IZUMIClientes;User Id=TU_USUARIO;Password=TU_PASSWORD;TrustServerCertificate=True;"
  }
}
```

### 4. Crear Base de Datos

```bash
cd IZUMI.Clientes.Infrastructure
dotnet ef database update
```

### 5. Compilar Solución

```bash
cd ..
dotnet build
```

### 6. Ejecutar la Aplicación

```bash
cd IZUMI.Clientes.Api
dotnet run
```

La API estará disponible en:
- **HTTP**: `http://localhost:5283`
- **HTTPS**: `https://localhost:7283`
- **Swagger**: `https://localhost:7283/swagger`

---

## ?? Configuración

### Cadena de Conexión

Modifica `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "SqlserverConnection": "Server=TU_SERVIDOR;Database=IZUMIClientes;User Id=TU_USUARIO;Password=TU_PASSWORD;TrustServerCertificate=True;"
  }
}
```

### CORS

Por defecto, CORS está configurado para aceptar solicitudes desde `http://localhost:5283`. 

Para modificar los orígenes permitidos, edita `Program.cs`:

```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy.WithOrigins("http://tu-frontend.com") 
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});
```

### Logging

Los niveles de logging se configuran en `appsettings.json`:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}
```

---

## ?? Uso

### Usando Swagger UI

1. Navega a `https://localhost:7283/swagger`
2. Explora los endpoints disponibles
3. Prueba las operaciones directamente desde el navegador

### Usando cURL

#### Obtener Lista de Clientes (Paginado)

```bash
curl -X GET "https://localhost:7283/api/IZUMI/Cliente/ObtenerListaClientesPaginado?pageNumber=1&pageSize=10"
```

#### Crear Cliente

```bash
curl -X POST "https://localhost:7283/api/IZUMI/Cliente/CrearCliente" \
  -H "Content-Type: application/json" \
  -d '{
    "tipoDocumentoId": 1,
    "numeroDocumento": "123456789",
    "fechaNacimiento": "1990-01-01",
    "primerNombre": "Juan",
    "primerApellido": "Pérez",
    "email": "juan.perez@email.com",
    "planId": 1
  }'
```

#### Obtener Cliente por ID

```bash
curl -X GET "https://localhost:7283/api/IZUMI/Cliente/ObtenerClienteXId/{id}"
```

---

## ?? Endpoints API

### ?? Clientes

| Método | Endpoint | Descripción |
|--------|----------|-------------|
| `GET` | `/api/IZUMI/Cliente/ObtenerListaClientes` | Obtiene todos los clientes activos |
| `GET` | `/api/IZUMI/Cliente/ObtenerListaClientesPaginado?pageNumber=1&pageSize=10` | Obtiene clientes paginados |
| `GET` | `/api/IZUMI/Cliente/ObtenerClienteXId/{id}` | Obtiene un cliente por ID |
| `POST` | `/api/IZUMI/Cliente/CrearCliente` | Crea un nuevo cliente |
| `POST` | `/api/IZUMI/Cliente/ActualizarCliente/{id}` | Actualiza un cliente existente |
| `DELETE` | `/api/IZUMI/Cliente/EliminarCliente/{id}` | Elimina (soft delete) un cliente |

### ?? Planes

| Método | Endpoint | Descripción |
|--------|----------|-------------|
| `GET` | `/api/IZUMI/Plan/ObtenerListaPlanes` | Obtiene todos los planes |

### ?? Tipos de Documento

| Método | Endpoint | Descripción |
|--------|----------|-------------|
| `GET` | `/api/IZUMI/TipoDocumento/ObtenerListaTipoDocumentos` | Obtiene todos los tipos de documento |

### Ejemplos de Respuesta

#### Respuesta Exitosa (Paginada)

```json
{
  "data": [
    {
      "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "tipoDocumentoId": 1,
      "tipoDocumento": "CC",
      "numeroDocumento": "123456789",
      "nombreCompleto": "Juan Pérez",
      "email": "juan.perez@email.com",
      "celular": "3001234567",
      "planId": 1,
      "planNombre": "Plan Básico"
    }
  ],
  "totalRecords": 150,
  "pageNumber": 1,
  "pageSize": 10,
  "totalPages": 15,
  "succeeded": true,
  "message": null
}
```

#### Respuesta de Error

```json
{
  "data": null,
  "succeeded": false,
  "message": "Se presentó un error en el procesamiento de la solicitud."
}
```

---

## ?? Pruebas

El proyecto incluye **29 pruebas unitarias** con cobertura completa.

### Ejecutar Todas las Pruebas

```bash
dotnet test
```

### Ejecutar con Cobertura Detallada

```bash
dotnet test --logger "console;verbosity=detailed"
```

### Estadísticas de Pruebas

```
? ClienteUseCaseTests: 16 pruebas
? PlanUseCaseTests: 2 pruebas
? TipoDocumentoUseCaseTests: 2 pruebas
? ClienteServiceTests: 7 pruebas
? PlanServiceTests: 1 prueba
? TipoDocumentoServiceTests: 1 prueba
??????????????????????????????????????
Total: 29/29 pruebas pasando ?
```

### Cobertura de Pruebas

- ? **Use Cases** - Lógica de negocio
- ? **Services** - Capa de dominio
- ? **Validaciones** - Reglas de negocio
- ? **Manejo de Excepciones** - Casos de error
- ? **Paginación** - Funcionalidad avanzada

---

## ?? Estructura del Proyecto

```
IZUMI.Clientes/
?
??? ?? IZUMI.Clientes.Api/                    # Capa de Presentación
?   ??? Controllers/                          # Controladores REST
?   ?   ??? ClienteController.cs
?   ?   ??? PlanController.cs
?   ?   ??? TipoDocumentoController.cs
?   ??? Program.cs                            # Configuración de la aplicación
?   ??? appsettings.json                      # Configuración
?
??? ?? IZUMI.Clientes.Application/            # Capa de Aplicación
?   ??? DTO/                                  # Data Transfer Objects
?   ?   ??? ClienteDTO.cs
?   ?   ??? ClienteRequestDTO.cs
?   ?   ??? ClienteUpdateRequestDTO.cs
?   ?   ??? PagedResponseDTO.cs
?   ?   ??? ResponseDTO.cs
?   ?   ??? PlanDTO.cs
?   ?   ??? TipoDocumentoDTO.cs
?   ??? Profiles/                             # AutoMapper Profiles
?   ?   ??? ApplicationProfile.cs
?   ??? UseCase/                              # Casos de Uso
?       ??? Interfaces/
?       ?   ??? IClienteUseCase.cs
?       ?   ??? IPlanUseCase.cs
?       ?   ??? ITipoDocumentoUseCase.cs
?       ??? ClienteUseCase.cs
?       ??? PlanUseCase.cs
?       ??? TipoDocumentoUseCase.cs
?
??? ?? IZUMI.Clientes.Domain/                 # Capa de Dominio
?   ??? Entities/                             # Entidades de Dominio
?   ?   ??? ClienteEntity.cs
?   ?   ??? PlanEntity.cs
?   ?   ??? TipoDocumentoEntity.cs
?   ?   ??? PagedResultEntity.cs
?   ??? IRepositories/                        # Interfaces de Repositorios
?   ?   ??? IClienteRepository.cs
?   ?   ??? IPlanRepository.cs
?   ?   ??? ITipoDocumentoRepository.cs
?   ??? Services/                             # Servicios de Dominio
?       ??? Interfaces/
?       ?   ??? IClienteService.cs
?       ?   ??? IPlanService.cs
?       ?   ??? ITipoDocumentoService.cs
?       ??? ClienteService.cs
?       ??? PlanService.cs
?       ??? TipoDocumentoService.cs
?
??? ?? IZUMI.Clientes.Infrastructure/         # Capa de Infraestructura
?   ??? Contexts/                             # DbContext
?   ?   ??? Context.cs
?   ??? Models/                               # Modelos de Base de Datos
?   ?   ??? ClienteModel.cs
?   ?   ??? PlanModel.cs
?   ?   ??? TipoDocumentoModel.cs
?   ??? Profiles/                             # AutoMapper Profiles
?   ?   ??? InfrastructureProfile.cs
?   ??? Repositories/                         # Implementación de Repositorios
?       ??? ClienteRepository.cs
?       ??? PlanRepository.cs
?       ??? TipoDocumentoRepository.cs
?
??? ?? IZUMI.Clientes.Tests/                  # Proyecto de Pruebas
    ??? UseCase/                              # Pruebas de Casos de Uso
    ?   ??? ClienteUseCaseTests.cs
    ?   ??? PlanUseCaseTests.cs
    ?   ??? TipoDocumentoUseCaseTests.cs
    ??? Services/                             # Pruebas de Servicios
        ??? ClienteServiceTests.cs
        ??? PlanServiceTests.cs
        ??? TipoDocumentoServiceTests.cs
```

---

## ?? Tecnologías y Patrones

### Patrones de Diseño Implementados

- ? **Repository Pattern** - Abstracción de acceso a datos
- ? **Dependency Injection** - Inversión de control
- ? **Unit of Work** - Gestión de transacciones
- ? **DTO Pattern** - Transferencia de datos
- ? **Service Layer** - Lógica de negocio
- ? **Clean Architecture** - Separación de responsabilidades

### Principios SOLID

- ? **S**ingle Responsibility Principle
- ? **O**pen/Closed Principle
- ? **L**iskov Substitution Principle
- ? **I**nterface Segregation Principle
- ? **D**ependency Inversion Principle

---

## ?? Contribución

¡Las contribuciones son bienvenidas! Por favor, sigue estos pasos:

1. **Fork** el proyecto
2. Crea una **rama** para tu feature (`git checkout -b feature/AmazingFeature`)
3. **Commit** tus cambios (`git commit -m 'Add some AmazingFeature'`)
4. **Push** a la rama (`git push origin feature/AmazingFeature`)
5. Abre un **Pull Request**

### Guía de Estilo

- Sigue las convenciones de C# y .NET
- Escribe pruebas unitarias para nuevas funcionalidades
- Documenta el código con comentarios XML
- Mantén la cobertura de pruebas arriba del 80%

---

## ?? Licencia

Este proyecto está bajo la Licencia MIT - ver el archivo [LICENSE](LICENSE) para más detalles.

---

## ?? Autores

- **Edwin** - *Desarrollo Inicial* - [GitHub](https://github.com/edwin)

---

## ?? Agradecimientos

- Equipo de desarrollo de .NET
- Comunidad de Entity Framework Core
- Colaboradores del proyecto

---

## ?? Contacto

- **Email**: contacto@izumi.com
- **Website**: https://www.izumi.com
- **LinkedIn**: [IZUMI](https://linkedin.com/company/izumi)

---

## ?? Estado del Proyecto

```
Estado: ? Activo
Versión: 1.0.0
Última actualización: 2024
```

---

## ?? Roadmap

### Versión 1.1 (Próxima)
- [ ] Implementar autenticación JWT
- [ ] Agregar caché con Redis
- [ ] Implementar rate limiting
- [ ] Agregar auditoría de cambios

### Versión 2.0 (Futuro)
- [ ] Migrar a microservicios
- [ ] Implementar Event Sourcing
- [ ] Agregar GraphQL
- [ ] Containerización con Docker

---

<div align="center">

**Hecho con ?? usando .NET 8**

[? Volver arriba](#-izumi---sistema-de-gestión-de-clientes)

</div>
