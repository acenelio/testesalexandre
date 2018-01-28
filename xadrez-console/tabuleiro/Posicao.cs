namespace tabuleiro
{
    class Posicao
    {
        //atributos
        public int linha { get; set; }
        public int coluna { get; set; }

        //Construtor
        public Posicao(int linha, int coluna)
        {
            this.linha = linha;
            this.coluna = coluna;
        }
        //metodo to string
        public override string ToString()
        {
            return  linha
                + ", "
                + coluna;
        }
    }
}
