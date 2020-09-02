using System;
using System.Collections.Generic;
using System.Text;

namespace exerciciosAula2.Scripts
{
    class mostrarNumerosNegativos
    {
        int[] numeros;

        public mostrarNumerosNegativos(int[] numeros)
        {
            this.numeros = numeros;
        }
        public int retornarQuantidadeNegativos()
        {
            int quantidade = 0;

            foreach (int i in numeros)
            {
                if (i % 2 != 0)
                    quantidade++;
            }
            return quantidade;
        }
    }
}
