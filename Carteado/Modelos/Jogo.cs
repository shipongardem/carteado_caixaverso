namespace Modelos;

using Interfaces;

class Jogo<T>
{
    private IBaralho<T> Baralho { get; set; }
    private IJogador<T> Jogador1 { get; set; }
    private IJogador<T> Jogador2 { get; set; }

    public Jogo(IBaralho<T> baralho, IJogador<T> jogador1, IJogador<T> jogador2)
    {
        Baralho = baralho;
        Jogador1 = jogador1;
        Jogador2 = jogador2;
    }

    public void Jogar()
    {
        Baralho.Embaralhar();
        Jogador1.PegarNovoItem(Baralho.Entregar());
        Jogador2.PegarNovoItem(Baralho.Entregar());

        VerificarGanhador();
    }

    private void VerificarGanhador()
    {

        if (Jogador1.Pontos > Jogador2.Pontos)
        {
            Console.WriteLine($"Jogador 1 ganhou! Carta: {Jogador1.Pontos} vs Carta: {Jogador2.Pontos}");
        }
        else if (Jogador2.Pontos > Jogador1.Pontos)
        {
            Console.WriteLine($"Jogador 2 ganhou! Carta: {Jogador1.Pontos} vs Carta: {Jogador2.Pontos}");
        }
        else
        {
            Console.WriteLine($"Empate! Carta: {Jogador1.Pontos} vs Carta: {Jogador2.Pontos}");
        }
    }
}