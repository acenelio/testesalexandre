using System;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Tela
    {
        //titulo
        public static void Titulo()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine("\t=================================================================");
            Console.WriteLine("\t|                   JOGO DE XADREZ CONSOLE                      |");
            Console.WriteLine("\t=================================================================");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }


        //imprimir o tabuleiro na tela 
        public static void ImprimirTabuleiro(Tabuleiro tab)
        {
            for(int i = 0; i < tab.linhas; i++)
            {
                Console.Write("\t" + (8 - i) + " ");

                for (int j = 0; j < tab.colunas; j++)
                {
                    ImprimirPeca(tab.peca(i,j));
                }
                    
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("\t   a  b  c  d  e  f  g  h ");
            
        }
        //imprimir o tabuleiro na tela +1 sobrecarga
        public static void ImprimirTabuleiro(Tabuleiro tab, bool [,] PosicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write("\t" + (8 - i) + " ");

                for (int j = 0; j < tab.colunas; j++)
                {
                    if (PosicoesPossiveis[i,j])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    ImprimirPeca(tab.peca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }

                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("\t   a  b  c  d  e  f  g  h ");
            Console.BackgroundColor = fundoOriginal;
        }

        //entradas do jogador
        public static PosicaoXadrez  LerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha); 
        }

        public static void ImprimirPeca(Peca peca)
        {
            if (peca == null)
            {
                Console.Write(" * ");
            }

            else
            {

                if (peca.cor == Cor.Branca)
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(" " + peca + " ");
                    Console.ForegroundColor = aux;
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(" " + peca + " ");
                    Console.ForegroundColor = aux;
                }
                Console.Write("");
            }
        }
    }
}
