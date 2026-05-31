using Microsoft.AspNetCore.Mvc;
using SimpleApiApp.Models;

namespace SimpleApiApp.Controller;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private static readonly List<Product> Products = new()
    {
        new Product { Id = 1, Name = "Laptop", Price = 999.99m },
        new Product { Id = 2, Name = "Mouse",  Price = 29.99m  }
    };

    [HttpGet]
    public IActionResult GetAll() => Ok(Products);

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var product = Products.FirstOrDefault(p => p.Id == id);
        return product is null ? NotFound() : Ok(product);
    }

    [HttpPost]
    public IActionResult Create([FromBody] Product product)
    {
        product.Id = Products.Max(p => p.Id) + 1;
        Products.Add(product);
        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }
}