# Console-ToDoList
Una aplicación de consola para la gestión de tareas, diseñada con C# y .NET 8.

## Descripción
ToDoDB es una aplicación de consola que permite a los usuarios gestionar tareas de manera eficiente. Con funcionalidades como crear, eliminar y actualizar tareas, esta herramienta es ideal para mantener un seguimiento de tus actividades diarias.

## Características
- Crear nuevas tareas con nombre, descripción y estado.
- Eliminar tareas existentes.
- Marcar tareas como completadas, en progreso o pendientes.
- Mostrar todas las tareas en una tabla interactiva.
- Separación de responsabilidades en capas (UI, Servicios, Repositorios).

## Requisitos
- .NET 8 SDK o superior.
- Visual Studio 2022 (recomendado).
- Base de datos configurada para Entity Framework Core (puedes usar SQLite, SQL Server, etc.).

## Instalación
1. Clona este repositorio:
2. Restaura las dependencias del proyecto:
3. Configura la base de datos:
   - Asegúrate de que la cadena de conexión en `TDBContext` esté configurada correctamente.
   - Aplica las migraciones para crear la base de datos:
     
4. Compila y ejecuta el proyecto:
   
## Uso
1. Al iniciar la aplicación, se mostrará un menú interactivo con las siguientes opciones:
   - **1**: Crear nueva tarea.
   - **2**: Eliminar tarea.
   - **3**: Marcar tarea como completada.
   - **4**: Marcar tarea como en progreso.
   - **5**: Marcar tarea como pendiente.
   - **0**: Salir.

2. Sigue las instrucciones en pantalla para interactuar con la aplicación.

## Estructura del Proyecto
- **Contexts/**: Contiene el contexto de la base de datos (`TDBContext`).
- **Data/**: Implementación del repositorio para la gestión de datos.
- **Migrations/**: Migraciones generadas por Entity Framework Core.
- **Objects/**: Clases de modelo, como `Task`.
- **Services/**: Servicios para la lógica de negocio, como `TaskService`.
- **UI/**: Lógica de la interfaz de usuario en consola.
- **Program.cs**: Punto de entrada de la aplicación.

## Tecnologías Utilizadas
- C# 12.0 y .NET 8.
- Entity Framework Core para la persistencia de datos.
- Inyección de dependencias con `Microsoft.Extensions.DependencyInjection`.

## Mejoras Futuras
- Exportar e importar tareas en formato JSON o CSV.
- Implementar autenticación y roles de usuario.
- Agregar soporte para prioridades y fechas límite en las tareas.
- Notificaciones para tareas próximas a vencer.
- Interfaz gráfica con WPF o Blazor.

## Contribuciones
¡Las contribuciones son bienvenidas! Si deseas colaborar, por favor:
1. Haz un fork del repositorio.
2. Crea una rama para tu funcionalidad:
3. Realiza tus cambios y haz un commit:
4. Envía un pull request.

## Licencia
Este proyecto está bajo la licencia MIT. Consulta el archivo `LICENSE` para más detalles.

   
   
