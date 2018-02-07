using tabuleiro;

namespace xadrez
{
    class Rei : Peca
    {
        private PartidaXadrez partida;

        //construtor com a base da classe pai Peca
        public Rei(Tabuleiro tab, Cor cor, PartidaXadrez partida) : base (tab, cor)
        {
            this.partida = partida;

        }

        //testando se pode mover
        private bool PodeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p == null || p.cor != this.cor;
        }

        //testando jogada para roque
        private bool TesteTorreParaRoque(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p != null && p is Torre && p.cor == this.cor && p.qtemovimentos == 0;
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

            //jogada especial roque
            if(qtemovimentos == 0 && !partida.xeque)
            {
                // #jogada roque pequeno
                Posicao posT1 = new Posicao(posicao.linha, posicao.coluna + 3);
                if(TesteTorreParaRoque(posT1))
                {
                    Posicao p1 = new Posicao(posicao.linha, posicao.coluna + 1);
                    Posicao p2 = new Posicao(posicao.linha, posicao.coluna + 2);
                    if(tab.peca(p1) == null && tab.peca(p2) == null)
                    {
                        mat[posicao.linha, posicao.coluna + 2] = true;
                    }
                }

                // #jogada roque Grande
                Posicao posT2 = new Posicao(posicao.linha, posicao.coluna - 4);
                if (TesteTorreParaRoque(posT2))
                {
                    Posicao p1 = new Posicao(posicao.linha, posicao.coluna - 1);
                    Posicao p2 = new Posicao(posicao.linha, posicao.coluna - 2);
                    Posicao p3 = new Posicao(posicao.linha, posicao.coluna - 3);
                    if (tab.peca(p1) == null && tab.peca(p2) == null && tab.peca(p3) == null)
                    {
                        mat[posicao.linha, posicao.coluna - 2] = true;
                    }
                }
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
