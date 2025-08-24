/*
Regras e implantação

Carta 1 contra Carta 2

1 São escolhidas as 2 cartas do jogo
2 É exibido qual o Naipe da Carta sem o número
3 Concomitante É exibido qual o Multiplicador de cada Naipe - Sorteado a cada jogo
Peso    [ 3.5 ] [ 4.0 ] [ 4.5 ] [ 5.0 ] 
4 Jogador escolhe a carta depois de ser exibido o Naipe e o respectivo peso
5 São exibidas ambas cartas, resultado do peso aplicado, e se o jogador ganhou ou perdeu


    public static readonly char[] Naipe = { '\u2665', '\u2666', '\u2660', '\u2663' };
    public int NaipeIndex { get; private set; }

    // "Copas", '\u2665'
    // "Ouros", '\u2666'
    // "Espadas", '\u2660'
    // "Paus", '\u2663'

*/

namespace Carteado
{
    using Interfaces;
    using Modelos;

    class Program
    {
        static void Main(string[] args)
        {
            List<Carta> CriarCartas()
            {
                List<Carta> cartas = new List<Carta>();
                for (int i = 1; i <= 100; i++)
                {
                    cartas.Add(new Carta(i));
                }
                return cartas;
            }

            List<Carta> CriarCartasComMultiplicador()
            {
                List<Carta> cartas = new List<Carta>();
                for (int i = 1; i <= 100; i++)
                {
                    for (int j = 1; j <= 4; j++)
                    {
                        cartas.Add(new CartaComMultiplicador(i, j));
                    }
                }
                return cartas;
            }

            List<ICarta> CriarCartasComNaipe()
            {
                List<ICarta> cartas = new List<ICarta>();
                //char[] naipe = CartaComNaipe.Naipe;
                for (int i = 1; i <= 13; i++)
                {
                    foreach (char naipe in CartaComNaipe.Naipe)
                    {
                        cartas.Add(new CartaComNaipe(i, naipe));
                    }
                }
                return cartas;
            }

            //Baralho baralho = new Baralho(CriarCartas());
            Baralho<ICarta> baralho = new Baralho<ICarta>(CriarCartasComNaipe());

            Jogo<ICarta> jogo = new Jogo<ICarta>(baralho, new Jogador(), new Jogador());
            jogo.Jogar();
        }
    }
}
