using System.Collections.Generic;

namespace HackenSlay.Core.Player;

public class Inventory
{
    private readonly List<Item> _items = new();

    public void Add(Item item)
    {
        _items.Add(item);
    }

    public void Remove(Item item)
    {
        _items.Remove(item);
    }

    public IReadOnlyList<Item> Items => _items;
}
