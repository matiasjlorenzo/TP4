using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP4.Enums;

namespace TP4.Models
{
    public class Terminal
    {
        public Terminal()
        {
            Estado = eEstadosTerminales.Libre;
            //Ocupada = false;
            MantenimientoRealizado = false;
            HoraFinOperacion = 0;
        }
        public string Estado { get; set; }
        //public bool Ocupada { get; set; }
        public Cliente Cliente { get; set; }
        public bool MantenimientoRealizado { get; set; }
        public double HoraFinOperacion { get; set; }
    }
}
