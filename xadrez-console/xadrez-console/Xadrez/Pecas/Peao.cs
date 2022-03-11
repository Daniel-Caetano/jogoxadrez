using tabuleiro;

namespace xadrez
{
    internal class Peao : Peca
    {
        private PartidaDeXadrez partida;
        public Peao(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor)
        {
            this.partida = partida;
        }
        public bool PodeMover(Posicao pos)
        {
            Peca peca = Tab.Peca(pos);
            return peca == null;
            //|| peca.Cor != Cor
        }
        private bool ExisteInimigo(Posicao pos)
        {
            Peca peca = Tab.Peca(pos);
            return peca != null && peca.Cor != Cor;
        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] matrizMovimentos = new bool[Tab.Linhas, Tab.Colunas];

            //Movimentação// 
            Posicao posicao = new Posicao(0, 0);
            if (Cor == Cor.Branca)
            {
                //Norte 
                posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);

                if (Tab.PosicaoValida(posicao) && PodeMover(posicao))
                {
                    matrizMovimentos[posicao.Linha, posicao.Coluna] = true;
                }
                //Nordeste 
                posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);

                if (Tab.PosicaoValida(posicao) && ExisteInimigo(posicao))
                {
                    matrizMovimentos[posicao.Linha, posicao.Coluna] = true;
                }
                //Noroeste
                posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);

                if (Tab.PosicaoValida(posicao) && ExisteInimigo(posicao))
                {
                    matrizMovimentos[posicao.Linha, posicao.Coluna] = true;
                }
                //Primeira jogada , andar 2 casas
                posicao.DefinirValores(Posicao.Linha - 2, Posicao.Coluna);
                if (Tab.PosicaoValida(posicao) && PodeMover(posicao) && QteMovimentos==0)
                {
                    matrizMovimentos[posicao.Linha, posicao.Coluna] = true;
                }

                //Jogada especial EN PASSANT
                if (Posicao.Linha == 3)
                {
                    Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    if (Tab.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && Tab.Peca(esquerda) == partida.VulneravelEmPassant)
                    {
                        matrizMovimentos[esquerda.Linha-1, esquerda.Coluna] = true;
                    }
                    else
                    {
                        Posicao direita = new Posicao(Posicao.Linha+1, Posicao.Coluna + 1);
                        if (Tab.PosicaoValida(direita) && ExisteInimigo(direita) && Tab.Peca(direita) == partida.VulneravelEmPassant)
                        {
                            matrizMovimentos[direita.Linha-1, direita.Coluna] = true;
                        }
                    }
                }
            }
            else
            {
                //Sul
                posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);

                if (Tab.PosicaoValida(posicao) && PodeMover(posicao))
                {
                    matrizMovimentos[posicao.Linha, posicao.Coluna] = true;
                }
                //Suldeste 
                posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);

                if (Tab.PosicaoValida(posicao) && ExisteInimigo(posicao))
                {
                    matrizMovimentos[posicao.Linha, posicao.Coluna] = true;
                }
                //Suldoeste
                posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);

                if (Tab.PosicaoValida(posicao) && ExisteInimigo(posicao))
                {
                    matrizMovimentos[posicao.Linha, posicao.Coluna] = true;
                }
                //Primeira jogada , andar 2 casas
                posicao.DefinirValores(Posicao.Linha + 2, Posicao.Coluna);
                if (Tab.PosicaoValida(posicao) && PodeMover(posicao) && QteMovimentos == 0)
                {
                    matrizMovimentos[posicao.Linha, posicao.Coluna] = true;
                }

                //Jogada especial EN PASSANT
                if (Posicao.Linha == 4)
                {
                    Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    if (Tab.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && Tab.Peca(esquerda) == partida.VulneravelEmPassant)
                    {
                        matrizMovimentos[esquerda.Linha+1, esquerda.Coluna] = true;
                    }
                    else
                    {
                        Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                        if (Tab.PosicaoValida(direita) && ExisteInimigo(direita) && Tab.Peca(direita) == partida.VulneravelEmPassant)
                        {
                            matrizMovimentos[direita.Linha+1, direita.Coluna] = true;
                        }
                    }
                }
            }
            //Fim movimentação
            return matrizMovimentos;
        }
        public override string ToString()
        {
            return "P";
        }
    }
}
