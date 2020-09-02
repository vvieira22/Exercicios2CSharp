using System;
using System.Collections.Generic;
using System.Text;

namespace exerciciosAula2.Scripts
{
    class quintaPotencia
    {
        private int numeroDigitado;

        public quintaPotencia(int numeroDigitado)
        {
            this.numeroDigitado = numeroDigitado;
        }

        public float FuncaoQuadrado()
        {
            return (float)Math.Pow(numeroDigitado, 5);
        }
    }
}
