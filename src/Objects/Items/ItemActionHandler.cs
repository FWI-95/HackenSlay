/// <summary>
/// Handles item collection and usage logic for the player.
/// </summary>
//Todo: refactor unused using, variables and comments
//Todo: Add XML documentation to all methods and properties
//Todo: move / refactor this file into the fitting category and folder structure

using System.Collections.Generic;
using System.Runtime.Loader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using HackenSlay;
using HackenSlay.Core.Dev;

namespace HackenSlay.Core.Objects;
/// <summary>
/// Maintains the player's inventory actions such as collecting or using items.
/// </summary>
class ItemActionHandler
{
    List<Item> droppedItems { get; set; }
    List<Item> collectedItems { get; set; }
    
    int selectedPrimaryItem { get; set; }
    int selectedSecondaryItem { get; set; }

    /// <summary>
    /// Initializes item action handler for the given player.
    /// </summary>
    public ItemActionHandler(HackenSlay.Player player, GameHS game)
    {
        collectedItems = new List<Item>();
        droppedItems = new List<Item>();
        selectedPrimaryItem = 0; // Default to the first item
        selectedSecondaryItem = 0; // Default to the first item
    }

    /// <summary>
    /// Executes the primary attack with the currently selected item.
    /// </summary>
    public void PrimaryAttack(GameHS game)
    {
        Item item = collectedItems[selectedPrimaryItem];
        if (item != null)
        {
            item.Handle(game);
        }
        else
        {
            Debug.Log("No item selected for primary attack.", DebugLevel.MEDIUM, DebugCategory.ITEM);
        }
    }

    /// <summary>
    /// Executes the secondary attack with the currently selected item.
    /// </summary>
    public void SecondaryAttack(GameHS game)
    {

        Item item = collectedItems[selectedSecondaryItem];
        if (item != null)
        {
            item.Handle(game);
        }
        else
        {
            Debug.Log("No item selected for secondary attack.", DebugLevel.MEDIUM, DebugCategory.ITEM);
        }
    }

    /// <summary>
    /// Adds the given item to the collection if it is active.
    /// </summary>
    public void Collect(GameHS game, Item item)
    {
        // if (game.userInput.IsActionPressed("open_inventory"))
        // {
        //     itemActionHandler.OpenInventory(game);
        // }
        if (item != null && item._isActive)
        {
            collectedItems.Add(item);
            item._isActive = false; // Mark the item as collected
            Debug.Log($"Collected item: {item._name}", DebugLevel.LOW, DebugCategory.ITEM);
        }
        else
        {
            Debug.Log("Item is not active or null.", DebugLevel.MEDIUM, DebugCategory.ITEM);
        }
    }
    /// <summary>
    /// Drops the specified item back into the world.
    /// </summary>
    public void Drop(GameHS game, Item item)
    {
        if (item != null && !item._isActive)
        {
            droppedItems.Add(item);
            item._isActive = true; // Mark the item as dropped
            Debug.Log($"Dropped item: {item._name}", DebugLevel.LOW, DebugCategory.ITEM);
        }
        else
        {
            Debug.Log("Item is already active or null.", DebugLevel.MEDIUM, DebugCategory.ITEM);
        }
    }

    public void LoadContent(GameHS game)
    {

    }

    public void UnloadContent()
    {

    }
    /// <summary>
    /// Updates all collected items.
    /// </summary>
    public void Update(GameHS game, GameTime gameTime)
    {
        foreach (Item item in collectedItems)
        {
            if (item._isActive)
            {
                item.Update(game, gameTime);
            }
        }
    }
    /// <summary>
    /// Draws all active collected items.
    /// </summary>
    public void Draw(GameHS game, SpriteBatch spriteBatch)
    {
        foreach (Item item in collectedItems)
        {
            if (item._isVisible && item._isActive)
            {
                item.Draw(game, spriteBatch);
            }
        }
    }
    
}