using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAgua.EN
{
    public class Consumo
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("DerechoAgua")]
        [Required(ErrorMessage = "DerechoAgua es Obligatorio")]
        [Display(Name = "DerechoAgua")]
        public int IdDerechoAgua { get; set; }
        [Required(ErrorMessage = "Mora es Obligatorio")]
        [StringLength(32, ErrorMessage = "Mora debe tener entre 5 y 32 Caracteres")]
        public string Mora { get; set; }
        public DerechoAgua DerechoAgua { get; set; }
        [NotMapped]
        public int Top_Aux { get; set; }
    }
}
