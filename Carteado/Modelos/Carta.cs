using Interfaces;

namespace Modelos;

class Carta : IPontuacao
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

class CartaComNaipe : Carta
{
    public static readonly char[] Naipe = { '\u2665', '\u2666', '\u2660', '\u2663' };
    public int NaipeIndex { get; private set; }
    public char SimboloNaipe => Naipe[NaipeIndex];
    public double[] NaipePeso { get; private set; }
    // "Copas", '\u2665'
    // "Ouros", '\u2666'
    // "Espadas", '\u2660'
    // "Paus", '\u2663'

    public CartaComNaipe(double valor, int naipeIndex) : base(valor)
    {
        NaipeIndex = naipeIndex;
        NaipePeso = new double[] { 3.5, 4.0, 4.5, 5.0 };
        NaipePeso = SorteiaNaipePeso(NaipePeso);
    }


    public override double Pontos
    { get { return base.Pontos; } 
        /*
        get
        {
            double multiplicador = NaipePeso[NaipeIndex];
            return base.Pontos * multiplicador;
        }
        */
    }

    double[] SorteiaNaipePeso(double[] sorteiaNaipePeso)
    {
        Random pesoRandom = new Random();
        int n = NaipePeso.Length;
        while (n > 1)
        {
            n--;
            int k = pesoRandom.Next(n + 1);
            double temp = sorteiaNaipePeso[k];
            sorteiaNaipePeso[k] = sorteiaNaipePeso[n];
            sorteiaNaipePeso[n] = temp;
        }
        return sorteiaNaipePeso;
    }

}
