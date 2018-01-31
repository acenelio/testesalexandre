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
                    if (tab.peca(i,j) == null)
                    {
                        Console.Write("\t*" );
                    }
                    else
                    {
                        ImprimirPeca(tab.peca(i, j));
                        Console.Write("");
                    }
                }
                    
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t\ta\tb\tc\td\te\tf\tg\th");
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

            if (peca.cor == Cor.Branca)
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\t" + peca);
                Console.ForegroundColor = aux;
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\t" + peca);
                Console.ForegroundColor = aux;
            }

        }
    }
}
