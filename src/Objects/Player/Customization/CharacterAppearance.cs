/// <summary>
/// Stores simple appearance customization options for the player.
/// </summary>
//Todo: refactor unused using, variables and comments
//Todo: Add XML documentation to all methods and properties
//Todo: move / refactor this file into the fitting category and folder structure (make everything to do with player a own category, like Player/Inventory, Player/State, etc.)

namespace HackenSlay.Core.Customization;

/// <summary>
/// Defines basic appearance properties for the player character.
/// </summary>
public class CharacterAppearance
{
    public string HairStyle { get; set; } = "Default";
    public string Outfit { get; set; } = "Default";
}
