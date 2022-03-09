using tabuleiro;

namespace xadrez
{
    internal class Peao : Peca
    {
        public Peao(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }
        public bool PodeMover(Posicao pos)
        {
            Peca peca = Tab.Peca(pos);
            return peca == null;
            //|| peca.Cor != Cor
        }
        public bool PodeMoverVertical(Posicao pos)
        {
            Peca peca = Tab.Peca(pos);
            return peca != null && peca.Cor != Cor;
            //|| peca.Cor != Cor
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

                if (Tab.PosicaoValida(posicao) && PodeMoverVertical(posicao))
                {
                    matrizMovimentos[posicao.Linha, posicao.Coluna] = true;
                }
                //Noroeste
                posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);

                if (Tab.PosicaoValida(posicao) && PodeMoverVertical(posicao))
                {
                    matrizMovimentos[posicao.Linha, posicao.Coluna] = true;
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

                if (Tab.PosicaoValida(posicao) && PodeMoverVertical(posicao))
                {
                    matrizMovimentos[posicao.Linha, posicao.Coluna] = true;
                }
                //Suldoeste
                posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);

                if (Tab.PosicaoValida(posicao) && PodeMoverVertical(posicao))
                {
                    matrizMovimentos[posicao.Linha, posicao.Coluna] = true;
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
