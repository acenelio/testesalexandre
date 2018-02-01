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

        public abstract bool[,] Movimentospossiveis();
    }
}
