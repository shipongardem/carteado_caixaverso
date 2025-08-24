namespace Interfaces;

interface ICarta : IPontuacao
{
    double Valor { get; }
    double NaipePeso { get; }
    char SimboloNaipe { get; }
}