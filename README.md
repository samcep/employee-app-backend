
# Employee App

Este proyecto es una API para gestionar empleados, que permite realizar operaciones como crear, actualizar y obtener empleados, además de manejar la relación con los departamentos. Está construida con .NET 8 y utiliza Entity Framework Core para interactuar con la base de datos.
![image](https://github.com/user-attachments/assets/9f8b3fca-1cae-4c5f-b0d7-633d772781dd)

## Requisitos previos

Asegúrate de tener los siguientes programas instalados en tu máquina:

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio](https://visualstudio.microsoft.com/) con soporte para .NET y C#
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) o cualquier otra base de datos que configures

## Pasos para levantar el proyecto

### 1. Clonar el repositorio

Clona este repositorio en tu máquina local:

```bash
git clone https://github.com/samcep/employee-app-backend.git
```

### 2. Abrir el proyecto en Visual Studio

1. Abre Visual Studio.
2. Ve a **Archivo** > **Abrir** > **Proyecto/Solución y/o .csproj**.
3. Selecciona el archivo `employee-app.csproj` que se encuentra en la raíz del proyecto clonado .Asegúrate de abrirlo en visual studio.

### 3. Configurar la cadena de conexión

La cadena de conexión se encuentra en el archivo `appsettings.Development.json`. Asegúrate de configurar tu base de datos SQL Server o cualquier otra base de datos que estés usando.

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost; Database={{YOUR_DATABASE}}; Integrated Security=True; TrustServerCertificate=True"
  }
}
```

Asegúrate de que los valores en la cadena de conexión sean correctos:

- **Server**: Dirección del servidor de la base de datos (puede ser `localhost` o el nombre del servidor si estás usando SQL Server en otro equipo).
- **Database**: El nombre de la base de datos.
- **Trusted_Connection**: Si usas autenticación de Windows, asegúrate de que esté configurado en `True`. Si usas autenticación de SQL Server, necesitarás especificar el usuario y la contraseña en la cadena.

### 4. Restaurar los paquetes NuGet

Una vez que hayas abierto el proyecto en Visual Studio, restaura los paquetes NuGet necesarios para que el proyecto funcione:

1. Abre el **Administrador de Paquetes NuGet** desde **Herramientas** > **Administrador de Paquetes NuGet** > **Consola del Administrador de Paquetes**.
2. Ejecuta el siguiente comando en la consola para restaurar los paquetes NuGet:

```bash
dotnet restore
```
## Opción 2: Usar el Menú de Visual Studio
Haz clic derecho sobre la solución en el Explorador de Soluciones.
Selecciona la opción Restaurar paquetes NuGet.
Esto descargará e instalará todos los paquetes necesarios para el proyecto

### 5. Crear y aplicar migraciones

A continuación, necesitarás generar las migraciones para crear la estructura de la base de datos.

1. **Crear una migración**:

   Ejecuta el siguiente comando en la Consola del Administrador de Paquetes para crear una nueva migración:

   ```bash
   Add-Migration InitialCreate
   ```

   Esto generará los archivos necesarios para crear la base de datos y las tablas definidas en tu modelo.

2. **Actualizar la base de datos**:

   Después de crear la migración, ejecuta el siguiente comando para aplicar las migraciones y crear la base de datos:

   ```bash
   Update-Database
   ```

   Esto aplicará la migración y creará la base de datos con las tablas necesarias.

### 6. Ejecutar el proyecto

Para ejecutar el proyecto:

1. Asegúrate de que el proyecto está configurado correctamente en **Visual Studio**.
2. Presiona **Ctrl+F5** para ejecutar el proyecto sin depuración o **F5** para ejecutarlo con depuración.

### 9. Consideraciones adicionales

- Este proyecto utiliza **AutoMapper** para mapear objetos de DTO a entidades y viceversa.
- El controlador de empleados maneja las operaciones CRUD básicas con validaciones y lógica de negocio.

---

¡Eso es todo! Ahora tu proyecto debería estar listo para ser ejecutado.

