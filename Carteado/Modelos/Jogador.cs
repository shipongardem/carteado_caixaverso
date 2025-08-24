using Interfaces;

namespace Modelos
{
    class Jogador<T> : IJogador<T> where T : IPontuacao
    {
        private T Item { get; set; }

        public double Pontos => Item.Pontos;

        public void PegarNovoItem(T item)
        {
            Item = item;
        }
    }
}
