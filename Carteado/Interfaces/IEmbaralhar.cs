namespace Interfaces;

interface IBaralho<T> : IEmbaralhar, IEntregar<T>
{

}

interface IEmbaralhar
{
    void Embaralhar();
}

interface IEntregar<T>
{
    T Entregar();
}
