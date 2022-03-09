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

            //Movimentação// 
            Posicao posicao = new Posicao(0, 0);

            //Norte curto Leste longo 1
            posicao.DefinirValores(Posicao.Linha - 1 , Posicao.Coluna + 2);
            if (Tab.PosicaoValida(posicao) && PodeMover(posicao))
            {
                matrizMovimentos[posicao.Linha, posicao.Coluna] = true;
            }
            //Norte longo Leste curto 2
            posicao.DefinirValores(Posicao.Linha - 2, Posicao.Coluna + 1);
            if (Tab.PosicaoValida(posicao) && PodeMover(posicao))
            {
                matrizMovimentos[posicao.Linha, posicao.Coluna] = true;
            }
            //Norte curto Oeste longo 3
            posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 2);
            if (Tab.PosicaoValida(posicao) && PodeMover(posicao))
            {
                matrizMovimentos[posicao.Linha, posicao.Coluna] = true;
            }
            //Norte longo Oeste curto 4
            posicao.DefinirValores(Posicao.Linha - 2, Posicao.Coluna - 1);
            if (Tab.PosicaoValida(posicao) && PodeMover(posicao))
            {
                matrizMovimentos[posicao.Linha, posicao.Coluna] = true;
            }
            //Sul curto Leste longo 5
            posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 2);
            if (Tab.PosicaoValida(posicao) && PodeMover(posicao))
            {
                matrizMovimentos[posicao.Linha, posicao.Coluna] = true;
            }
            //Sul longo Leste curto 6
            posicao.DefinirValores(Posicao.Linha + 2, Posicao.Coluna + 1);
            if (Tab.PosicaoValida(posicao) && PodeMover(posicao))
            {
                matrizMovimentos[posicao.Linha, posicao.Coluna] = true;
            }
            //Sul curto Oeste longo 7
            posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 2);
            if (Tab.PosicaoValida(posicao) && PodeMover(posicao))
            {
                matrizMovimentos[posicao.Linha, posicao.Coluna] = true;
            }
            //Sul longo Oeste curto 8
            posicao.DefinirValores(Posicao.Linha + 2, Posicao.Coluna - 1);
            if (Tab.PosicaoValida(posicao) && PodeMover(posicao))
            {
                matrizMovimentos[posicao.Linha, posicao.Coluna] = true;
            }

            //FIM movimentação

            return matrizMovimentos;
        }
        public override string ToString()
        {
            return "C";
        }
    }
}
