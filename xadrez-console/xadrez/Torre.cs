using tabuleiro;
namespace xadrez
{ 
    class Torre : Peca
    {
        //construtor com a base da classe pai Peca
        public Torre(Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }

        //metodo to string
        public override string ToString()
        {
            return "T";
        }
    }
}
