using tabuleiro;

namespace xadrez
{
    internal class Rei : Peca
    {
        private PartidaDeXadrez partida;
        public Rei(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor)
        {
            this.partida = partida;
        }
        public bool PodeMover(Posicao pos)
        {
            Peca peca = Tab.Peca(pos);
            return (peca == null || peca.Cor != Cor);
        }
        private bool TesteTorreParaRoque(Posicao pos)
        {
            Peca peca = Tab.Peca(pos);
            return peca != null && peca is Torre && peca.Cor == Cor && peca.QteMovimentos==0;
        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] matrizMovimentos = new bool[Tab.Linhas, Tab.Colunas];

            //teste// 
            Posicao posicao = new Posicao(0, 0);
            //Norte 
            posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);

            if (Tab.PosicaoValida(posicao) && PodeMover(posicao))
            {
                matrizMovimentos[posicao.Linha, posicao.Coluna] = true;
            }
            //Nordeste 
            posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);

            if (Tab.PosicaoValida(posicao) && PodeMover(posicao))
            {
                matrizMovimentos[posicao.Linha, posicao.Coluna] = true;
            }
            //Leste
            posicao.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);

            if (Tab.PosicaoValida(posicao) && PodeMover(posicao))
            {
                matrizMovimentos[posicao.Linha, posicao.Coluna] = true;
            }
            //Suldeste 
            posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);

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
            posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);

            if (Tab.PosicaoValida(posicao) && PodeMover(posicao))
            {
                matrizMovimentos[posicao.Linha, posicao.Coluna] = true;
            }
            //#Roque Jogada Especial
            if ( (QteMovimentos == 0) && (!partida.Xeque) )
            {

                //#Roque Pequeno: Jogada-Especial
                Posicao torreRoquePequeno = new Posicao(Posicao.Linha, Posicao.Coluna + 3);
                if (TesteTorreParaRoque(torreRoquePequeno))
                {
                    Posicao posicaoMaisUm = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    Posicao posicaoMaisDois = new Posicao(Posicao.Linha, Posicao.Coluna + 2);
                    if(Tab.Peca(posicaoMaisUm)==null && Tab.Peca(posicaoMaisDois) == null)
                    {
                        matrizMovimentos[Posicao.Linha,Posicao.Coluna + 2] = true;
                    }
                }
                //#Roque Grande: Jogada-Especial
                Posicao torreRoqueGrande= new Posicao(Posicao.Linha, Posicao.Coluna - 4);
                if (TesteTorreParaRoque(torreRoqueGrande))
                {
                    Posicao posicaoMaisUm = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    Posicao posicaoMaisDois = new Posicao(Posicao.Linha, Posicao.Coluna - 2);
                    Posicao posicaoMaisTres = new Posicao(Posicao.Linha, Posicao.Coluna - 3);
                    if (Tab.Peca(posicaoMaisUm) == null && Tab.Peca(posicaoMaisDois) == null && Tab.Peca(posicaoMaisTres) == null)
                    {
                        matrizMovimentos[Posicao.Linha, Posicao.Coluna - 2] = true;
                    }
                }
            }
            return matrizMovimentos;

        }
        public override string ToString()
        {
            return "R";
        }
    }
}
