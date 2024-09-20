using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAgua.EN
{
    internal class Mecha
    {

        public int Id { get; set; }
        public string CantidadMecha { get; set; }

        public int? DerechoAguaId { get; set; }
        public DerechoAgua DerechoAgua { get; set; }
    }
}
