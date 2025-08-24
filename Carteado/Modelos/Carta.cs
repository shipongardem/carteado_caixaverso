using Interfaces;

namespace Modelos;

public class Carta : IPontuacao
{
    public double Valor { get; private set; }

    public Carta(double valor)
    {
        Valor = valor;
    }

    public virtual double Pontos { get { return Valor; } }
}

class CartaComMultiplicador : Carta
{
    public double Multiplicador { get; private set; }

    public CartaComMultiplicador(double valor, int multiplicador) : base(valor)
    {
        Multiplicador = multiplicador;
    }

    public override double Pontos { get { return base.Pontos * Multiplicador; } }
}

public class CartaComNaipe : Carta, ICarta
{
    public static readonly char[] Naipe = { '\u2665', '\u2666', '\u2660', '\u2663' };
    public int NaipeIndex { get; private set; }
    public double[] pesosSorteados;

    // "Copas", '\u2665'
    // "Ouros", '\u2666'
    // "Espadas", '\u2660'
    // "Paus", '\u2663'

    public CartaComNaipe(double valor, int naipeIndex) : base(valor)
    {
        if (pesosSorteados == null)
        {
            pesosSorteados = SorteiaNaipePeso(new double[] { 3.5, 4.0, 4.5, 5.0 });
        }
        NaipeIndex = naipeIndex;
    }

    public double NaipePeso => pesosSorteados[NaipeIndex];
    public char SimboloNaipe => Naipe[NaipeIndex];

    public override double Pontos
    {
        get { return base.Pontos; }
    }

    private static double[] SorteiaNaipePeso(double[] pesos)
    // teoricamente o Static faz com que somente ocorra 1 sorteio ao todo, 
    // pois assim que for criado o array o static impede de sobreposição

    {
        Random pesoRandom = new Random();
        int n = pesos.Length;
        while (n > 1)
        {
            n--;
            int k = pesoRandom.Next(n + 1);
            double temp = pesos[k];
            pesos[k] = pesos[n];
            pesos[n] = temp;
        }
        return pesos;
    }
    public new double Valor => base.Valor;
}
