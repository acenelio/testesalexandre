using tabuleiro;
namespace xadrez
{
    class Cavalo : Peca

    {
        public Cavalo(Tabuleiro tab, Cor cor) : base( tab,  cor)
        {
            
        }

        public override string ToString()
        {
            return "C";
        }

        //testando se pode mover
        private bool PodeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p == null || p.cor != this.cor;
        }

        public override bool[,] Movimentospossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];
            Posicao pos = new Posicao(0, 0);

            //implementar movimentos
            pos.DefinirValores(posicao.linha - 1, posicao.coluna - 2);
            if(tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha,pos.coluna] = true;
            }

            pos.DefinirValores(posicao.linha - 2, posicao.coluna - 1);
            if (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            pos.DefinirValores(posicao.linha - 2, posicao.coluna + 1);
            if (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            pos.DefinirValores(posicao.linha - 1, posicao.coluna + 2);
            if (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            pos.DefinirValores(posicao.linha + 1, posicao.coluna + 2);
            if (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            pos.DefinirValores(posicao.linha + 2, posicao.coluna + 1);
            if (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            pos.DefinirValores(posicao.linha + 2, posicao.coluna - 1);
            if (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            pos.DefinirValores(posicao.linha + 1, posicao.coluna - 2);
            if (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }


            return mat;
        }

        
    }
}
