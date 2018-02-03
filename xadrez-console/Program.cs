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
            PartidaXadrez partida = new PartidaXadrez();
            
			//loop principal do jogo
			while (!partida.terminada)
			{
                try
				{
                    Console.Clear();

                    //titulo
                    Tela.Titulo();

                    //imprimindo tabuleiro
                    Tela.ImprimirTabuleiro(partida.tab);
                    Console.WriteLine();
                    Console.WriteLine("\tTurno: " + partida.turno);
                    Console.WriteLine("\tAguardando Jogada das peças " + partida.jogadorAtual + "!");

					//entradas do jogador, movimenta a peça a partir da origem
					Console.Write("\tDigite a origem: ");
					Posicao origem = Tela.LerPosicaoXadrez().toPosicao();
					partida.ValidarPosicaoOrigem(origem);

					bool[,] PosicoesPossiveis = partida.tab.peca(origem).Movimentospossiveis();

					Console.Clear();
					Tela.Titulo();
					Tela.ImprimirTabuleiro(partida.tab, PosicoesPossiveis);
					Console.WriteLine();

					//entradas do jogador, movimenta a peça para o destino
					Console.Write("\tDigite o destino: ");
					Posicao destino = Tela.LerPosicaoXadrez().toPosicao();
					partida.ValidarPosicaoDestino(origem, destino);
						
					// se tudo acima estiver dentro das regras executa a função abaixo
					partida.RealizaJogadas(origem, destino);
				}

                catch (TabuleiroException e)
				{
                    Console.WriteLine(e.Message);
					Console.Write("\tTecle enter para continuar... ");
					Console.ReadLine();
				}
				catch (Exception e)
				{
					Console.WriteLine("\tErro inesperado: " + e.Message);
					Console.ReadLine();
				}

				//Console.Write("\t");
				//Console.ReadLine();
			}
            
            
        }
    }
}
