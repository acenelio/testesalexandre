using tabuleiro;

namespace xadrez
{
    class Rei : Peca
    {
        //construtor com a base da classe pai Peca
        public Rei(Tabuleiro tab, Cor cor) : base (tab, cor)
        {

        }

        //testando se pode mover
        private bool PodeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p == null || p.cor != this.cor;
        }

        //definindo a movimentação de uma peça específica
        public override bool[,] Movimentospossiveis()
        {
            bool[,] mat = new bool [tab.linhas,tab.colunas];
            Posicao pos = new Posicao(0,0);

            //Movimentospossiveis do Rei

            //acima
            pos.DefinirValores(posicao.linha - 1, posicao.coluna);
            if(tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //nordeste
            pos.DefinirValores(posicao.linha - 1, posicao.coluna + 1);
            if (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //direita
            pos.DefinirValores(posicao.linha, posicao.coluna + 1);
            if (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //sudeste
            pos.DefinirValores(posicao.linha + 1, posicao.coluna +1);
            if (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //abaixo
            pos.DefinirValores(posicao.linha + 1, posicao.coluna);
            if (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //sudoeste
            pos.DefinirValores(posicao.linha + 1, posicao.coluna -1);
            if (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            //esquerda
            pos.DefinirValores(posicao.linha, posicao.coluna -1);
            if (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //noroeste
            pos.DefinirValores(posicao.linha - 1, posicao.coluna -1);
            if (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            return mat;
        }

        //metodo to string
        public override string ToString()
        {
            return "R";
        }
    }
}
