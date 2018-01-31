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
        public Peca peca(Posicao pos)
        {
            return pecas[pos.linha, pos.coluna];
        }

        //validar se existe peça colocada na posição
        public bool ExistePeca(Posicao pos)
        {
            ValidarPosicao(pos);
            return peca(pos) != null;

        }

        //colocar peça no tabuleiro
        public void ColocarPeca(Peca p, Posicao pos)
        {
            if (ExistePeca(pos))
            {
                throw new TabuleiroException("\tJá existe uma peça nessa posição!");
            }

            pecas[pos.linha, pos.coluna] = p;
            p.posicao = pos;

        }

        //retirar peça no tabuleiro
        public Peca RetirarPeca(Posicao pos)
        {
           if(peca(pos) == null)
            {
                return null;
            }

            Peca aux = peca(pos);
            aux.posicao = null;
            pecas[pos.linha, pos.coluna] = null;
            return aux;
        }


        //validando se a posição existe
        public bool PosicaoValida(Posicao pos)
        {
            if(pos.linha < 0 || pos.linha >= linhas || pos.coluna < 0 || pos.coluna >= colunas)
            {
                return false;
            }
            return true;
        }
        // criando uma excessão de tratamento pra validar posições de peças
        public void ValidarPosicao(Posicao pos)
        {
            if(!PosicaoValida(pos))
            {
                throw new TabuleiroException("\tPosição inválida!");
            }
        }


    }
}
