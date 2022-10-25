using master_API.Models;
using master_API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace master_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        [HttpGet("ProductoCargadoPorUsuarioId")]
        public List<DescripProducto> TraerProd(int IdUsuario) => ADO_Producto.TraerProducto(IdUsuario);


        [HttpPost(Name = "Agregar producto")]
        public void AgregarProducto([FromBody] Producto pr)
        {
            ADO_Producto.AgregarProducto(pr);
        }


        [HttpPut(Name = "Modificar un producto")]
        public void ModificarProducto([FromBody] Producto Pr, int id)
        {
            ADO_Producto.ModificarProducto(Pr, id);
        }


        [HttpDelete(Name = "Eliminar producto")]
        public void EliminarProducto([FromBody] int id)
        {
            ADO_Producto.EliminarProducto(id);
        }

    }
}
