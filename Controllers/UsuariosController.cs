using ApiRestIPSPROAA.Datos;
using ApiRestIPSPROAA.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiRestIPSPROAA.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> Get()
        {
            var funcion = new DatosUsuario();
            var lista = await funcion.MostrarUsuarios();
            return lista;
        }
    }
}
