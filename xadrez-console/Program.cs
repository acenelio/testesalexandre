using System;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            //variaveis e clsses
            Posicao P = new Posicao(3, 4);
            Tabuleiro tab = new Tabuleiro(8,8);

            //colocando peças
            tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(0,0));
            tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 7));
            tab.ColocarPeca(new Rei(tab, Cor.Preta), new Posicao(0, 4));


            //funções
            Console.WriteLine();
            Tela.ImprimirTabuleiro(tab);

            //testes
            Console.WriteLine();
            Console.Write("\tPosição: " + P);
            Console.ReadLine();
        }
    }
}
