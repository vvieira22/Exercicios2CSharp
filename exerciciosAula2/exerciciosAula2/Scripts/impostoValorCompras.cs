using System;
using System.Collections.Generic;
using System.Text;

namespace exerciciosAula2.Scripts
{
    class impostoValorCompras
    {

        public Tuple<double,double> retornarValorImposto(double valor)
        {
            if (valor <= 15000)
                return new Tuple<double,double>(Convert.ToDouble(valor*5/100),5);
            if(valor> 15000 && valor < 70000)
                return new Tuple<double, double>(Convert.ToDouble(valor * 7.5 / 100), 7.5);
            if (valor > 70000 && valor < 100000)
                return new Tuple<double, double>(Convert.ToDouble(valor * 9 / 100), 9);
            return new Tuple<double, double>(Convert.ToDouble(valor * 9.5 / 100), 9.5);
        }

    }
}
