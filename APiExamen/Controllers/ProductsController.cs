using APiExamen.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APiExamen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductosBL _productosBL;

        public ProductsController(IProductosBL productosBL) { _productosBL = productosBL; }

        [HttpGet]
        public async Task<IActionResult> GET() 
        {
            try {
               var response = await _productosBL.GET();
                return Ok(response);
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
        
        }
    }
}
