namespace tabuleiro
{
    internal abstract class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QteMovimentos { get; protected set; }
        public Tabuleiro Tab { get; protected set; }
        public Peca(Tabuleiro tab, Cor cor)
        {
            Posicao = null;
            Tab = tab;
            Cor = cor;
            QteMovimentos = 0;
        }
        public void IncrementarQteMoviemntos()
        {
            QteMovimentos++;
        }
        public void DecrementarQteMoviemntos()
        {
            QteMovimentos--;
        }
        public bool ExisteMovimentosPossiveis()
        {
            bool[,] movimentos = MovimentosPossiveis();
            for (int i = 0; i < Tab.Linhas; i++)    
            {
                for (int j = 0; j < Tab.Colunas; j++)
                {
                    if (movimentos[i,j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool PodeMoverPara(Posicao posicao)
        {
            return MovimentosPossiveis()[posicao.Linha, posicao.Coluna];
        }
        public abstract bool[,] MovimentosPossiveis();
    }
}
