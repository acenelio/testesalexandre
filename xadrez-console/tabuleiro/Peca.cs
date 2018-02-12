namespace tabuleiro
{
    abstract class Peca
    {
        //atributos
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qtemovimentos { get; protected set; }
        public Tabuleiro tab { get; protected set; }

        //construtor
        public Peca(Tabuleiro tab, Cor cor )
        {
            this.posicao = null;
            this.tab = tab;
            this.cor = cor;
            this.qtemovimentos = 0;
        }

        //incrementar movimentos
        public void IncrementarQteMovimentos()
        {
            qtemovimentos++;
        }

        //decrementar movimentos
        public void DecrementarQteMovimentos()
        {
            qtemovimentos--;
        }

        // testando movimentos posssiveis numa matriz
        public bool ExisteMovimentosPossiveis()
        {
            bool [,] mat = Movimentospossiveis();
            for (int i = 0; i < tab.linhas; i++)
            {
                for (int j = 0; j < tab.colunas; j++)
                {
                    if (mat[i, j]) {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool MovimentoPossivel(Posicao pos)
        {
            return Movimentospossiveis()[pos.linha, pos.coluna];
        }


        public abstract bool[,] Movimentospossiveis();
    }
}
