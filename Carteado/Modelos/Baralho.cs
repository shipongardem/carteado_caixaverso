namespace Modelos;

using Interfaces;

class Baralho<T> : IBaralho<T>
{
    public List<T> Cartas { get; private set; }

    public Baralho(List<T> cartas)
    {
        Cartas = cartas;
    }

    public T Entregar()
    {
        int posicaoPrimeiraCarta = 0;
        T carta = Cartas[posicaoPrimeiraCarta];
        Cartas.RemoveAt(posicaoPrimeiraCarta);
        return carta;
    }

    public void Embaralhar()
    {
        var rand = new Random();
        Cartas = Cartas.OrderBy(x => rand.Next()).ToList();
    }

}
