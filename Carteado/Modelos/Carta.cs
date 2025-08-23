using Interfaces;

namespace Modelos;

class Carta : IPontuacao
{
    private int Valor;

    public Carta(int valor)
    {
        Valor = valor;
    }

    public virtual int Pontos { get { return Valor; } }
}

class CartaComMultiplicador : Carta
{
    public int Multiplicador { get; private set; }

    public CartaComMultiplicador(int valor, int multiplicador) : base(valor)
    {
        Multiplicador = multiplicador;
    }

    public override int Pontos { get { return base.Pontos * Multiplicador; } }
}

class CartaComNaipe : Carta
{
    public static readonly char[] Naipe = { '\u2665', '\u2666', '\u2660', '\u2663' };
    public int NaipeIndex { get; private set; }

    // "Copas", '\u2665'
    // "Ouros", '\u2666'
    // "Espadas", '\u2660'
    // "Paus", '\u2663'

    public CartaComNaipe(int valor, int naipeIndex) : base(valor)
    {
        NaipeIndex = naipeIndex;
    }

    public char SimboloNaipe => Naipe[NaipeIndex];
    // public override int Pontos { get { return base.Pontos * Multiplicador; } }

}
