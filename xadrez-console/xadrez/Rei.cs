using tabuleiro;

namespace xadrez
{
    class Rei : Peca
    {
        //construtor com a base da classe pai Peca
        public Rei(Tabuleiro tab, Cor cor) : base (tab, cor)
        {

        }

        //metodo to string
        public override string ToString()
        {
            return "R";
        }
    }
}
