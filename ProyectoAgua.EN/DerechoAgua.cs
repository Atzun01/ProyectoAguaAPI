using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAgua.EN
{
    public class DerechoAgua
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nombre es Obligatorio")]
        [StringLength(20, ErrorMessage = "Maximo 20 Caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Pasaje es Obligatorio")]
        [StringLength(50, ErrorMessage = "Maximo 50 Caracteres")]
        public string Pasaje { get; set; }
        [Required(ErrorMessage = "Casa es Oblgatorio")]
        [StringLength(100, ErrorMessage = "Maximo 40 Caracteres")]
        public string Casa { get; set; }
        public List<RegistroAgua> RegistroAgua { get; set; }
        public List<Mecha> Mecha { get; set; }
        public List<Consumo> Consumo { get; set; }
        [NotMapped]
        public int Top_Aux { get; set; }
    }
}
