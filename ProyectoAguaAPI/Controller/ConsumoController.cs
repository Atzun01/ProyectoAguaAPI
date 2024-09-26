using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoAgua.BL;
using ProyectoAgua.EN;
using System.Text.Json;

namespace SysSeguridadG05.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumoController : ControllerBase
    {
        private ConsumoBL consumoBl = new ConsumoBL();

        [HttpGet]
        public async Task<IEnumerable<Consumo>> Get()
        {
            return await consumoBl.ObtenerTodosAsync();
        }

        [HttpGet("{id}")]
        public async Task<Consumo> Get(int id)
        {
            Consumo consumo = new Consumo();
            consumo.Id = id;
            return await consumoBl.ObtenerPorIdAsync(consumo);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] object pConsumo)
        {
            try
            {
                var option = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                string strConsumo = JsonSerializer.Serialize(pConsumo);
                Consumo consumo = JsonSerializer.Deserialize<Consumo>(strConsumo, option);
                await consumoBl.CrearAsync(consumo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] object pConsumo)
        {
            try
            {
                var option = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                string strConsumo = JsonSerializer.Serialize(pConsumo);
                Consumo consumo = JsonSerializer.Deserialize<Consumo>(strConsumo, option);
                if (consumo.Id == id)
                {
                    await consumoBl.ModificarAsync(consumo);
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
                await consumoBl.EliminarAsync(new Consumo { Id = id });
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Consumo>> Buscar([FromBody] object pConsumo)
        {
            try
            {
                var option = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var strConsumo = JsonSerializer.Serialize(pConsumo);
                Consumo consumo = JsonSerializer.Deserialize<Consumo>(strConsumo, option);
                return await consumoBl.BuscarAsync(consumo);
            }
            catch (Exception ex)
            {
                return new List<Consumo>();
            }
        }
    }
}

