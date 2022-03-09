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
            this.Posicao = null;
            this.Tab = tab;
            this.Cor = cor;
            this.QteMovimentos = 0;
        }
        public void incrementarQteMoviemntos()
        {
            this.QteMovimentos++;
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
        public abstract bool[,] MovimentosPossiveis();
    }
}
