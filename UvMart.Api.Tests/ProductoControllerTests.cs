using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using UvMart.Api.Controllers;
using UvMart.Api.Models;
 
namespace UvMart.Api.Tests;
 
public class ProductosControllerTests
{
    private static readonly FieldInfo ProductosField = typeof(ProductosController)
        .GetField("Productos", BindingFlags.NonPublic | BindingFlags.Static)!;
 
    public ProductosControllerTests()
    {
        ResetProductos();
    }
 
    private static void ResetProductos()
    {
        var productos = (List<Producto>)ProductosField.GetValue(null)!;
        productos.Clear();
        productos.AddRange(new[]
        {
            new Producto { Id = 1, Nombre = "Laptop", Precio = 1200.00m, Stock = 15 },
            new Producto { Id = 2, Nombre = "Teclado Mecánico", Precio = 85.50m, Stock = 30 },
            new Producto { Id = 3, Nombre = "Mouse Inalámbrico", Precio = 45.99m, Stock = 50 }
        });
    }
 
    [Fact]
    public void Get_ReturnsAllProducts()
    {
        var controller = new ProductosController();
 
        var actionResult = controller.Get();
 
        var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        var productos = Assert.IsAssignableFrom<IEnumerable<Producto>>(okResult.Value);
 
        Assert.Equal(3, productos.Count());
    }
 
    [Fact]
    public void Get_ById_ReturnsProduct_WhenExists()
    {
        var controller = new ProductosController();
 
        var actionResult = controller.Get(2);
 
        var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        var producto = Assert.IsType<Producto>(okResult.Value);
 
        Assert.Equal(2, producto.Id);
        Assert.Equal("Teclado Mecánico", producto.Nombre);
    }
 
    [Fact]
    public void Get_ById_ReturnsNotFound_WhenMissing()
    {
        var controller = new ProductosController();
 
        var actionResult = controller.Get(999);
 
        Assert.IsType<NotFoundResult>(actionResult.Result);
    }
 
    [Fact]
    public void Post_AddsProduct_ReturnsCreatedAtAction()
    {
        var controller = new ProductosController();
        var productoNuevo = new Producto { Nombre = "Auriculares", Precio = 59.99m, Stock = 20 };
 
        var actionResult = controller.Post(productoNuevo);
 
        var createdResult = Assert.IsType<CreatedAtActionResult>(actionResult.Result);
        var creado = Assert.IsType<Producto>(createdResult.Value);
 
        Assert.Equal(4, creado.Id);
        Assert.Equal("Auriculares", creado.Nombre);
        Assert.Equal("Get", createdResult.ActionName);
    }
 
    [Fact]
    public void Post_AssignsUniqueId_WhenListHasExistingProducts()
    {
        var controller = new ProductosController();
        var productoNuevo = new Producto { Nombre = "Base para Laptop", Precio = 34.99m, Stock = 10 };
 
        var actionResult = controller.Post(productoNuevo);
        var createdResult = Assert.IsType<CreatedAtActionResult>(actionResult.Result);
        var creado = Assert.IsType<Producto>(createdResult.Value);
 
        Assert.Equal(4, creado.Id);
        Assert.Equal(4, ((List<Producto>)ProductosField.GetValue(null)!).Count);
    }
 
    [Fact]
    public void Put_UpdatesExistingProduct_ReturnsNoContent()
    {
        var controller = new ProductosController();
        var productoActualizado = new Producto { Id = 2, Nombre = "Teclado Retroiluminado", Precio = 95.00m, Stock = 25 };
 
        var result = controller.Put(2, productoActualizado);
 
        Assert.IsType<NoContentResult>(result);
 
        var updatedProduct = ((List<Producto>)ProductosField.GetValue(null)!).First(p => p.Id == 2);
        Assert.Equal("Teclado Retroiluminado", updatedProduct.Nombre);
        Assert.Equal(95.00m, updatedProduct.Precio);
        Assert.Equal(25, updatedProduct.Stock);
    }
 
    [Fact]
    public void Put_ReturnsNotFound_WhenProductDoesNotExist()
    {
        var controller = new ProductosController();
        var productoActualizado = new Producto { Id = 999, Nombre = "Producto No Existe", Precio = 1.00m, Stock = 0 };
 
        var result = controller.Put(999, productoActualizado);
 
        Assert.IsType<NotFoundResult>(result);
    }
 
    [Fact]
    public void Delete_RemovesExistingProduct_ReturnsNoContent()
    {
        var controller = new ProductosController();
 
        var result = controller.Delete(1);
 
        Assert.IsType<NoContentResult>(result);
        Assert.DoesNotContain(((List<Producto>)ProductosField.GetValue(null)!), p => p.Id == 1);
    }
 
    [Fact]
    public void Delete_ReturnsNotFound_WhenProductDoesNotExist()
    {
        var controller = new ProductosController();
 
        var result = controller.Delete(999);
 
        Assert.IsType<NotFoundResult>(result);
    }
 
    [Fact]
    public void Get_AfterPost_ReturnsProductInList()
    {
        var controller = new ProductosController();
        var nuevo = new Producto { Nombre = "Cargador USB-C", Precio = 29.99m, Stock = 40 };
        controller.Post(nuevo);
 
        var actionResult = controller.Get();
        var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        var productos = Assert.IsAssignableFrom<IEnumerable<Producto>>(okResult.Value);
 
        Assert.Contains(productos, p => p.Nombre == "Cargador USB-C" && p.Precio == 29.99m && p.Stock == 40);
        Assert.Equal(4, productos.Count());
    }
}