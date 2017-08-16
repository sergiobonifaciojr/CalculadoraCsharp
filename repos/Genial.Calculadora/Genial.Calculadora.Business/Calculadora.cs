using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genial.Calculadora.Business
{
    public class Calculadora
    {
        private double N1 { get; set; }
        private double N2 { get; set; }

        public Calculadora(double n1, double n2)
        {
            N1 = n1;
            N2 = n2;
        }

        public double Somar()
        {
            return N1 + N2;
        }
        
        public double Subtrair()
        {
            return N1 - N2;
        }

        public double Dividir()
        {
            return N1 / N2;
        }

        public double Multiplicar()
        {
            return N1 * N2; 
        }
    }
}
