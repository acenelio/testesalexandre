using tabuleiro;
namespace xadrez
{
    class PosicaoXadrez
    {
        //atributos
        public char coluna { get; set; }
        public int linha { get; set; }

        //construtor

        public PosicaoXadrez(char coluna, int linha)
        {
            this.coluna = coluna;
            this.linha = linha;

        }

        //converter as posições da matriz para as posições do xadrez
        public Posicao toPosicao()
        {
            return new Posicao(8 - linha, coluna - 'a');
        }


        //metodo para imprimir personalizado
        public override string ToString()
        {
            return " " + coluna + linha;
        }


    }
}
