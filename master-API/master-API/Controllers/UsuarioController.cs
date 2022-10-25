using master_API.Models;
using master_API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace master_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet("TraerTodosLosUsuarios")]
        public List<Usuario> Get()
        {
            return ADO_Usuario.TraerUsuarios();
        }

        [HttpGet("TraerUsuarioPorId")]
        public Usuario TraerUnUsuario(string NombreUsuario)
        {
            return ADO_Usuario.TraerUsuariosPorId(NombreUsuario);
        }

        [HttpPut("ModificarUsuario")]
        public void ModificarUsuario([FromBody] Usuario Us, int id)
        {
            ADO_Usuario.ModificarUsuario(Us, id);
        }
    }
}
