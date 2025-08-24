/*
Regras e implantação

Carta 1 contra Carta 2

1 São escolhidas as 2 cartas do jogo
2 É exibido qual o Naipe da Carta sem o número
3 Concomitante É exibido qual o Multiplicador de cada Naipe - Sorteado a cada jogo
Peso    [ 3.5 ] [ 4.0 ] [ 4.5 ] [ 5.0 ] 
4 Jogador escolhe a carta depois de ser exibido o Naipe e o respectivo peso
5 São exibidas ambas cartas, resultado em pontos, e se o jogador ganhou ou perdeu
*/

namespace Modelos;

using Interfaces;

class Jogo<T>
{
    // neste momento já foi atribuído o naipe, porém, pontuação já é igual a carta
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
        // neste momento baralho já foi embaralhado corretamente, a lista possui as cartas com naipe e com NaipePeso
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

    private void VerificarGanhadorNaipe()
    {

        //double pontosCarta1 = (Jogador1.Pontos * Jogador1.NaipePeso);
        //double pontosCarta2 = (Jogador2.Pontos * Jogador2.NaipePeso);


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

    private string ExibeValorCarta()
    {
        //string cartaValor = Carta.Valor.ToString();
        string cartaValor = "0";
        if (cartaValor == "1")
        {
            cartaValor = "A";
        }
        else if (cartaValor == "11")
        {
            cartaValor = "J";
        }
        else if (cartaValor == "12")
        {
            cartaValor = "Q";
        }
        else if (cartaValor == "13")
        {
            cartaValor = "K";
        }
        return cartaValor;
    }

    public void NovaTelaJogo()
    {
        Console.Clear();
        Console.WriteLine("Bem Vindo!");
        Console.WriteLine("Este é o jogo Carta Maior CaixaVerso!\n");
        Console.WriteLine($"O Naipe das Cartas é \n\tCarta 1 {Jogador1.Pontos} \tvs Carta 2: {Jogador2.Pontos}\n");
        Console.WriteLine("Desta vez a ordem crescente de valor dos Naipes das Cartas é:");
        //Console.WriteLine($"Naipe0\tNaipe1\tNaipe2\tNaipe3");
        Console.WriteLine($"{CartaComNaipe.Naipe[0]}\t{CartaComNaipe.Naipe[1]}\t{CartaComNaipe.Naipe[2]}\t{CartaComNaipe.Naipe[3]}");
        Console.WriteLine("");
        Console.WriteLine("Qual Carta você escolhe?");
        Console.WriteLine("Você ganha o jogo se sua carta tiver uma pontuação final maior que a não escolhida.");
        Console.WriteLine("Digite 1 ou 2 pra escolher sua carta:");
        string? escolhaUsuario = Console.ReadLine();
        int.TryParse(escolhaUsuario, out int escolhaCarta);
        while (escolhaCarta < 1 || escolhaCarta > 2)
        {
            escolhaUsuario = Console.ReadLine();
            int.TryParse(escolhaUsuario, out escolhaCarta);
        }


    }

}