using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4.Models
{
    public class Servidor
    {
        public Servidor()
        {
            ColaClientes = new Queue<Cliente>();
            Terminal1 = new Terminal();
            Terminal2 = new Terminal();
            Terminal3 = new Terminal();
            Terminal4 = new Terminal();
        }

        public Queue<Cliente> ColaClientes { get; set; }
        public Terminal Terminal1 { get; set; }
        public Terminal Terminal2 { get; set; }
        public Terminal Terminal3 { get; set; }
        public Terminal Terminal4 { get; set; }
    }
}
