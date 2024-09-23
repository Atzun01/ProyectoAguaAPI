using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAgua.EN
{
    public class RegistroAgua
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("DerechoAgua")]
        [Required(ErrorMessage = "DerechoAgua es Obligatorio")]
        [Display(Name = "DerechoAgua")]
        public int IdDerechoAgua { get; set; }
        [Required(ErrorMessage = "Pago es Obligatorio")]
        public int Pago { get; set; }
        [Required(ErrorMessage = "FechaPago es Obligatorio")]
        public DateTime FechaPago { get; set; }
        public DerechoAgua DerechoAgua { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }
    }
}
