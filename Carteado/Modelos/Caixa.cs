class Caixa<T>
{
    List<T> items = new List<T>();
    void Adicionar(T item)
    {
        items.Add(item);
    }
    T Retirar(int posicao)
    {
        return items[posicao];
    }
}
