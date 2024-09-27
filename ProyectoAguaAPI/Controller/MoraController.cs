using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoAgua.BL;
using ProyectoAgua.EN;
using System.Text.Json;

namespace ProyectoAguaAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoraController : ControllerBase
    {
        private MoraBL moraBL = new MoraBL();

        [HttpGet]
        public async Task<IEnumerable<Mora>> Get()
        {
            return await moraBL.ObtenerTodosAsync();
        }

        [HttpGet("{id}")]
        public async Task<Mora> Get(int id)
        {
            Mora mora = new Mora();
            mora.Id = id;
            return await moraBL.ObtenerPorIdAsync(mora);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] object pMora)
        {
            try
            {
                var option = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                string strMora = JsonSerializer.Serialize(pMora);
                Mora mora = JsonSerializer.Deserialize<Mora>(strMora, option);
                await moraBL.GuardarAsync(mora);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] object pMora)
        {
            try
            {
                var option = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                string strMora = JsonSerializer.Serialize(pMora);
                Mora mora = JsonSerializer.Deserialize<Mora>(strMora, option);
                if (mora.Id == id)
                {
                    await moraBL.ModificarAsync(mora);
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
                await moraBL.EliminarAsync(new Mora { Id = id });
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Mora>> Buscar([FromBody] object pMora)
        {
            try
            {
                var option = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var strMora = JsonSerializer.Serialize(pMora);
                Mora mora = JsonSerializer.Deserialize<Mora>(strMora, option);
                return await moraBL.BuscarAsync(mora);
            }
            catch (Exception ex)
            {
                return new List<Mora>();
            }
        }
    }
}
