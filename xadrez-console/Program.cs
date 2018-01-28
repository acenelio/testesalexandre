using System;
using tabuleiro;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            //variaveis e clsses
            Posicao P = new Posicao(3, 4);
            Tabuleiro tab = new Tabuleiro(8,8);

            //funções
            Console.WriteLine();
            Tela.ImprimirTabuleiro(tab);

            //testes
            Console.WriteLine();
            Console.WriteLine("\tPosição: " + P);
            Console.ReadLine();
        }
    }
}
