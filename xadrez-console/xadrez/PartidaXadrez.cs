using System.Collections.Generic;
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
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;
        public bool xeque { get; private set; }

        //construtor
        public PartidaXadrez()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            terminada = false;
            xeque = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            ColocarPecas();
        }

        //executar movimento com as peças
        public Peca ExecutaMovimentos(Posicao origem, Posicao destino)
        {
            Peca p = tab.RetirarPeca(origem);
            p.IncrementarQteMovimentos();
            Peca pecaCapturada = tab.RetirarPeca(destino);
            tab.ColocarPeca(p, destino);
            if (pecaCapturada != null)
            {
                capturadas.Add(pecaCapturada);
            }
            return pecaCapturada;
        }

        public void RealizaJogadas(Posicao origem, Posicao destino)
        {
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            
            Peca pecaCapturada = ExecutaMovimentos(origem, destino);
            if(EstarEmXeque(jogadorAtual))
            {
                DefazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("\tVocê não pode ser colocar em cheque!");
            }
            if(EstarEmXeque(Adversaria (jogadorAtual)))
            {
                xeque = true;
            }
            else
            {
                xeque = false;
            }
            Console.ForegroundColor = aux;

            turno++;
            MudaJogador();
        }


        public void DefazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca p = tab.RetirarPeca(destino);
            p.DecrementarQteMovimentos();
            if(pecaCapturada != null)
            {
                tab.ColocarPeca(pecaCapturada, destino);
                capturadas.Remove(pecaCapturada);
            }
            tab.ColocarPeca(p, origem);
        }



        public void ValidarPosicaoOrigem(Posicao pos)
        {
            if (tab.peca(pos) == null)
            {
                throw new TabuleiroException("\tNão existe peça na posição escolhida!");
            }
            if (jogadorAtual != tab.peca(pos).cor)
            {
                throw new TabuleiroException("\tA peça na posição escolhida não é sua!");
            }
            if (!tab.peca(pos).ExisteMovimentosPossiveis())
            {
                throw new TabuleiroException("\tNão há movimentos possiveis na peça de origem escolhida!");
            }
        }

        public void ValidarPosicaoDestino(Posicao origem, Posicao destino)
        {
            if (!tab.peca(origem).PodeMoverPara(destino))
            {
                throw new TabuleiroException("\tPosição de destino inválida!");
            }
        }


        private void MudaJogador()
        {
            if (jogadorAtual == Cor.Branca)
            {
                jogadorAtual = Cor.Preta;
            }
            else
            {
                jogadorAtual = Cor.Branca;
            }
        }

        //peças capturadas de uma determinada cor
        public HashSet<Peca> PecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in capturadas)
            {
                if(x.cor == cor)
                {
                    aux.Add(x);
                }

            }
            return aux;
        }

        //peças em jogo de uma determinada cor
        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in pecas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }

            }
            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
        }

        //validadndo a cor das peças em jogo
        private Cor Adversaria(Cor cor)
        {
            if(cor == Cor.Branca)
            {
                return Cor.Preta;
            }
            else
            {
                return Cor.Branca;
            }

        }

        private Peca Rei(Cor cor)
        {
            foreach(Peca x in PecasEmJogo(cor))
            {
                if (x is Rei)
                {
                    return x;
                }
            }

            return null;
        }

        public bool EstarEmXeque(Cor cor)
        {
            Peca R = Rei(cor);
            if (R == null)
            {
                throw new TabuleiroException("Não tem da cor " + cor + " bo tabuleiro!");
            }
            foreach(Peca x in PecasEmJogo(Adversaria(cor)))
            {
                bool[,] mat = x.Movimentospossiveis();
                if(mat[R.posicao.linha,R.posicao.coluna])
                {
                    return true;
                }
            }
            return false;
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            tab.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            pecas.Add(peca);
        }


        private void ColocarPecas()
        {
            ColocarNovaPeca('a', 1, new Torre(tab, Cor.Branca));
            ColocarNovaPeca('h', 1, new Torre(tab, Cor.Branca));
            ColocarNovaPeca('e', 1, new Rei(tab, Cor.Branca));

            ColocarNovaPeca('a', 8, new Torre(tab, Cor.Preta));
            ColocarNovaPeca('h', 8, new Torre(tab, Cor.Preta));
            ColocarNovaPeca('e', 8, new Rei(tab, Cor.Preta));
        }
    }
}
