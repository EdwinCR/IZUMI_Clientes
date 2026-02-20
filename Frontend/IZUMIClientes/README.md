# IZUMI Clientes

Sistema de gestión de clientes desarrollado con ASP.NET Core MVC que consume una API REST para realizar operaciones CRUD sobre clientes y sus planes asociados.

## ?? Descripción

IZUMI Clientes es una aplicación web que permite gestionar información de clientes, incluyendo sus datos personales, documentos de identificación y planes asociados. La aplicación está construida siguiendo el patrón MVC y consume servicios de una API externa para todas las operaciones de datos.

## ?? Tecnologías

- **.NET 8.0** - Framework principal
- **ASP.NET Core MVC** - Patrón arquitectónico
- **Razor Pages** - Motor de vistas
- **Bootstrap 5** - Framework CSS para interfaz de usuario
- **Newtonsoft.Json** - Serialización/deserialización JSON
- **C# 12.0** - Lenguaje de programación

## ?? Estructura del Proyecto

```
IZUMIClientes/
??? Controllers/
?   ??? ClienteController.cs          # Controlador principal de clientes
??? Models/
?   ??? ClienteViewModel.cs           # Modelo de vista de cliente
?   ??? ClienteRequestViewModel.cs    # Modelo para crear cliente
?   ??? ClienteUpdateRequestViewModel.cs # Modelo para actualizar cliente
?   ??? ListaPaginadaViewModel.cs     # Modelo para paginación
?   ??? PagedResponseViewModel.cs     # Respuesta paginada de API
?   ??? ResponseViewModel.cs          # Respuesta genérica de API
?   ??? PlanViewModel.cs              # Modelo de planes
?   ??? TipoDocumentoViewModel.cs     # Modelo de tipos de documento
?   ??? ErrorViewModel.cs             # Modelo para errores
??? Services/
?   ??? Interfaces/
?   ?   ??? IClienteService.cs        # Interface de servicio de cliente
?   ?   ??? IPlanService.cs           # Interface de servicio de planes
?   ?   ??? ITipoDocumentoService.cs  # Interface de tipos de documento
?   ??? ClienteService.cs             # Implementación del servicio de cliente
?   ??? PlanService.cs                # Implementación del servicio de planes
?   ??? TipoDocumentoService.cs       # Implementación de tipos de documento
?   ??? CommonService.cs              # Servicio base con métodos HTTP
??? Views/
?   ??? Cliente/
?   ?   ??? Index.cshtml              # Vista principal con listado
?   ?   ??? Crear.cshtml              # Vista para crear cliente
?   ?   ??? Editar.cshtml             # Vista para editar cliente
?   ?   ??? _FormularioCliente.cshtml # Partial view del formulario
?   ??? Shared/
?       ??? _Layout.cshtml            # Layout principal
?       ??? _ValidationScriptsPartial.cshtml
?       ??? Error.cshtml
??? wwwroot/                          # Archivos estáticos (CSS, JS, imágenes)
??? appsettings.json                  # Configuración de la aplicación
??? Program.cs                        # Punto de entrada de la aplicación
```

## ?? Configuración

### Pre-requisitos

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) o superior
- Visual Studio 2022 o Visual Studio Code
- API REST IZUMI corriendo en el puerto configurado

### Configuración de la API

Edita el archivo `appsettings.json` para configurar la URL de la API:

```json
{
  "HostWebAPIs": {
    "IZUMIAPI": "http://localhost:5141/api/IZUMI/"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

**Importante:** Asegúrate de que la API REST esté corriendo en la URL especificada antes de ejecutar la aplicación.

## ?? Instalación

1. **Clonar el repositorio:**
   ```bash
   git clone <url-del-repositorio>
   cd IZUMIClientes
   ```

2. **Restaurar paquetes NuGet:**
   ```bash
   dotnet restore
   ```

3. **Configurar la conexión a la API:**
   - Edita `appsettings.json` con la URL correcta de tu API

4. **Compilar el proyecto:**
   ```bash
   dotnet build
   ```

5. **Ejecutar la aplicación:**
   ```bash
   dotnet run
   ```

6. **Abrir en el navegador:**
   ```
   https://localhost:5001
   ```

## ?? Uso

### Funcionalidades Principales

#### 1. Listar Clientes
- Vista principal con listado paginado de clientes
- Muestra información básica: nombre completo, documento, email y plan
- Paginación de 5 registros por página
- Acciones disponibles: Editar y Eliminar

#### 2. Crear Cliente
- Formulario completo para registrar nuevos clientes
- Campos obligatorios:
  - Tipo de documento
  - Número de documento
  - Primer nombre
  - Primer apellido
  - Fecha de nacimiento
  - Email
  - Dirección
  - Celular
  - Plan

#### 3. Editar Cliente
- Permite modificar la información de un cliente existente
- Precarga los datos actuales del cliente
- Validación de campos

#### 4. Eliminar Cliente
- Eliminación de clientes del sistema
- Confirmación antes de eliminar

### Validaciones

- **Número de documento:** Campo requerido y único
- **Email:** Formato de correo electrónico válido
- **Fecha de nacimiento:** Formato de fecha válido
- **Celular:** Solo números
- **Campos requeridos:** Tipo documento, primer nombre, primer apellido, plan

## ??? Arquitectura

### Patrón MVC
La aplicación sigue el patrón Modelo-Vista-Controlador:

- **Modelos (Models):** Clases que representan los datos y la lógica de negocio
- **Vistas (Views):** Páginas Razor que presentan la información al usuario
- **Controladores (Controllers):** Manejan las peticiones HTTP y coordinan la lógica

### Servicios
Los servicios actúan como capa de abstracción entre el controlador y la API:

- **ClienteService:** Maneja todas las operaciones relacionadas con clientes
- **PlanService:** Obtiene la lista de planes disponibles
- **TipoDocumentoService:** Obtiene los tipos de documento disponibles
- **CommonService:** Clase base con métodos HTTP reutilizables (GET, POST, PUT, DELETE)

### Inyección de Dependencias
Los servicios se registran en `Program.cs` usando el contenedor de DI de ASP.NET Core:

```csharp
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IPlanService, PlanService>();
builder.Services.AddScoped<ITipoDocumentoService, TipoDocumentoService>();
```

## ?? API Endpoints Consumidos

La aplicación consume los siguientes endpoints de la API:

### Clientes
- `GET /Cliente/ObtenerListaClientesPaginado/{pagina}/{tamanioPagina}` - Lista paginada
- `GET /Cliente/ObtenerClienteXId/{idCliente}` - Obtener cliente por ID
- `POST /Cliente/CrearCliente` - Crear nuevo cliente
- `PUT /Cliente/ActualizarCliente/{idCliente}` - Actualizar cliente
- `DELETE /Cliente/EliminarCliente/{idCliente}` - Eliminar cliente

### Planes
- `GET /Plan/ObtenerListaPlanes` - Lista de planes disponibles

### Tipos de Documento
- `GET /TipoDocumento/ObtenerListaTipoDocumentos` - Lista de tipos de documento

## ?? Interfaz de Usuario

- **Framework CSS:** Bootstrap 5
- **Diseño:** Responsivo y adaptable a diferentes dispositivos
- **Componentes:** Tablas, formularios, botones, alertas y paginación
- **Mensajes:** Sistema de notificaciones con TempData para éxito y errores

## ?? Manejo de Errores

- Validaciones del lado del cliente y servidor
- Mensajes de error personalizados
- Página de error genérica para excepciones no controladas
- Logging configurado para desarrollo y producción

## ?? Notas de Desarrollo

- El proyecto usa **implicit usings** de .NET 8
- Namespace del proyecto: `IZUMIClientes_`
- Target Framework: `net8.0`
- Nullable habilitado para mejor seguridad de tipos

## ?? Contribuir

Si deseas contribuir al proyecto:

1. Fork el repositorio
2. Crea una rama para tu feature (`git checkout -b feature/AmazingFeature`)
3. Commit tus cambios (`git commit -m 'Add some AmazingFeature'`)
4. Push a la rama (`git push origin feature/AmazingFeature`)
5. Abre un Pull Request

## ?? Licencia

Este proyecto es privado y confidencial.

## ?? Autor

Desarrollado para el sistema IZUMI

## ?? Soporte

Para soporte o consultas, contacta al equipo de desarrollo.

---

**Versión:** 1.0.0  
**Última actualización:** 2024
