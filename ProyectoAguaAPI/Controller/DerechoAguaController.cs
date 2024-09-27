using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoAgua.BL;
using ProyectoAgua.EN;
using System.Text.Json;

namespace ProyectoAguaAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DerechoAguaController : ControllerBase
    {
        private DerechoAguaBL derechoaguabl = new DerechoAguaBL();

        [HttpGet]
        public async Task<IEnumerable<DerechoAgua>> Get()
        {
            return await derechoaguabl.ObtenerTodosAsync();
        }

        [HttpGet("{id}")]
        public async Task<DerechoAgua> Get(int id)
        {
            DerechoAgua derechoagua = new DerechoAgua();
            derechoagua.Id = id;
            return await derechoaguabl.ObtenerPorIdAsync(derechoagua);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] object pDerechoAgua)
        {
            try
            {
                var option = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                string strDerechoAgua = JsonSerializer.Serialize(pDerechoAgua);
                DerechoAgua derechoAgua = JsonSerializer.Deserialize<DerechoAgua>(strDerechoAgua, option);
                await derechoaguabl.GuardarAsync(derechoAgua);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] object pDerechoAgua)
        {
            try
            {
                var option = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                string strDerchoAgua = JsonSerializer.Serialize(pDerechoAgua);
                DerechoAgua derechoAgua = JsonSerializer.Deserialize<DerechoAgua>(strDerchoAgua, option);
                if (derechoAgua.Id == id)
                {
                    await derechoaguabl.GuardarAsync(derechoAgua);
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
                await derechoaguabl.EliminarAsync(new DerechoAgua { Id = id });
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<DerechoAgua>> Buscar([FromBody] object pDerechoAgua)
        {
            try
            {
                var option = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var strDerechoAgua = JsonSerializer.Serialize(pDerechoAgua);
                DerechoAgua derechoAgua = JsonSerializer.Deserialize<DerechoAgua>(strDerechoAgua, option);
                return await derechoaguabl.BuscarAsync(derechoAgua);
            }
            catch (Exception ex)
            {
                return new List<DerechoAgua>();
            }
        }
    }
}

