using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAgua.EN
{
    internal class DerechoAgua
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Pasaje { get; set; }
        public string Casa { get; set; }

        public ICollection<Consumo> Consumos { get; set; }
        public ICollection<Mecha> Mechas { get; set; }
        public ICollection<Mora> Moras { get; set; }
        public ICollection<RegistroAgua> RegistroAguas { get; set; }
    }
}
