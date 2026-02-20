# IZUMI_Clientes — Gestor de clientes IZUMI

Repositorio con:
- **BD**: scripts de base de datos en `BD/`
- **Backend (API)**: solución/proyecto en `Backend/IZUMI.Clientes/`
- **Frontend (MVC)**: aplicación web en `Frontend/IZUMIClientes/`

---

## Requisitos

- Git
- SQL Server (recomendado 2019+) + SSMS (u otra herramienta para ejecutar scripts)
- .NET SDK **8.0** (según los README de los proyectos)
- Visual Studio 2022 (recomendado)

---

## 1) Clonar el repositorio

```bash
git clone https://github.com/EdwinCR/IZUMI_Clientes.git
cd IZUMI_Clientes
```

---

## 2) Preparar Base de Datos (carpeta `BD/`)

1. Abre la carpeta `BD/`.
2. Ejecuta los scripts **en el orden indicado** dentro de la carpeta (por ejemplo: `01_...`, `02_...` o “Paso 1 / Paso 2”, etc.).
3. Verifica que la BD quede creada y con datos iniciales si aplica.

> Importante: el orden exacto depende de cómo estén organizados los scripts dentro de `BD/`.

---

## 3) Ejecutar Backend (API) — `Backend/IZUMI.Clientes/`

### 3.1 Configurar cadena de conexión
Configura la cadena de conexión en el proyecto de API (normalmente en `appsettings.json` del proyecto **`IZUMI.Clientes.Api`**), por ejemplo:

- `Backend/IZUMI.Clientes/IZUMI.Clientes.Api/appsettings.json` (ruta aproximada; puede variar dentro de la solución)

Ajusta los valores de servidor, base de datos y credenciales según tu entorno.

### 3.2 Restaurar, compilar y ejecutar (CLI)
Desde la raíz del repo:

```bash
cd Backend/IZUMI.Clientes
dotnet restore
dotnet build
```

Para correr la API, ejecuta el proyecto `IZUMI.Clientes.Api` (entra a la carpeta del proyecto API y corre):

```bash
# ejemplo (ajusta la ruta si tu .csproj está en otra subcarpeta)
cd IZUMI.Clientes.Api
dotnet run
```

Según el README del backend, al ejecutar la API normalmente queda disponible en algo similar a:
- HTTP: `http://localhost:5283`
- HTTPS: `https://localhost:7283`
- Swagger: `https://localhost:7283/swagger`

> Si tus puertos cambian, revisa `Properties/launchSettings.json` del proyecto API.

---

## 4) Ejecutar Frontend (MVC) — `Frontend/IZUMIClientes/`

### 4.1 Configurar URL del Backend (API)
En el frontend MVC, configura la URL de la API en:

- `Frontend/IZUMIClientes/appsettings.json`

Ejemplo (según README del frontend):

```json
{
  "HostWebAPIs": {
    "IZUMIAPI": "http://localhost:5141/api/IZUMI/"
  }
}
```

Cambia ese valor para que apunte a la URL real donde levantó tu backend.
Por ejemplo, si tu backend corre en `https://localhost:7283`, típicamente sería:

- `https://localhost:7283/api/IZUMI/`

### 4.2 Restaurar, compilar y ejecutar (CLI)

```bash
cd Frontend/IZUMIClientes
dotnet restore
dotnet build
dotnet run
```

Luego abre la URL que te muestre la consola (o la configurada en launchSettings).

---

## Orden recomendado de ejecución

1. Clonar repositorio
2. Ejecutar scripts de BD (`BD/`) en el orden indicado
3. Levantar Backend (API) (`Backend/IZUMI.Clientes/`)
4. Levantar Frontend (MVC) (`Frontend/IZUMIClientes/`)

---

## Referencias rápidas (README internos)

- Backend: `Backend/IZUMI.Clientes/README.md`
- Frontend: `Frontend/IZUMIClientes/README.md`
