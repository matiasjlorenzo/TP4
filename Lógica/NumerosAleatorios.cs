using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4.Lógica
{
    public class NumerosAleatorios
    {
        public List<double> GenerarNumeros(int n)
        {
            List<double> list = new List<double>();
            Random rnd = new Random();

            for (int i = 0; i < n; i++)
            {
                double nroi = (double)rnd.NextDouble();
                list.Add(Math.Round(nroi, 2));
            }

            return list;
        }
    }
}
