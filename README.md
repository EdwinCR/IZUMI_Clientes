# IZUMI_Clientes — Gestor de clientes IZUMI

Proyecto para la gestión de clientes IZUMI. El repositorio incluye:
- Scripts de **Base de Datos** (carpeta `BD`)
- **Backend** (API/Servicio)
- **Frontend** en **ASP.NET MVC**

> Nota: Los nombres exactos de soluciones/proyectos, puertos y cadenas de conexión pueden variar según tu configuración local. Este README describe el flujo general de ejecución.

---

## Requisitos

### Software
- **Git**
- **SQL Server** (o el motor definido por el proyecto) + una herramienta para ejecutar scripts (por ejemplo: SSMS)
- **.NET SDK / Visual Studio** (según el tipo de proyecto)
  - Recomendado: **Visual Studio 2022** con workloads de **ASP.NET y desarrollo web**
- (Opcional) **IIS Express** (si se usa desde Visual Studio)

### Accesos / Configuración previa
- Permisos para crear base de datos, tablas, usuarios, etc.
- Tener disponibles credenciales/servidor de base de datos (local o remoto).

---

## 1) Clonar el repositorio

```bash
git clone https://github.com/EdwinCR/IZUMI_Clientes.git
cd IZUMI_Clientes
```

---

## 2) Preparar la Base de Datos (carpeta `BD`)

1. Ubica la carpeta **`BD`** dentro del repositorio.
2. **Sigue el orden indicado en esa carpeta** (por ejemplo: `Paso 1`, `Paso 2`, `01_`, `02_`, etc.).
3. Ejecuta los scripts en tu servidor SQL:
   - Creación de la base de datos
   - Creación de tablas/objetos
   - Inserts iniciales (si aplica)
   - Stored procedures / vistas / funciones (si aplica)
   - Usuarios/permisos (si aplica)

> Importante: Ejecuta los scripts **en el orden** indicado por la carpeta `BD`. Si hay un README o un archivo de pasos dentro de `BD`, úsalo como fuente principal.

---

## 3) Configurar el Backend (API / Servicio)

1. Abre la solución/proyecto del backend en Visual Studio (o con `dotnet`).
2. Configura la **cadena de conexión** a la BD creada en el paso anterior.
   - Busca el archivo de configuración típico:
     - `appsettings.json` / `appsettings.Development.json` (si es .NET Core/5+/6+)
     - `Web.config` (si es .NET Framework)
3. Verifica valores comunes:
   - `Server` / `Data Source`
   - `Database` / `Initial Catalog`
   - `User Id` / `Password` o `Trusted_Connection=True`
4. Ejecuta el backend:
   - Desde Visual Studio: seleccionar el proyecto de API/Servicio como **Startup Project** y presionar **Run (F5)**.
   - O por CLI (si aplica): `dotnet run` dentro del proyecto del backend.

### Validación rápida
- Comprueba que el backend inicia sin errores.
- Identifica la URL base (por ejemplo `https://localhost:xxxx/` o `http://localhost:xxxx/`).
- Si existe Swagger, intenta abrir `/swagger`.

---

## 4) Configurar y ejecutar el Frontend (MVC)

1. Abre el proyecto **MVC** (frontend) en Visual Studio.
2. Configura el endpoint del backend (si el MVC consume la API):
   - Puede estar en `appsettings.json`, `Web.config`, variables de entorno o una clase de configuración.
3. Establece el proyecto MVC como **Startup Project**.
4. Ejecuta el frontend (F5).

### Validación rápida
- Abre el sitio MVC en el navegador.
- Prueba un flujo básico (login/listados/alta de cliente) para confirmar comunicación con la API y la BD.

---

## Orden recomendado de ejecución (resumen)

1. **Clonar repo**
2. **Ejecutar scripts de BD** (carpeta `BD`, siguiendo el orden)
3. **Levantar Backend (API/Servicio)**
4. **Levantar Frontend (MVC)**

---

## Troubleshooting (común)

- **Error de conexión a BD**: revisa cadena de conexión, nombre de servidor, usuario/clave, puerto, firewall.
- **Scripts fallan por orden**: ejecuta exactamente en el orden definido en `BD`.
- **CORS / llamadas a API**: si el frontend consume API en otro puerto, revisa configuración CORS en backend.
- **Puertos ocupados**: cambia el puerto de ejecución en launchSettings/IIS Express.

---

## Notas

Si compartes:
- el nombre del proyecto/solución del backend y del MVC,
- el tipo exacto (.NET Framework vs .NET 6/7/8),
- y dónde está la cadena de conexión,

puedo ajustar este README para que quede 100% alineado a la estructura real del repositorio.
