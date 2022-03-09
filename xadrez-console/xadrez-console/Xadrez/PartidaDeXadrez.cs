using System;
using tabuleiro;

namespace xadrez
{
    internal class PartidaDeXadrez
    {
        public Tabuleiro Tab { get; set; }
        private int turno;
        private Cor jogadorAtual;
        public bool Terminada { get; set; }

        public PartidaDeXadrez()
        {
            this.Tab = new Tabuleiro(8,8);
            this.turno = 1;
            this.jogadorAtual = Cor.Branca;
            ColocarPeca();
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca peca = Tab.RetirarPeca(origem);
            peca.incrementarQteMoviemntos();
            Peca pecaCapturada= Tab.RetirarPeca(destino);
            Tab.ColocarPeca(peca,destino);
        }
        public void ColocarPeca()
        {
            //Tab.ColocarPeca(new Peao(Tab, Cor.Branca),new PosicaoDeXadrez('a',2).toPosicao());
            //Tab.ColocarPeca(new Peao(Tab, Cor.Branca), new PosicaoDeXadrez('b', 2).toPosicao());
            //Tab.ColocarPeca(new Peao(Tab, Cor.Branca), new PosicaoDeXadrez('c', 2).toPosicao());
            //Tab.ColocarPeca(new Peao(Tab, Cor.Branca), new PosicaoDeXadrez('d', 2).toPosicao());
            //Tab.ColocarPeca(new Peao(Tab, Cor.Branca), new PosicaoDeXadrez('e', 2).toPosicao());
            //Tab.ColocarPeca(new Peao(Tab, Cor.Branca), new PosicaoDeXadrez('f', 2).toPosicao());
            //Tab.ColocarPeca(new Peao(Tab, Cor.Branca), new PosicaoDeXadrez('g', 2).toPosicao());
            //Tab.ColocarPeca(new Peao(Tab, Cor.Branca), new PosicaoDeXadrez('h', 2).toPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Branca), new PosicaoDeXadrez('a', 1).toPosicao());
            //Tab.ColocarPeca(new Cavalo(Tab, Cor.Branca), new PosicaoDeXadrez('b', 1).toPosicao());
            //Tab.ColocarPeca(new Bispo(Tab, Cor.Branca), new PosicaoDeXadrez('c', 1).toPosicao());
            Tab.ColocarPeca(new Rei(Tab, Cor.Branca), new PosicaoDeXadrez('d', 1).toPosicao());
            //Tab.ColocarPeca(new Dama(Tab, Cor.Branca), new PosicaoDeXadrez('e', 1).toPosicao());
            //Tab.ColocarPeca(new Bispo(Tab, Cor.Branca), new PosicaoDeXadrez('f', 1).toPosicao());
            //Tab.ColocarPeca(new Cavalo(Tab, Cor.Branca), new PosicaoDeXadrez('g', 1).toPosicao());
            //Tab.ColocarPeca(new Torre(Tab, Cor.Branca), new PosicaoDeXadrez('h', 1).toPosicao());

            //Tab.ColocarPeca(new Peao(Tab, Cor.Preta), new PosicaoDeXadrez('a', 7).toPosicao());
            //Tab.ColocarPeca(new Peao(Tab, Cor.Preta), new PosicaoDeXadrez('b', 7).toPosicao());
            //Tab.ColocarPeca(new Peao(Tab, Cor.Preta), new PosicaoDeXadrez('c', 7).toPosicao());
            //Tab.ColocarPeca(new Peao(Tab, Cor.Preta), new PosicaoDeXadrez('d', 7).toPosicao());
            //Tab.ColocarPeca(new Peao(Tab, Cor.Preta), new PosicaoDeXadrez('e', 7).toPosicao());
            //Tab.ColocarPeca(new Peao(Tab, Cor.Preta), new PosicaoDeXadrez('f', 7).toPosicao());
            //Tab.ColocarPeca(new Peao(Tab, Cor.Preta), new PosicaoDeXadrez('g', 7).toPosicao());
            //Tab.ColocarPeca(new Peao(Tab, Cor.Preta), new PosicaoDeXadrez('h', 7).toPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Preta), new PosicaoDeXadrez('a', 8).toPosicao());
            Tab.ColocarPeca(new Cavalo(Tab, Cor.Preta), new PosicaoDeXadrez('b', 8).toPosicao());
            Tab.ColocarPeca(new Bispo(Tab, Cor.Preta), new PosicaoDeXadrez('c', 8).toPosicao());
            Tab.ColocarPeca(new Rei(Tab, Cor.Preta), new PosicaoDeXadrez('d', 8).toPosicao());
            Tab.ColocarPeca(new Dama(Tab, Cor.Preta), new PosicaoDeXadrez('e', 8).toPosicao());
            Tab.ColocarPeca(new Bispo(Tab, Cor.Preta), new PosicaoDeXadrez('f', 8).toPosicao());
            Tab.ColocarPeca(new Cavalo(Tab, Cor.Preta), new PosicaoDeXadrez('g', 8).toPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Preta), new PosicaoDeXadrez('h', 8).toPosicao());
        }
    }
}
