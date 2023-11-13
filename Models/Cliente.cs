using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP4.Enums;

namespace TP4.Models
{
    public class Cliente
    {
        public eTiposClientes TipoCliente { get; set; }
        public string Estado { get; set; }
        public double HoraLlegada { get; set; }
        public double HoraEspera { get; set; }
    }
}
