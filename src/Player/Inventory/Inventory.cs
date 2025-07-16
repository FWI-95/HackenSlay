//Todo: Add a comment to the top of this file explaining what this file is for and what it does.
//Todo: refactor unused using, variables and comments
//Todo: Add XML documentation to all methods and properties
//Todo: move / refactor this file into the fitting category and folder structure

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
