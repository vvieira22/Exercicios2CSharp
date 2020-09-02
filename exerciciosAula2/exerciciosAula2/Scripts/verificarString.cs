using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exerciciosAula2.Scripts
{
    class verificarString
    {

        public int retornarQuantidadePontuacao(string palavra)
        {
            int soma = 0;
            for(int i = 0; i < palavra.Length; i++)
            {     
                if (char.IsPunctuation(palavra[i]))
                    soma = soma + 1;
            }
            return soma;
        }
        public int retornarQuantidadeNumeros(string palavra)
        {
            return palavra.Count(c => char.IsDigit(c));
        }
    }
}
