using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoAgua.EN;
using ProyectoAgua.BL;
using System.Text.Json;

namespace ProyectoAguaAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private EmpleadoBL empleadoBl = new EmpleadoBL();

        // Obtener todos los empleados
        [HttpGet]
        public async Task<IEnumerable<Empleado>> Get()
        {
            return await empleadoBl.ObtenerTodosAsync();
        }

        // Obtener un empleado por ID
        [HttpGet("{id}")]
        public async Task<Empleado> Get(int id)
        {
            Empleado empleado = new Empleado();
            empleado.Id = id;
            return await empleadoBl.ObtenerPorIdAsync(empleado);
        }

        // Crear un nuevo empleado
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] object pEmpleado)
        {
            try
            {
                var option = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                string strEmpleado = JsonSerializer.Serialize(pEmpleado);
                Empleado empleado = JsonSerializer.Deserialize<Empleado>(strEmpleado, option);
                await empleadoBl.CrearAsync(empleado);
                return Ok();
            }
            catch (Exception Ex)
            {
                return BadRequest();
            }
        }

        // Modificar un empleado existente
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] object pEmpleado)
        {
            try
            {
                var option = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                string strEmpleado = JsonSerializer.Serialize(pEmpleado);
                Empleado empleado = JsonSerializer.Deserialize<Empleado>(strEmpleado, option);
                if (empleado.Id == id)
                {
                    await empleadoBl.ModificarAsync(empleado);
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

        // Eliminar un empleado por ID
        [HttpDelete("{id}")]
        public async Task<ActionResult> Eliminar(int id)
        {
            try
            {
                await empleadoBl.EliminarAsync(new Empleado { Id = id });
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Buscar empleados con filtros
        [HttpPost("Buscar")]
        public async Task<List<Empleado>> Buscar([FromBody] object pEmpleado)
        {
            try
            {
                var option = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var strEmpleado = JsonSerializer.Serialize(pEmpleado);
                Empleado empleado = JsonSerializer.Deserialize<Empleado>(strEmpleado, option);
                return await empleadoBl.BuscarAsync(empleado);
            }
            catch (Exception ex)
            {
                return new List<Empleado>();
            }
        }

    }
}
