using Interfaces;

namespace Modelos
{
    class Jogador : IJogador<ICarta>
    {
        public ICarta Item { get; set; }
        //public ICarta Item { get; set; }
        public double Pontos => Item.Pontos;

        public void PegarNovoItem(ICarta item)
        {
            Item = item;
        }
        public ICarta Carta => Item;
    }
}
