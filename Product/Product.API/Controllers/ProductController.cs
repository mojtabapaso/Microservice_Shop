using Microsoft.AspNetCore.Mvc;

namespace Product.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController(ILogger<ProductController> logger) : ControllerBase
{

}
