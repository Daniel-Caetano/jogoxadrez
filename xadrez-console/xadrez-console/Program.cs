using System;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();
                while (!partida.Terminada)
                {
                    try
                    {
                        Console.Clear();
                        Tela.ImprimirTabuleiro(partida.Tab);
                        Console.WriteLine();
                        Console.WriteLine("Turno: " + partida.Turno);
                        Console.WriteLine("Aguardando jogada: " + partida.JogadorAtual);

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = Tela.LerPosicaoXadrez().toPosicao();

                        partida.ValidarPosicaoOrigem(origem);

                        bool[,] posicoesPossiveis = partida.Tab.Peca(origem).MovimentosPossiveis();

                        Console.Clear();
                        Tela.ImprimirTabuleiro(partida.Tab, posicoesPossiveis);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.LerPosicaoXadrez().toPosicao();

                        partida.RealizaJogada(origem, destino);
                    }
                    catch(TabuleiroException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
