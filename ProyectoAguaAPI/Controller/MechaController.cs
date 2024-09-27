using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoAgua.BL;
using ProyectoAgua.EN;
using System.Text.Json;

namespace ProyectoAguaAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MechaController : ControllerBase
    {
        private MechaBL mechaBL = new MechaBL();

        [HttpGet]
        public async Task<IEnumerable<Mecha>> Get()
        {
            return await mechaBL.ObtenerTodosAsync();
        }

        [HttpGet("{id}")]
        public async Task<Mecha> Get(int id)
        {
            Mecha mecha = new Mecha();
            mecha.Id = id;
            return await mechaBL.ObtenerPorIdAsync(mecha);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] object pMecha)
        {
            try
            {
                var option = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                string strMecha = JsonSerializer.Serialize(pMecha);
                Mecha mecha = JsonSerializer.Deserialize<Mecha>(strMecha, option);
                await mechaBL.GuardarAsync(mecha);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] object pMecha)
        {
            try
            {
                var option = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                string strMecha = JsonSerializer.Serialize(pMecha);
                Mecha mecha = JsonSerializer.Deserialize<Mecha>(strMecha, option);
                if (mecha.Id == id)
                {
                    await mechaBL.ModificarAsync(mecha);
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
                await mechaBL.EliminarAsync(new Mecha { Id = id });
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Mecha>> Buscar([FromBody] object pMecha)
        {
            try
            {
                var option = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var strMecha = JsonSerializer.Serialize(pMecha);
                Mecha mecha = JsonSerializer.Deserialize<Mecha>(strMecha, option);
                return await mechaBL.BuscarAsync(mecha);
            }
            catch (Exception ex)
            {
                return new List<Mecha>();
            }
        }
    }
}

