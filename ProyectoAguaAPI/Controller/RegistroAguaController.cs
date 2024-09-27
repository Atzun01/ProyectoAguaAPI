using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoAgua.BL;
using ProyectoAgua.EN;
using System.Text.Json;

namespace ProyectoAguaAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroAguaController : ControllerBase
    {
        private RegistroAguaBL registroAguaBL = new RegistroAguaBL();

        [HttpGet]
        public async Task<IEnumerable<RegistroAgua>> Get()
        {
            return await registroAguaBL.ObtenerTodosRegistrosAguaAsync();
        }

        [HttpGet("{id}")]
        public async Task<RegistroAgua> Get(int id)
        {
            RegistroAgua registroAgua = new RegistroAgua();
            registroAgua.Id = id;
            return await registroAguaBL.ObtenerRegistroAguaPorIdAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] object pRegistroAgua)
        {
            try
            {
                var option = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                string strRegistroAgua = JsonSerializer.Serialize(pRegistroAgua);
                RegistroAgua registroAgua = JsonSerializer.Deserialize<RegistroAgua>(strRegistroAgua, option);
                await registroAguaBL.CrearRegistroAguaAsync(registroAgua);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] object pRegistroAgua)
        {
            try
            {
                var option = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                string strRegistroAgua = JsonSerializer.Serialize(pRegistroAgua);
                RegistroAgua registroAgua = JsonSerializer.Deserialize<RegistroAgua>(strRegistroAgua, option);
                if (registroAgua.Id == id)
                {
                    await registroAguaBL.ModificarRegistroAguaAsync(registroAgua);
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
                await registroAguaBL.EliminarRegistroAguaAsync(new RegistroAgua { Id = id });
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<RegistroAgua>> Buscar([FromBody] object pRegistroAgua)
        {
            try
            {
                var option = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var strRegistroAgua = JsonSerializer.Serialize(pRegistroAgua);
                RegistroAgua registroAgua = JsonSerializer.Deserialize<RegistroAgua>(strRegistroAgua, option);
                return await registroAguaBL.BuscarRegistrosAguaAsync(registroAgua);
            }
            catch (Exception ex)
            {
                return new List<RegistroAgua>();
            }
        }
    }
}
