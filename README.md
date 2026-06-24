# UvMart API
 
API Web simple para la gestión de productos construida con .NET 10.
 
## Estructura del repositorio
 
- `UvMart.slnx` - Solución principal.
- `UvMart.Api/` - Proyecto Web API.
  - `Controllers/ProductosController.cs` - Controlador REST para CRUD de productos.
  - `Models/Producto.cs` - Entidad de producto.
  - `Program.cs` - Configuración de la aplicación y mapeo de controladores.
- `UvMart.Api.Tests/` - Proyecto de pruebas unitarias.
  - `ProductosControllerTests.cs` - Pruebas unitarias para el controlador `ProductosController`.
 
## Funcionalidad
 
El controlador `ProductosController` expone los siguientes endpoints:
 
- `GET /api/Productos` - Listar todos los productos.
- `GET /api/Productos/{id}` - Obtener un producto por su identificador.
- `POST /api/Productos` - Crear un nuevo producto.
- `PUT /api/Productos/{id}` - Actualizar un producto existente.
- `DELETE /api/Productos/{id}` - Eliminar un producto.
 
El controlador utiliza una lista en memoria para almacenar los productos y devuelve respuestas HTTP estándar (`200 OK`, `201 Created`, `204 No Content`, `404 Not Found`).
 
## Tecnologías
 
- .NET 10
- ASP.NET Core Web API
- xUnit para pruebas unitarias
 
## Cómo ejecutar
 
Desde la raíz de la solución:
 
```powershell
cd c:\Tmp\git\webapiapp
dotnet run --project UvMart.Api\UvMart.Api.csproj
```
 
La API quedará disponible en `https://localhost:5001` o el puerto asignado por el servidor.
 
## Cómo probar
 
Ejecuta las pruebas unitarias desde la raíz de la solución:
 
```powershell
dotnet test UvMart.Api.Tests\UvMart.Api.Tests.csproj
```
 
## Notas
 
- El proyecto actual usa datos de ejemplo en memoria, por lo que los cambios no persisten entre ejecuciones.
- Para desarrollo y pruebas locales, los endpoints se configuran mediante el atributo `[Route("api/[controller]")]`.