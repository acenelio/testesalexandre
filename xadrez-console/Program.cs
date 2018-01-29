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

            try
            {
                //colocando peças
                tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 0));
                tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 7));
                tab.ColocarPeca(new Rei(tab, Cor.Preta), new Posicao(0, 4));

                Console.Write("\tDigite uma posição para a linha: ");
                int linha = int.Parse(Console.ReadLine());
                Console.Write("\tDigite uma posição para a Coluna: ");
                int coluna = int.Parse(Console.ReadLine());
                tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(linha, coluna));

                //funções
                Console.WriteLine();
                Tela.ImprimirTabuleiro(tab);

                //testes
                Console.WriteLine();
                Console.WriteLine("\tPosição: " + P);
                PosicaoXadrez pos = new PosicaoXadrez('a', 1);
                Console.WriteLine("\tPosição: " + pos);
                Console.Write("\tPosição: " + pos.toPosicao());

                Console.ReadLine();
            }
            catch(TabuleiroException e)
            {
                Console.WriteLine("\tErro inesperado: " + e.Message);
                Console.ReadLine();
            }
            catch(Exception e)
            {
                Console.WriteLine("\tErro inesperado: " + e.Message);
                Console.ReadLine();
            }
        }
    }
}
