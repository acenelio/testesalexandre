using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tabuleiro
{
    class Tabuleiro
    {
        //atributos
        public int linhas { get; set; }
        public int colunas { get; set; }
        private Peca[,] pecas;

        //contrutor
        public Tabuleiro(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }

        //metodo para aceesar a matriz  peca, o atributo é private
        public Peca peca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }

        //colocar peça no tabuleiro
        public void ColocarPeca(Peca p, Posicao pos)
        {
            pecas[pos.linha, pos.coluna] = p;
            p.posicao = pos;

        }

    }
}
