using System;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Posicao P = new Posicao(3, 4);
            Tabuleiro tab = new Tabuleiro(8,8);

            try
            {
                PartidaXadrez partida = new PartidaXadrez();

                //loop principal do jogo
                while (!partida.terminada)
                {
                    Console.Clear();

                    //titulo
                    Tela.Titulo();
                    
                    //imprimindo tabuleiro
                    Tela.ImprimirTabuleiro(partida.tab);
                    Console.WriteLine();
                    
                    //entradas do jogador, movimenta a peça a partir da origem
                    Console.Write("\tDigite a origem: ");
                    Posicao origem = Tela.LerPosicaoXadrez().toPosicao();

                    bool[,] PosicoesPossiveis = partida.tab.peca(origem).Movimentospossiveis();

                    Console.Clear();
                    Tela.Titulo();
                    Tela.ImprimirTabuleiro(partida.tab,PosicoesPossiveis);
                    Console.WriteLine();

                    //entradas do jogador, movimenta a peça para o destino
                    Console.Write("\tDigite o destino: ");
                    Posicao destino = Tela.LerPosicaoXadrez().toPosicao();
                    partida.ExecutaMovimentos(origem, destino);


                    //Console.Write("\t");
                    //Console.ReadLine();
                }
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
