/// <summary>
/// Simple list based inventory for holding items.
/// </summary>

using System.Collections.Generic;

namespace HackenSlay.Core.Player;

/// <summary>
/// Represents the player's collection of items.
/// </summary>
public class Inventory
{
    private readonly List<Item> _items = new();

    /// <summary>
    /// Adds an item to the inventory.
    /// </summary>
    public void Add(Item item)
    {
        _items.Add(item);
    }

    /// <summary>
    /// Removes an item from the inventory.
    /// </summary>
    public void Remove(Item item)
    {
        _items.Remove(item);
    }

    /// <summary>
    /// Moves an item from one index to another within the inventory list.
    /// </summary>
    public void MoveItem(int fromIndex, int toIndex)
    {
        if (fromIndex < 0 || fromIndex >= _items.Count)
            return;
        if (toIndex < 0 || toIndex >= _items.Count)
            return;
        if (fromIndex == toIndex)
            return;

        Item item = _items[fromIndex];
        _items.RemoveAt(fromIndex);
        _items.Insert(toIndex, item);
    }


    /// <summary>
    /// Gets the list of items currently in the inventory.
    /// </summary>
    public IReadOnlyList<Item> Items => _items;
}
