namespace tabuleiro
{
    internal class Tabuleiro
    {
        public int Linha { get; set; }
        public int Coluna { get; set; }
        private Peca[,] _pecas;

        public Tabuleiro(int linha, int coluna)
        {
            this.Linha = linha;
            this.Coluna = coluna;
            _pecas=new Peca[linha, coluna];
        }
    }
}
