using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAgua.EN
{
    public class Empleado
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nombre es Obligatorio")]
        [StringLength(20, ErrorMessage = "Maximo 20 Caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Direccion es Obligatorio")]
        [StringLength(50, ErrorMessage = "Maximo 50 Caracteres")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "Entrada es Oblgatorio")]
        [StringLength(100, ErrorMessage = "Maximo 40 Caracteres")]
        public string Entrada { get; set; }
        [NotMapped]
        public int Top_Aux { get; set; }
    }
}
