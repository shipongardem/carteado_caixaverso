namespace Interfaces;

interface IJogador<T> : IPontuacao
{
    void PegarNovoItem(T item);
    T Carta { get; }
}