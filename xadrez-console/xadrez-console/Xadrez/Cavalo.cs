using tabuleiro;

namespace xadrez
{
    internal class Cavalo : Peca
    {
        public Cavalo(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }
        public bool PodeMover(Posicao pos)
        {
            Peca peca = Tab.Peca(pos);
            return peca == null || peca.Cor != Cor;
        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] matrizMovimentos = new bool[Tab.Linhas, Tab.Colunas];

            //teste// 
            Posicao posicao = new Posicao(0, 0);
            //Norte 
            posicao.DefinirValores(posicao.Linha - 1, posicao.Coluna);

            if (Tab.PosicaoValida(posicao) && PodeMover(posicao))
            {
                matrizMovimentos[posicao.Linha, posicao.Coluna] = true;
            }
            //Nordeste 
            posicao.DefinirValores(posicao.Linha - 1, posicao.Coluna + 1);

            if (Tab.PosicaoValida(posicao) && PodeMover(posicao))
            {
                matrizMovimentos[posicao.Linha, posicao.Coluna] = true;
            }
            //Leste
            posicao.DefinirValores(posicao.Linha, posicao.Coluna + 1);

            if (Tab.PosicaoValida(posicao) && PodeMover(posicao))
            {
                matrizMovimentos[posicao.Linha, posicao.Coluna] = true;
            }
            //Suldeste 
            posicao.DefinirValores(posicao.Linha + 1, posicao.Coluna + 1);

            if (Tab.PosicaoValida(posicao) && PodeMover(posicao))
            {
                matrizMovimentos[posicao.Linha, posicao.Coluna] = true;
            }
            //Sul
            posicao.DefinirValores(posicao.Linha + 1, posicao.Coluna);

            if (Tab.PosicaoValida(posicao) && PodeMover(posicao))
            {
                matrizMovimentos[posicao.Linha, posicao.Coluna] = true;
            }
            //Suldoeste
            posicao.DefinirValores(posicao.Linha + 1, posicao.Coluna - 1);

            if (Tab.PosicaoValida(posicao) && PodeMover(posicao))
            {
                matrizMovimentos[posicao.Linha, posicao.Coluna] = true;
            }
            //Oeste
            posicao.DefinirValores(posicao.Linha, posicao.Coluna - 1);

            if (Tab.PosicaoValida(posicao) && PodeMover(posicao))
            {
                matrizMovimentos[posicao.Linha, posicao.Coluna] = true;
            }
            //Noroeste
            posicao.DefinirValores(posicao.Linha - 1, posicao.Coluna - 1);

            if (Tab.PosicaoValida(posicao) && PodeMover(posicao))
            {
                matrizMovimentos[posicao.Linha, posicao.Coluna] = true;
            }
            return matrizMovimentos;
        }
        public override string ToString()
        {
            return "C";
        }
    }
}
