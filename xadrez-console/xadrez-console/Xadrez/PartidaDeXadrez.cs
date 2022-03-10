using System;
using System.Collections.Generic;
using tabuleiro;

namespace xadrez
{
    internal class PartidaDeXadrez
    {
        public Tabuleiro Tab { get; set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }
        public bool Xeque { get; set; }

        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;

        public PartidaDeXadrez()
        {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            Xeque = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            ColocarPeca();
        }
        public Peca ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca peca = Tab.RetirarPeca(origem);
            peca.IncrementarQteMoviemntos();
            Peca pecaCapturada = Tab.RetirarPeca(destino);
            Tab.ColocarPeca(peca, destino);
            if (pecaCapturada != null)
            {
                capturadas.Add(pecaCapturada);
            }
            return pecaCapturada;
        }
        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = ExecutaMovimento(origem, destino);

            if (EstaEmXeque(JogadorAtual))
            {
                DesfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em xeque!");
            }
            else if (EstaEmXeque(Adversaria(JogadorAtual)))
            {
                Xeque = true;
            }
            else
            {
                Xeque = false;
            }
            if (TesteXequeMate(Adversaria(JogadorAtual)))
            {
                Terminada = true;
            }
            else
            {
                Turno++;
                MudaJogador();
            }
        }
        public void DesfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca peca = Tab.RetirarPeca(destino);
            peca.DecrementarQteMoviemntos();
            if (pecaCapturada != null)
            {
                Tab.ColocarPeca(pecaCapturada, destino);
                capturadas.Remove(pecaCapturada);
            }
            Tab.ColocarPeca(peca, origem);
        }
        private void MudaJogador()
        {
            if (JogadorAtual == Cor.Branca)
            {
                JogadorAtual = Cor.Preta;
            }
            else
            {
                JogadorAtual = Cor.Branca;
            }
        }
        public HashSet<Peca> PecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca peca in capturadas)
            {
                if (peca.Cor == cor)
                {
                    aux.Add(peca);
                }
            }
            return aux;
        }
        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca peca in pecas)
            {
                if (peca.Cor == cor)
                {
                    aux.Add(peca);
                }
            }
            aux.ExceptWith(PecasCapturadas(cor));//ExceptWith: função do c# para tirar um determinado padrão
            return aux;
        }
        public void ValidarPosicaoOrigem(Posicao posicao)
        {
            if (Tab.Peca(posicao) == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }
            if (JogadorAtual != Tab.Peca(posicao).Cor)
            {
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            }
            if (!Tab.Peca(posicao).ExisteMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
            }
        }

        public void ValidarPosicaoDestino(Posicao origem, Posicao destino)
        {
            if (!Tab.Peca(origem).PodeMoverPara(destino))
            {
                throw new TabuleiroException("Posição de destino inválida!");
            }
        }
        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            Tab.ColocarPeca(peca, new PosicaoDeXadrez(coluna, linha).toPosicao());
            pecas.Add(peca);
        }
        private Cor Adversaria(Cor cor)//branca
        {
            if (cor == Cor.Branca)
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
            foreach (Peca peca in PecasEmJogo(cor))
            {
                if (peca is Rei)
                {
                    return peca;
                }
            }
            return null;
        }
        public bool EstaEmXeque(Cor cor)
        {
            Peca rei = Rei(cor);
            if (rei == null)
            {
                throw new TabuleiroException("Não tem rei da cor " + cor + " no tabuleiro!");
            }
            foreach (Peca peca in PecasEmJogo(Adversaria(cor)))
            {
                bool[,] movimentosPossiveis = peca.MovimentosPossiveis();
                if (movimentosPossiveis[rei.Posicao.Linha, rei.Posicao.Coluna])
                {
                    return true;
                }
            }
            return false;
        }

        public bool TesteXequeMate(Cor cor)
        {
            if (!EstaEmXeque(cor))
            {
                return false;
            }
            foreach (Peca peca in PecasEmJogo(cor))
            {
                bool[,] movimentosPossiveis = peca.MovimentosPossiveis();
                for (int i = 0; i < Tab.Linhas; i++)
                {
                    for (int j = 0; j < Tab.Colunas; j++)
                    {
                        if (movimentosPossiveis[i, j])
                        {
                            Posicao origem = peca.Posicao;
                            Posicao destino = new Posicao(i, j);
                            Peca pecaCapturada = ExecutaMovimento(origem, destino);
                            bool testeXeque = EstaEmXeque(cor);
                            DesfazMovimento(origem, destino, pecaCapturada);
                            if (!testeXeque)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
        public void ColocarPeca()
        {



            ColocarNovaPeca('a', 8, new Rei(Tab, Cor.Preta));
            ColocarNovaPeca('b', 8, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('c', 1, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('h', 7, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('d', 1, new Rei(Tab, Cor.Branca));



            //    ColocarNovaPeca('a', 2, new Peao(Tab, Cor.Branca));
            //    ColocarNovaPeca('b', 2, new Peao(Tab, Cor.Branca));
            //    ColocarNovaPeca('c', 2, new Peao(Tab, Cor.Branca));
            //    ColocarNovaPeca('d', 2, new Peao(Tab, Cor.Branca));
            //    ColocarNovaPeca('e', 2, new Peao(Tab, Cor.Branca));
            //    ColocarNovaPeca('f', 2, new Peao(Tab, Cor.Branca));
            //    ColocarNovaPeca('g', 2, new Peao(Tab, Cor.Branca));
            //    ColocarNovaPeca('h', 2, new Peao(Tab, Cor.Branca));
            //    ColocarNovaPeca('a', 1, new Torre(Tab, Cor.Branca));
            //    ColocarNovaPeca('b', 1, new Cavalo(Tab, Cor.Branca));
            //    ColocarNovaPeca('c', 1, new Bispo(Tab, Cor.Branca));
            //    ColocarNovaPeca('d', 1, new Rei(Tab, Cor.Branca));
            //    ColocarNovaPeca('e', 1, new Dama(Tab, Cor.Branca));
            //    ColocarNovaPeca('f', 1, new Bispo(Tab, Cor.Branca));
            //    ColocarNovaPeca('g', 1, new Cavalo(Tab, Cor.Branca));
            //    ColocarNovaPeca('h', 1, new Torre(Tab, Cor.Branca));

            //    ColocarNovaPeca('a', 7, new Peao(Tab, Cor.Preta));
            //    ColocarNovaPeca('b', 7, new Peao(Tab, Cor.Preta));
            //    ColocarNovaPeca('c', 7, new Peao(Tab, Cor.Preta));
            //    ColocarNovaPeca('d', 7, new Peao(Tab, Cor.Preta));
            //    ColocarNovaPeca('e', 7, new Peao(Tab, Cor.Preta));
            //    ColocarNovaPeca('f', 7, new Peao(Tab, Cor.Preta));
            //    ColocarNovaPeca('g', 7, new Peao(Tab, Cor.Preta));
            //    ColocarNovaPeca('h', 7, new Peao(Tab, Cor.Preta));
            //    ColocarNovaPeca('a', 8, new Torre(Tab, Cor.Preta));
            //    ColocarNovaPeca('b', 8, new Cavalo(Tab, Cor.Preta));
            //    ColocarNovaPeca('c', 8, new Bispo(Tab, Cor.Preta));
            //    ColocarNovaPeca('d', 8, new Rei(Tab, Cor.Preta));
            //    ColocarNovaPeca('e', 8, new Dama(Tab, Cor.Preta));
            //    ColocarNovaPeca('f', 8, new Bispo(Tab, Cor.Preta));
            //    ColocarNovaPeca('g', 8, new Cavalo(Tab, Cor.Preta));
            //    ColocarNovaPeca('h', 8, new Torre(Tab, Cor.Preta));

        }
    }
}
