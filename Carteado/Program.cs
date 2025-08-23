namespace Carteado
{
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

            List<Carta> CriarCartasComNaipe()
            {
                List<Carta> cartas = new List<Carta>();
                //char[] naipe = CartaComNaipe.Naipe;
                for (int i = 1; i <= 13; i++)
                {
                    foreach (char naipe in CartaComNaipe.Naipe)
                    {
                        cartas.Add(new CartaComNaipe(i, naipe));
                    }
                    //for (int j = 1; j <= 3; j++)
                    // {
                    //     cartas.Add(new CartaComNaipe(i, j));
                    // }
                }
                return cartas;
            }

            //Baralho baralho = new Baralho(CriarCartas());
            Baralho<Carta> baralho = new Baralho<Carta>(CriarCartasComNaipe());

            Jogo<Carta> jogo = new Jogo<Carta>(baralho, new Jogador<Carta>(), new Jogador<Carta>());
            jogo.Jogar();
        }
    }
}
