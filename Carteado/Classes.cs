class Carta
{
    public int Valor;

    public Carta(int valor)
    {
        Valor = valor;
    }

}

class Jogador
{
    public Carta Carta { get; set; }
}

class Baralho
{
    List<Carta> Cartas;

    public Baralho()
    {
        var baralho = new List<Carta>();

        for (int i = 1; i <= 100; i++)
        {
            baralho.Add(new Carta(i));
        }
        Cartas = baralho;
    }

    public Baralho(int tamanho)
    {
        var baralho = new List<Carta>();

        for (int i = 1; i <= tamanho; i++)
        {
            baralho.Add(new Carta(i));
        }
        Cartas = baralho;
    }

    public Carta DarCarta()
    {
        int posicaoPrimeiraCarta = 0;
        Carta carta = Cartas[posicaoPrimeiraCarta];
        Cartas.RemoveAt(posicaoPrimeiraCarta);
        return carta;
    }

    public void Embaralhar()
    {
        var rand = new Random();
        Cartas = Cartas.OrderBy(x => rand.Next()).ToList();
    }

}

class Jogo
{
    Baralho Baralho;
    Jogador Jogador1;
    Jogador Jogador2;

    public Jogo()
    {
        Baralho = new Baralho();
        Jogador1 = new Jogador();
        Jogador2 = new Jogador();
    }

    public Jogo(Baralho baralho)
    {
        Baralho = baralho;
        Jogador1 = new Jogador();
        Jogador2 = new Jogador();
    }

    public Jogo(Baralho baralho, Jogador jogador1, Jogador jogador2)
    {
        Baralho = baralho;
        Jogador1 = jogador1;
        Jogador2 = jogador2;
    }

    public void Jogar()
    {
        Baralho.Embaralhar();
        Jogador1.Carta = Baralho.DarCarta();
        Jogador2.Carta = Baralho.DarCarta();

        VerificarGanhador();
    }

    void VerificarGanhador()
    {

        if (Jogador1.Carta.Valor > Jogador2.Carta.Valor)
        {
            Console.WriteLine($"Jogador 1 ganhou! Carta: {Jogador1.Carta.Valor} vs Carta: {Jogador2.Carta.Valor}");
        }
        else if (Jogador2.Carta.Valor > Jogador1.Carta.Valor)
        {
            Console.WriteLine($"Jogador 2 ganhou! Carta: {Jogador1.Carta.Valor} vs Carta: {Jogador2.Carta.Valor}");
        }
        else
        {
            Console.WriteLine($"Empate! Carta: {Jogador1.Carta.Valor} vs Carta: {Jogador2.Carta.Valor}");
        }
    }
}