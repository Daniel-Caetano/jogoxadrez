using tabuleiro;

namespace xadrez
{
    internal class Torre : Peca
    {
        public Torre(Tabuleiro tab, Cor cor) : base(tab, cor)
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

            //Norte
            posicao.DefinirValores(Posicao.Linha-1,Posicao.Coluna);
            while (Tab.PosicaoValida(posicao) && PodeMover(posicao))
            {
                matrizMovimentos[posicao.Linha, posicao.Coluna] = true;
                if (Tab.Peca(posicao)!=null && Tab.Peca(posicao).Cor != Cor)
                {
                    break;
                }
                posicao.Linha=posicao.Linha-1;
            }
            //Sul
            posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            while (Tab.PosicaoValida(posicao) && PodeMover(posicao))
            {
                matrizMovimentos[posicao.Linha, posicao.Coluna] = true;
                if (Tab.Peca(posicao) != null && Tab.Peca(posicao).Cor != Cor)
                {
                    break;
                }
                posicao.Linha = posicao.Linha + 1;
            }
            //Leste
            posicao.DefinirValores(Posicao.Linha, Posicao.Coluna+1);
            while (Tab.PosicaoValida(posicao) && PodeMover(posicao))
            {
                matrizMovimentos[posicao.Linha, posicao.Coluna] = true;
                if (Tab.Peca(posicao) != null && Tab.Peca(posicao).Cor != Cor)
                {
                    break;
                }
                posicao.Coluna = posicao.Coluna + 1;
            }
            //Oeste
            posicao.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            while (Tab.PosicaoValida(posicao) && PodeMover(posicao))
            {
                matrizMovimentos[posicao.Linha, posicao.Coluna] = true;
                if (Tab.Peca(posicao) != null && Tab.Peca(posicao).Cor != Cor)
                {
                    break;
                }
                posicao.Coluna = posicao.Coluna - 1;
            }
            //Fim movimentação

            return matrizMovimentos;
        }
        public override string ToString()
        {
            return "T";
        }
    }
}
