using tabuleiro;

namespace xadrez
{
    internal class Rei : Peca
    {
        public Rei(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }
        public bool PodeMover(Posicao pos)
        {
            Peca peca = Tab.Peca(pos);
            return (peca == null || peca.Cor != Cor);
        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] matrizMovimentos = new bool[Tab.Linhas, Tab.Colunas];

            //teste// 
            Posicao posicao = new Posicao(0, 0);
            //Norte 
            posicao.DefinirValores(Posicao.Linha-1, Posicao.Coluna);
            
            if( Tab.PosicaoValida(posicao) && PodeMover(posicao) )
            {
                matrizMovimentos[posicao.Linha,posicao.Coluna] = true;
            }
            //Nordeste 
            posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna+1);

            if (Tab.PosicaoValida(posicao) && PodeMover(posicao))
            {
                matrizMovimentos[posicao.Linha, posicao.Coluna] = true;
            }
            //Leste
            posicao.DefinirValores(Posicao.Linha , Posicao.Coluna + 1);

            if (Tab.PosicaoValida(posicao) && PodeMover(posicao))
            {
                matrizMovimentos[posicao.Linha, posicao.Coluna] = true;
            }
            //Suldeste 
            posicao.DefinirValores(Posicao.Linha+1, Posicao.Coluna + 1);

            if (Tab.PosicaoValida(posicao) && PodeMover(posicao))
            {
                matrizMovimentos[posicao.Linha, posicao.Coluna] = true;
            }
            //Sul
            posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);

            if (Tab.PosicaoValida(posicao) && PodeMover(posicao))
            {
                matrizMovimentos[posicao.Linha, posicao.Coluna] = true;
            }
            //Suldoeste
            posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);

            if (Tab.PosicaoValida(posicao) && PodeMover(posicao))
            {
                matrizMovimentos[posicao.Linha, posicao.Coluna] = true;
            }
            //Oeste
            posicao.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);

            if (Tab.PosicaoValida(posicao) && PodeMover(posicao))
            {
                matrizMovimentos[posicao.Linha, posicao.Coluna] = true;
            }            
            //Noroeste
            posicao.DefinirValores(Posicao.Linha-1, Posicao.Coluna - 1);

            if (Tab.PosicaoValida(posicao) && PodeMover(posicao))
            {
                matrizMovimentos[posicao.Linha, posicao.Coluna] = true;
            }
            return matrizMovimentos;
        }
        public override string ToString()
        {
            return "R";
        }
    }
}
