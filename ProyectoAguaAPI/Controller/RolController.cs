using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoAgua.BL;
using ProyectoAgua.EN;
using System.Text.Json;

namespace ProyectoAguaAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private RolBL rolBL = new RolBL();

        [HttpGet]
        public async Task<IEnumerable<Rol>> Get()
        {
            return await rolBL.ObtenerTodosRolesAsync();
        }

        [HttpGet("{id}")]
        public async Task<Rol> Get(int id)
        {
            Rol rol = new Rol();
            rol.Id = id;
            return await rolBL.ObtenerRolPorIdAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] object pRol)
        {
            try
            {
                var option = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                string strRol = JsonSerializer.Serialize(pRol);
                Rol rol = JsonSerializer.Deserialize<Rol>(strRol, option);
                await rolBL.CrearRolAsync(rol);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] object pRol)
        {
            try
            {
                var option = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                string strMecha = JsonSerializer.Serialize(pRol);
                Rol rol = JsonSerializer.Deserialize<Rol>(strMecha, option);
                if (rol.Id == id)
                {
                    await rolBL.ModificarRolAsync(rol);
                    return Ok();
                }
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Eliminar(int id)
        {
            try
            {
                await rolBL.EliminarRolAsync(new Rol { Id = id });
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Rol>> Buscar([FromBody] object pRol)
        {
            try
            {
                var option = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var strRol = JsonSerializer.Serialize(pRol);
                Rol rol = JsonSerializer.Deserialize<Rol>(strRol, option);
                return await rolBL.BuscarRolesAsync(rol);
            }
            catch (Exception ex)
            {
                return new List<Rol>();
            }
        }
    }
}
