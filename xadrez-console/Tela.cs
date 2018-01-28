using System;
using tabuleiro;

namespace xadrez_console
{
    class Tela
    {
        //imprimir o tabuleiro na tela
        public static void ImprimirTabuleiro(Tabuleiro tab)
        {
            for(int i = 0; i < tab.linhas; i++)
            {
                
                for (int j = 0; j < tab.colunas; j++)
                {
                    if (tab.peca(i,j) == null)
                    {
                        Console.Write("\t*" );
                    }
                    else
                    {
                        Console.Write("\t" + tab.peca(i, j) + " ");
                    }
                }
                    
                Console.WriteLine();
            }
        }
    }
}
