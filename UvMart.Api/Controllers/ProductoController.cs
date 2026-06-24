using Microsoft.AspNetCore.Mvc;
using UvMart.Api.Models;
namespace UvMart.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProductosController : ControllerBase
{
    private static readonly List<Producto> Productos = new()
    {
        new Producto { Id = 1, Nombre = "Laptop", Precio = 1200.00m, Stock = 15 },
        new Producto { Id = 2, Nombre = "Teclado Mecánico", Precio = 85.50m, Stock = 30 },
        new Producto { Id = 3, Nombre = "Mouse Inalámbrico", Precio = 45.99m, Stock = 50 }
    };
    [HttpGet]
    public ActionResult<IEnumerable<Producto>> Get()
    {
        return Ok(Productos);
    }
    [HttpGet("{id:int}")]
    public ActionResult<Producto> Get(int id)
    {
        var producto = Productos.FirstOrDefault(p => p.Id == id);
        return producto is not null ? Ok(producto) : NotFound();
    }
[HttpPost]
    public ActionResult<Producto> Post(Producto producto)
    {
        producto.Id = Productos.Any() ? Productos.Max(p => p.Id) + 1 : 1;
        Productos.Add(producto);
        return CreatedAtAction(nameof(Get), new { id = producto.Id }, producto);
    }
    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Producto producto)
    {
        var existente = Productos.FirstOrDefault(p => p.Id == id);
        if (existente is null)
        {
            return NotFound();
        }
        existente.Nombre = producto.Nombre;
        existente.Precio = producto.Precio;
        existente.Stock = producto.Stock;
        return NoContent();
    }
[HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var producto = Productos.FirstOrDefault(p => p.Id == id);
        if (producto is null)
        {
            return NotFound();
        }
        Productos.Remove(producto);
        return NoContent();
    }
}