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
    /// Gets the list of items currently in the inventory.
    /// </summary>
    public IReadOnlyList<Item> Items => _items;
}
