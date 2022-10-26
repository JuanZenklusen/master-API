using master_API.Models;
using master_API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace master_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {

        [HttpPost]
        public void CargarVenta([FromBody] VentaProducto vtas)
        {
            ADO_Ventas.CargarVenta(vtas);
        }

    }
}
