namespace SimpleApiApp.Controller;

using Microsoft.AspNetCore.Mvc;
using SimpleApiApp.Models;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private static readonly List<Category> Categories = new()
    {
        new Category { Id = 1, Title = "Electronics", Description = "Electronic devices" },
        new Category { Id = 2, Title = "Accessories", Description = "Various accessories" }
    };

    [HttpGet]
    public IActionResult GetAll() => Ok(Categories);

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var category = Categories.FirstOrDefault(c => c.Id == id);
        return category is null ? NotFound() : Ok(category);
    }

    [HttpPost]
    public IActionResult Create([FromBody] Category category)
    {
        category.Id = Categories.Max(c => c.Id) + 1;
        Categories.Add(category);
        return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
    }
}