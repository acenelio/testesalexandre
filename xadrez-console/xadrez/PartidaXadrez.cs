using System;
using tabuleiro;
namespace xadrez
{
    class PartidaXadrez
    {
        //atributos
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }

        //construtor
        public PartidaXadrez()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            terminada = false;
            ColocarPecas();
        }

        //executar movimento com as peças
        public void ExecutaMovimentos(Posicao origem, Posicao destino)
        {
            Peca p = tab.RetirarPeca(origem);
            p.IncrementarQteMovimentos();
            Peca pecaCapturada = tab.RetirarPeca(destino);
            tab.ColocarPeca(p, destino);   
        }

        public void RealizaJogadas(Posicao origem, Posicao destino)
        {
            ExecutaMovimentos(origem, destino);
            turno++;
            MudaJogador();

        }

        public void ValidarPosicaoOrigem(Posicao pos)
        {
            if (tab.peca(pos) == null)
            {
                throw new TabuleiroException("\tNão existe peça na posição escolhida!");
            }
            if (jogadorAtual != tab.peca(pos).cor )
            {
                throw new TabuleiroException ("\tA peça na posição escolhida não é sua!");
            }
            if (!tab.peca(pos).ExisteMovimentosPossiveis ())
            {
                throw new TabuleiroException("\tNão há movimentos possiveis na peça de origem escolhida!");
            }
        }

        public void ValidarPosicaoDestino(Posicao origem, Posicao destino)
        {
            if(!tab.peca(origem).PodeMoverPara(destino))
            {
                throw new TabuleiroException("\tPosição de destino inválida!");
            }
        }


        private void MudaJogador()
        {
            if(jogadorAtual == Cor.Branca)
            {
                jogadorAtual = Cor.Preta;
            }
            else
            {
                jogadorAtual = Cor.Branca;
            }
        }

        private void ColocarPecas()
        {
            tab.ColocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('a', 1).toPosicao());
            tab.ColocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('a', 8).toPosicao());
            tab.ColocarPeca(new Rei(tab, Cor.Preta), new PosicaoXadrez('d', 8).toPosicao());
            tab.ColocarPeca(new Rei(tab, Cor.Branca), new PosicaoXadrez('d', 1).toPosicao());
        }
    }
}
