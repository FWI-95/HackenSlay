/// <summary>
/// Represents a movable base such as a vehicle or mount.
/// </summary>
//Todo: refactor unused using, variables and comments
//Todo: Add XML documentation to all methods and properties
//Todo: move / refactor this file into the fitting category and folder structure (own category for MobileBase, this will used for player vehicles, pets, etc.)

namespace HackenSlay.Core.Customization;

/// <summary>
/// Base class for player controlled vehicles.
/// </summary>
public class MobileBase
{
    public string Name { get; set; } = "Van";
}
