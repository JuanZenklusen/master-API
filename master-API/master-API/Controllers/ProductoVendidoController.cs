using master_API.Models;
using master_API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace master_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoVendidoController : ControllerBase
    {

        [HttpGet("TraerProductoVendidoCargadoNombreUsuario")]
        public List<DescripProducto> TraerProdVendido(string nomDeUsuario) => ADO_ProductoVendido.TraerProductoVendido(nomDeUsuario);

    }
}
