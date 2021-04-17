using System;

namespace PraticandoDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            var somaDelegate = new ExecutaCalculo(Soma);

            Console.WriteLine("Soma usando delegates " + somaDelegate(5, 9));

            //aplicando a regra de seleção
            int[] vetorDeInteiros = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Func<int, bool> selecaoPar = (x) => x % 2 == 0;
            Func<int, bool> selecaoImpar = (x) => x % 2 != 0;


            ImprimeResultado(vetorDeInteiros, selecaoPar);
            Console.WriteLine("");
            ImprimeResultado(vetorDeInteiros, selecaoImpar);
            Console.WriteLine("\nPassando a regra para uma outra função que retorna uma função");
            ImprimeResultado(vetorDeInteiros, RetornaFunc("Par"));
            Console.WriteLine("\nPassando a regra para uma outra função que retorna uma função");
            ImprimeResultado(vetorDeInteiros, RetornaFunc("Aqui ele vai cair no ímpar"));

            Console.ReadKey();

        }

        public delegate int ExecutaCalculo(int a, int b);

        public static int Soma(int a, int b)
        {
            return a + b;
        }



        public static void ImprimeResultado(int[] vetorDeInteiros, Func<int, bool> selecao)
        {
            for (int i = 0; i < vetorDeInteiros.Length; i++)
            {
                if (selecao(vetorDeInteiros[i]))
                {
                    Console.Write(vetorDeInteiros[i] + " - ");
                }
            }
        }

        //recebe uma regra e retorna a função com o lambda
        //se passar qualquer coisa que não seja "Par" vai retornar o ímpar
        public static Func<int, bool> RetornaFunc(string regra)
        {
            Func<int, bool> selecao;
            if (regra == "Par")
            {
                selecao = (x) => x % 2 == 0;
            }
            else
            {
                selecao = (x) => x % 2 != 0;
            }
            return selecao;
        }
    }
}

