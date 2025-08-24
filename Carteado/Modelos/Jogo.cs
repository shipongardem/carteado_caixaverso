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

class Jogo<T> where T : ICarta
{
    // neste momento já foi atribuído o naipe, porém, pontuação já é igual a carta
    private IBaralho<ICarta> Baralho { get; set; }
    private IJogador<ICarta> Jogador1 { get; set; }
    private IJogador<ICarta> Jogador2 { get; set; }

    public Jogo(IBaralho<ICarta> baralho, IJogador<ICarta> jogador1, IJogador<ICarta> jogador2)
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

        // VerificarGanhador();
        VerificarGanhadorNaipe();
    }
/*
        public void JogarComNaipe()
    {
        // neste momento baralho já foi embaralhado corretamente, a lista possui as cartas com naipe e com NaipePeso
        Baralho.Embaralhar();
        Jogador1.PegarNovoItem(Baralho.Entregar());
        Jogador2.PegarNovoItem(Baralho.Entregar());

        VerificarGanhador();
    }
    */

    private void VerificarGanhador()
    {
        // No momento possuo baralho correto, Jogador1 e Jogador2 tendo Cartas, e não somente pontos
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

        var cartaJogador1 = Jogador1.Carta as CartaComNaipe;
        var cartaJogador2 = Jogador2.Carta as CartaComNaipe;
        double[] pesosSorteados = cartaJogador1.pesosSorteados;
        char[] naipes = CartaComNaipe.Naipe;
        double pontosCarta1 = cartaJogador1.Valor * cartaJogador1.pesosSorteados[PesoNaipeCalculado(cartaJogador1.NaipeIndex)];
        double pontosCarta2 = cartaJogador2.Valor * cartaJogador1.pesosSorteados[PesoNaipeCalculado(cartaJogador2.NaipeIndex)];


        //double pontosCarta1 = Jogador1.Carta.Valor * Jogador1.Carta.NaipePeso;
        //double pontosCarta2 = Jogador2.Carta.Valor * Jogador2.Carta.NaipePeso;

        int escolhaJogador = NovaTelaJogo();

        // Comandos para escolha da Carta 1
        Console.WriteLine($"Sua carta escolhida é : {cartaJogador1.Valor} {naipes[PesoNaipeCalculado(cartaJogador1.NaipeIndex)]} Num total de {pontosCarta1} Pontos!");

        // Comandos para escolha da Carta 2
        Console.WriteLine($"Sua carta escolhida é : {cartaJogador2.Valor} {naipes[PesoNaipeCalculado(cartaJogador2.NaipeIndex)]} Num total de {pontosCarta2} Pontos!");


        if (escolhaJogador == 1)
        {
            Console.WriteLine($"Jogador 1 ganhou! Carta: {Jogador1.Pontos} vs Carta: {Jogador2.Pontos}");
        }
        else if (escolhaJogador == 2)
        {
            Console.WriteLine($"Jogador 2 ganhou! Carta: {Jogador1.Pontos} vs Carta: {Jogador2.Pontos}");
        }
        else
        {
            Console.WriteLine($"Jogo será encerrado.");
        }
    }

    private string ExibeValorCarta(double cartaValor)
    {
        string cartaValorConvertida = cartaValor.ToString();

        //string cartaValor = "0";
        if (cartaValorConvertida == "1")
        {
            cartaValorConvertida = "A";
        }
        else if (cartaValorConvertida == "11")
        {
            cartaValorConvertida = "J";
        }
        else if (cartaValorConvertida == "12")
        {
            cartaValorConvertida = "Q";
        }
        else if (cartaValorConvertida == "13")
        {
            cartaValorConvertida = "K";
        }
        return cartaValorConvertida;
    }

    public int PesoNaipeCalculado(int naipeIndex)
    {
        //var cartaJogador1 = Jogador1.Carta as CartaComNaipe;
        //var[] retornoNaipe = new[] { cartaJogador1.}
        switch (naipeIndex)
        {
            case 9829:
                {
                    // CartaComNaipe.pesosSorteados[0];
                    return 0;
                    // break;
                }
            case 9830:
                {
                    // CartaComNaipe.pesosSorteados[1];
                    return 1;
                    // break;
                }
            case 9824:
                {
                    // CartaComNaipe.pesosSorteados[2];
                    return 2;
                    // break;
                }
            case 9827:
                {
                    return 3;
                    // CartaComNaipe.pesosSorteados[3];
                    // break;
                }
        }

        return 1;
    }

    public int NovaTelaJogo()
    {
        int escolhaCarta = 0; // --> Não mexer
        var cartaJogador1 = Jogador1.Carta as CartaComNaipe;
        var cartaJogador2 = Jogador2.Carta as CartaComNaipe;
        double[] pesosSorteados = cartaJogador1.pesosSorteados;
        char[] naipes = CartaComNaipe.Naipe;

        while (escolhaCarta < 1 || escolhaCarta > 2)
        {
            //Console.Clear(); // -> Desfazer comentário
            Console.WriteLine("Bem Vindo!");
            Console.WriteLine("Este é o jogo Carta Maior CaixaVerso!\n");
            Console.WriteLine("Desta vez a ordem crescente de valor dos Naipes das Cartas é:");
            Console.Write($" {naipes[0]} - Peso: {pesosSorteados[0]}\t {naipes[1]} - Peso: {pesosSorteados[1]}\t {naipes[2]} - Peso: {pesosSorteados[2]}\t {naipes[3]} - Peso: {pesosSorteados[3]}");
            Console.WriteLine("");
            Console.WriteLine("Qual Carta você escolhe?");
            Console.WriteLine($"\t\t{cartaJogador1.Valor}\t\t\t{cartaJogador2.Valor}");
            Console.WriteLine("Você ganha o jogo se sua carta tiver uma pontuação final maior que a não escolhida.");
            Console.WriteLine("Digite 1 ou 2 pra escolher sua carta:");
            string? escolhaUsuario = Console.ReadLine();
            int.TryParse(escolhaUsuario, out escolhaCarta);
        }
        return escolhaCarta;
    }
}