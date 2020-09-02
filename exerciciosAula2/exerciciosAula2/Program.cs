using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.X509Certificates;
using exerciciosAula2.Scripts;

namespace exerciciosAula2
{
    class Program
    {
        static void Main(string[] args)
        {

            int numeroExercicio;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;

                string title3 = @"
							         ██
 ______                   _      _         ___  	  ▄█     ██     █▄  
|  ____|                 (_)    (_)       |__ \         ███      ██      ███
| |__  __  _____ _ __ ___ _  ___ _  ___      ) |	 ▀███    ██    ███▀
|  __| \ \/ / _ \ '__/ __| |/ __| |/ _ \    / /             ███▌ ██ ████
| |____ >  <  __/ | | (__| | (__| | (_) |  / /_ 	      ▀██████▀
|______/_/\_\___|_|  \___|_|\___|_|\___/  |____|  	     ██████████
							  ████   ██   ████
							 ███     ██     ███
							   ███   ██   ███
							     ██████████
							       ██████
							         ██  
";
                Console.SetWindowSize(110, 30);
                foreach (var character in title3)
                {
                    Console.Write(character);
                    System.Threading.Thread.Sleep(1);
                }
                Console.ForegroundColor = ConsoleColor.White;


                System.Threading.Thread.Sleep(500);
                bool tryAgain = true;
                Console.WriteLine("0: Sair do Programa");
                Console.WriteLine("1: Calcular a quinta potência de um número qualquer.");
                Console.WriteLine("2: Calcular a velocidade média de um veículo.");
                Console.WriteLine("3: Mostrar Numeros negativos");
                Console.WriteLine("4: Calcule o quadrado dos números inteiros entre 3 e 9.");
                Console.WriteLine("5: Calcule a soma dos números inteiros, enquanto a soma\nnão ultrapassar o valor de 77");
                Console.WriteLine("6: Calcular imposto a ser cobrado");
                Console.WriteLine("7: Inserir quatro números inteiros ao usuário e exiba\no valor da soma seguido pelo maior deles.");
                Console.WriteLine("8: Converter Fahrenheit para Celsius.");
                Console.WriteLine("9: Ler cada caractere que o usuário digitar\nse for 'j' exibir todos antes dele");
                Console.WriteLine("10: Ler n numeros mostrar na tela do menor para o maior");
                Console.WriteLine("11: Ler dois numeros e informar algumas operaões entre eles");
                Console.WriteLine("12: Ler uma String e dizer sua quantidade de números e pontuação,\nalém dela mesma");
                numeroExercicio = Convert.ToInt32(Console.ReadLine());

                switch (numeroExercicio)
                {
                    case 0:
                        break;
                    case 1:
                        tryAgain = true;
                        Console.Clear();
                        while (tryAgain)
                        {
                            try
                            {
                                Console.WriteLine("Digite o número para ser elevado a 5:");
                                quintaPotencia quintapotencia = new quintaPotencia(Convert.ToInt32(Console.ReadLine()));
                                Console.WriteLine("resultado: {0}", quintapotencia.FuncaoQuadrado());
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("Aperte ENTER para voltar ao menu!");
                                Console.ReadLine();
                                tryAgain = false;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Por Favor Digite Apenas números inteiros!!!");
                                System.Threading.Thread.Sleep(1200);
                                Console.Clear();
                            }
                        }
                        break;

                    case 2:
                        tryAgain = true;
                        Console.Clear();
                        while (tryAgain)
                        {
                            try
                            {
                                velocidadeMediaVeiculo velocidademedia = new velocidadeMediaVeiculo();
                                Console.WriteLine("Qual o tempo gasto em (horas), *para 30m use 0.5:");
                                velocidademedia.tempoGastoEmHora = Convert.ToDouble(Console.ReadLine());

                                Console.WriteLine("Qual a distancia em (KM):");
                                velocidademedia.percurso = Convert.ToDouble(Console.ReadLine());

                                Console.WriteLine("resultado: {0}km/h", (velocidademedia.percurso / velocidademedia.tempoGastoEmHora));

                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("Aperte ENTER para voltar ao menu!");
                                Console.ReadLine();
                                tryAgain = false;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Por Favor Digite Apenas números inteiros!!!");
                                System.Threading.Thread.Sleep(1200);
                                Console.Clear();
                            }
                        }
                        break;

                    case 3:
                        tryAgain = true;
                        Console.Clear();
                        while (tryAgain)
                        {
                            try
                            {
                                int quantidadeVerificar;
                                Console.WriteLine("Quantos numeros você quer verificar?");
                                quantidadeVerificar = Convert.ToInt32(Console.ReadLine());
                                int[] array = new int[quantidadeVerificar];
                                for (int i = 0; i < array.Length; i++)
                                {
                                    Console.WriteLine("Digite o número({0})", i + 1);
                                    array[i] = Convert.ToInt32(Console.ReadLine());
                                }

                                mostrarNumerosNegativos numeroNegativo = new mostrarNumerosNegativos(array);
                                Console.Write("Quantidade de negativos: {0}", numeroNegativo.retornarQuantidadeNegativos());

                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("Aperte ENTER para voltar ao menu!");
                                Console.ReadLine();
                                tryAgain = false;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("deu merda");
                                Console.Clear();
                            }
                        }
                        break;

                    case 4:
                        Console.Clear();
                        int somaQuadradoEntre4E9 = 0;
                        int numeroQuadrado;
                        for (int i = 4; i < 9; i++)
                        {
                            numeroQuadrado = Convert.ToInt32(Math.Pow(i, 2));
                            Console.WriteLine("{0} ao quadrado={1}", i, numeroQuadrado);
                            somaQuadradoEntre4E9 = somaQuadradoEntre4E9 + numeroQuadrado;
                        }
                        Console.WriteLine("Soma de todos os Quadrados entre 3 e 9 ->: {0}", somaQuadradoEntre4E9);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Aperte ENTER para voltar ao menu!");
                        Console.ReadLine();
                        break;


                    case 5:
                        int somaAte77 = 0;
                        int valorLidoAte77 = 0;

                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Somatório total: {0}", somaAte77);
                            Console.WriteLine("Digite o Número a ser somado:");
                            Console.WriteLine("-1 para sair");

                            valorLidoAte77 = Convert.ToInt32(Console.ReadLine());

                            if (valorLidoAte77 != -1)
                            {
                                if (valorLidoAte77 <= 77)
                                {
                                    if (valorLidoAte77 + somaAte77 <= 77)
                                    {
                                        somaAte77 = somaAte77 + valorLidoAte77;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Essa soma ultrapassa 77 !");
                                        System.Threading.Thread.Sleep(1000);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Por Favor informar números menores que 77 !");
                                    System.Threading.Thread.Sleep(1000);

                                }
                            }

                        } while (valorLidoAte77 != -1);
                        if (somaAte77 == -1)
                            somaAte77 = 0;
                        Console.Clear();
                        Console.WriteLine("Somatório FINAL: {0}", somaAte77);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Aperte ENTER para voltar ao menu!");
                        Console.ReadLine();
                        break;

                    case 6:
                        tryAgain = true;
                        Console.Clear();
                        impostoValorCompras impostovalorcompras = new impostoValorCompras();
                        double valorCompras;

                        while (tryAgain)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            try
                            {
                                Console.WriteLine("Digite o valor das compras:");
                                valorCompras = Convert.ToDouble(Console.ReadLine());
                                var imposto = impostovalorcompras.retornarValorImposto(valorCompras);
                                Console.Clear();
                                Console.WriteLine("Valor Compra:{0}\nImposto de {1}%={2}", valorCompras, imposto.Item2, imposto.Item1);
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("Aperte ENTER para voltar ao menu!");
                                Console.ReadLine();
                                tryAgain = false;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Por Favor Digite Apenas números !!!");
                                Console.ForegroundColor = ConsoleColor.Blue;
                                try
                                {
                                    Console.WriteLine("Aperte ENTER para tentar novamente \n ou 0 para voltar ao menu!");
                                    int a = Convert.ToInt32(Console.ReadLine());
                                    break;
                                }
                                catch (Exception b)
                                {
                                    Console.Clear();
                                }
                            }
                        }
                        break;
                    case 7:
                        Console.Clear();
                        tryAgain = true;
                        while (tryAgain)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            try
                            {
                                int[] numeros4inteiros = new int[4];
                                int soma = 0;
                                for (int i = 0; i < 4; i++)
                                {
                                    Console.WriteLine("Digite numero[{0}]:", i + 1);
                                    numeros4inteiros[i] = Convert.ToInt32(Console.ReadLine());
                                    soma = soma + numeros4inteiros[i];
                                }
                                Console.WriteLine("Soma dos Números: {0}\nMaior deles:{1}", soma, numeros4inteiros.Max());
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("Aperte ENTER para voltar ao menu!");
                                Console.ReadLine();
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Por Favor Digite Apenas números !!!");
                                Console.ForegroundColor = ConsoleColor.Blue;
                                try
                                {
                                    Console.WriteLine("Aperte ENTER para tentar novamente \n ou 0 para voltar ao menu!");
                                    int a = Convert.ToInt32(Console.ReadLine());
                                    break;
                                }
                                catch (Exception b)
                                {
                                    Console.Clear();
                                }
                            }
                        }
                        break;
                    case 8:
                        Console.Clear();
                        double valorF;
                        Console.WriteLine("Qual a temperatura em Fahrenheit ?");
                        valorF = Convert.ToDouble(Console.ReadLine());
                        Console.Clear();
                        Console.WriteLine("{0}F é igual a {1:d4} Celsius", valorF, ((valorF - 32) * 5 / 9).ToString("0.00"));

                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Aperte ENTER para voltar ao menu!");
                        Console.ReadLine();
                        break;
                    case 9:
                        Console.Clear();
                        tryAgain = true;
                        List<char> listaChar = new List<char>();
                        int contador = 0;
                        bool sair = true;
                        do {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Clear();
                            Console.WriteLine("Pressione algum caractere ou j para parar:");
                            char valorLido = Console.ReadKey().KeyChar;
                            if (valorLido == 'j' || valorLido == 'J')
                                sair = false;
                            else
                            {
                                Console.Clear();
                                listaChar.Add(valorLido);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Inserido Com Sucesso!!");
                                System.Threading.Thread.Sleep(1200);
                            }
                        }
                        while (sair);

                        Console.Clear();
                        for (int i = 0; i < listaChar.Count; i++)
                        {
                            Console.Write("{0}  ", listaChar[i]);
                        }
                        Console.WriteLine("\n");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Aperte ENTER para voltar ao menu!");
                        Console.ReadLine();
                        break;
                    case 10:
                        Console.Clear();
                        List<double> listaNumeros = new List<double>();
                         bool resposta = true;
 
                        
                        do
                        {
                            double numeroparainserir;
                            try
                            {
                                Console.WriteLine("Digite o número que deseja inserir, ou uma letra para parar");
                                numeroparainserir = Convert.ToDouble(Console.ReadLine());
                                listaNumeros.Add(numeroparainserir);
                            }
                            catch
                            {
                                resposta = false;
                            }
                        } while (resposta);
                        int total = listaNumeros.Count;
                        for (int i = 0; i < total; i++)
                        {
                            Console.Write("{0} ", listaNumeros.Min());
                            listaNumeros.Remove(listaNumeros.Min());
                        }
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Aperte ENTER para voltar ao menu!");
                        Console.ReadLine();
                        break;

                    case 11:
                        Console.Clear();
                        double numero1;
                        double numero2;

                        Console.WriteLine("Digite o Primeiro número:");
                        numero1 = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("Digite o Segundo número:");
                        numero2 = Convert.ToDouble(Console.ReadLine());
                      
                        Console.WriteLine("Soma dos números:{0}\nO produto Do primeiro pelo quadrado do segundo:{1}\nO quadrado do Primeiro Numero:{2}\nRaiz quadrada da soma dos quadrados:{3}\n" +
                            "O seno da diferença do primeiro número pelo segundo:{4}\nO Modulo do primeiro Número:{5}", (numero1 + numero2), (numero1 * (Math.Pow(numero2, 2))), Math.Pow(numero1, 2), (numero1 + numero2),
                            Math.Sin(numero1 - numero2),(Math.Abs(numero1)));
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Aperte ENTER para voltar ao menu!");
                        Console.ReadLine();
                        break;
                    case 12:
                        Console.Clear();
                        string Palavra;
                        verificarString verificarstring = new verificarString();
                        Console.WriteLine("OBS: espaço conta como caractere =)");
                        Console.WriteLine("Digite alguma coisa:");
                        Palavra = Console.ReadLine();

                        Console.WriteLine("Número de caracteres: {0}\nNúmero de caracteres de Pontuação: {1}\nNúmero de caraceteres que são números: {2}", Palavra.Length, verificarstring.retornarQuantidadePontuacao(Palavra),
                            verificarstring.retornarQuantidadeNumeros(Palavra));
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Aperte ENTER para voltar ao menu!");
                        Console.ReadLine();
                        break;
                }
            }
            while (numeroExercicio!=0);


            
        }
    }
}
