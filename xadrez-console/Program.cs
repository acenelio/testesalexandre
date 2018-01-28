using System;
using tabuleiro;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Posicao P = new Posicao(3, 4);
            Tabuleiro tab = new Tabuleiro(8,8);
            for(int i = 0; i < tab.colunas; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < tab.linhas; j++)
                {
                    Console.Write("\t*");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("\tPosição: " + P);
            Console.ReadLine();
        }
    }
}
