# Parcial # 2 (Capas)

## 📅 Fecha: 07/11/2026

## 📋 Contenido del Repositorio

**Store** es una aplicación de escritorio en C# y Windows Forms con arquitectura por capas y patrón **MVP**. Permite iniciar sesión con contraseñas protegidas por hash, ver quién inició sesión y consultar los productos guardados en una base de datos MySQL.

## 🛠️ Tecnologías Utilizadas

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)
![.NET Framework](https://img.shields.io/badge/.NET_Framework_4.7.2-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![MySQL](https://img.shields.io/badge/MySQL-4479A1?style=for-the-badge&logo=mysql&logoColor=white)
![Visual Studio](https://img.shields.io/badge/Visual_Studio-5C2D91?style=for-the-badge&logo=visualstudio&logoColor=white)
![Git](https://img.shields.io/badge/Git-F05032?style=for-the-badge&logo=git&logoColor=white)

- **Lenguaje / Framework:** C#, .NET Framework 4.7.2 y Windows Forms
- **Base de datos:** MySQL 8 con el conector MySql.Data
- **Herramientas:** Visual Studio, Git y GitHub

## 🖥️ Capturas de Pantalla y Problemas

### Inicio de Sesión

![Pantalla de inicio de sesión](Parcial2(Capa)/docs/capturas/login.png)

- **Patrón MVP:** `frmLogin` solo muestra datos y recibe acciones. `LoginPresenter` valida los campos, consulta la capa de negocio y le indica a la vista qué mostrar a través de `ILoginVista`.
- **Generar y verificar hash:** la capa de negocio tiene dos contratos independientes, `IHashService` e `IVerificarHashService`. `HashService` los implementa con SHA-512 y compara la contraseña escrita con el hash guardado.
- **Conexión con privilegios mínimos:** la aplicación usa el usuario `app_tienda`, que solo puede leer las columnas necesarias de `usuarios` y `productos`. Las credenciales están en `conexion.config`, un archivo que no se sube al repositorio.

### Interfaz Principal

![Pantalla principal](Parcial2(Capa)/docs/capturas/principal.png)

- **Menú lateral:** las opciones están a la izquierda y el botón de las tres rayas contrae o expande el menú. Solo **Productos** está implementado; las demás opciones avisan que aún no están disponibles.
- **Hora actual:** un temporizador actualiza la hora y la fecha cada segundo.
- **Usuario de la sesión:** `frmLogin` entrega el usuario autenticado a la pantalla principal, que lo muestra en la parte inferior del menú.
- **Lista de productos:** `PrincipalPresenter` obtiene los productos desde la capa de negocio y los muestra en la tabla.

## 📁 Estructura de Carpetas o Directorios

```plaintext
Parcial-Capas-/
├── Parcial2(Capa)/
│   ├── BaseDeDatos/          # Scripts para crear las tablas y el usuario de la aplicación
│   ├── Datos/                # Acceso a MySQL
│   ├── docs/capturas/        # Imágenes de este README
│   ├── Entidades/            # Clases que representan los datos
│   ├── Negocio/
│   │   ├── Hash/             # Implementación de los contratos de hash
│   │   ├── Herramienta/      # Reglas de negocio de usuarios y productos
│   │   └── Interfaces/       # Contratos para generar y verificar el hash
│   ├── Presentacion/
│   │   ├── Presentadores/    # Presentadores del patrón MVP
│   │   ├── Resources/        # Imágenes de la interfaz
│   │   └── Vistas/           # Interfaces de las vistas
│   └── Parcial2(Capa).slnx   # Solución de Visual Studio
├── Capas (Backup).sql        # Copia de seguridad de la base de datos
├── Capas.sql                 # Consultas de apoyo para revisar usuarios y cambiar contraseñas
└── README.md                 # Documentación del proyecto
```

## 🚀 Instrucciones de Ejecución / Uso

### Requisitos

- Visual Studio con el componente de desarrollo de escritorio .NET
- MySQL Server 8

### Pasos

1. Clona el repositorio y entra en la carpeta del proyecto:

   ```bash
   git clone https://github.com/Lyrics354/Parcial-Capas-.git
   cd "Parcial-Capas-/Parcial2(Capa)"
   ```

2. Prepara la base de datos en MySQL Workbench, conectado como administrador:
   1. Abre `BaseDeDatos/esquema.sql`, cambia `CAMBIAR_CLAVE` por la contraseña que tendrá el usuario `admin` de la aplicación y ejecútalo.
   2. Abre `BaseDeDatos/usuario_app.sql`, cambia `CAMBIAR_CLAVE` por una clave para `app_tienda` y ejecútalo.

3. Crea el archivo de conexión y escribe en él la clave de `app_tienda`:

   ```bash
   cp Presentacion/conexion.example.config Presentacion/conexion.config
   ```

4. Abre `Parcial2(Capa).slnx` en Visual Studio y restaura los paquetes NuGet.

5. Establece `Presentacion` como proyecto de inicio y pulsa `F5`.

6. Inicia sesión con tu usuario y contraseña. En la pantalla principal verás los productos, la hora y el usuario de la sesión.

## 🧑‍🎓 Autor y Contexto

- **Nombre:** Wilson Wu (2-756-299)
- **Institución:** Universidad Tecnológica de Panamá (UTP)
- **Fecha de Realización:** 07/11/2026

## 📖 Referencias

- [Video de Apoyo](https://youtu.be/y1jftnTaTXU?si=9w3DMOw9oRmwEa7m)
- [Documentación de Windows Forms](https://learn.microsoft.com/es-es/dotnet/desktop/winforms/)
- [Documentación de MySQL Connector/NET](https://dev.mysql.com/doc/connector-net/en/)
