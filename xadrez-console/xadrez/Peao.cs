using tabuleiro;
namespace xadrez
{
    class Peao : Peca
    {
        private PartidaXadrez partida;
        public Peao (Tabuleiro tab, Cor cor, PartidaXadrez partida) : base(tab,cor)
        {
            this.partida = partida;
        }

        public override string ToString()
        {
            return "P";
        }

        private bool ExisteInimigo(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p != null && p.cor != this.cor;
        }

        private bool Livre(Posicao pos)
        {
            return tab.peca(pos) == null;
        }

        public bool PodeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p == null || p.cor != this.cor;
           
        }

        public override bool[,] Movimentospossiveis()
        {
            Posicao pos = new Posicao(0,0);
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            //implementar movimentos Peão
            if(cor == Cor.Branca)
            {
                //# jogada en passant
                if (pos.linha == 3)
                {
                    Posicao esquerda = new Posicao(pos.linha, pos.coluna - 1);

                    if (tab.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && tab.peca(esquerda) == partida.VuneravelEnPassant)
                    {
                        mat[esquerda.linha - 1, esquerda.coluna] = true;
                    }

                    Posicao direita = new Posicao(pos.linha, pos.coluna + 1);

                    if (tab.PosicaoValida(direita) && ExisteInimigo(direita) && tab.peca(direita) == partida.VuneravelEnPassant)
                    {
                        mat[direita.linha - 1, direita.coluna] = true;
                    }
                }


                pos.DefinirValores(posicao.linha - 1, posicao.coluna);
                if(tab.PosicaoValida(pos) && Livre(pos))
                {
                    mat[pos.linha,pos.coluna] = true;
                }

                pos.DefinirValores(posicao.linha - 2, posicao.coluna);
                if (tab.PosicaoValida(pos) && Livre(pos) && qtemovimentos == 0)
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                pos.DefinirValores(posicao.linha - 1, posicao.coluna -1);
                if (tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                pos.DefinirValores(posicao.linha - 1, posicao.coluna + 1);
                if (tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                

            }
            else
            {
                //# jogada en passant
                if (pos.linha == 4)
                {
                    Posicao esquerda = new Posicao(pos.linha, pos.coluna - 1);

                    if (tab.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && tab.peca(esquerda) == partida.VuneravelEnPassant)
                    {
                        mat[esquerda.linha + 1, esquerda.coluna] = true;
                    }

                    Posicao direita = new Posicao(pos.linha, pos.coluna + 1);

                    if (tab.PosicaoValida(direita) && ExisteInimigo(direita) && tab.peca(direita) == partida.VuneravelEnPassant)
                    {
                        mat[direita.linha + 1, direita.coluna] = true;
                    }
                }

                //Movimentos normais
                pos.DefinirValores(posicao.linha + 1, posicao.coluna);
                if (tab.PosicaoValida(pos) && Livre(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                pos.DefinirValores(posicao.linha + 2, posicao.coluna);
                if (tab.PosicaoValida(pos) && Livre(pos) && qtemovimentos == 0)
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                pos.DefinirValores(posicao.linha + 1, posicao.coluna - 1);
                if (tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                pos.DefinirValores(posicao.linha + 1, posicao.coluna + 1);
                if (tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                

            }

            return mat;
        }
    }
}
