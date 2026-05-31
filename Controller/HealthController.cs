namespace SimpleApiApp.Controller;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult Check()
    {
        return Ok(new
        {
            Status  = "Healthy",
            Time    = DateTime.UtcNow,
            Service = "MyApiApp"
        });
    }
}