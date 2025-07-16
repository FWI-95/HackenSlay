/// <summary>
/// Animation states that the player can be in.
/// </summary>
//Todo: refactor unused using, variables and comments
//Todo: Add XML documentation to all methods and properties
//Todo: move / refactor this file into the fitting category and folder structure - new animationhandler
namespace HackenSlay;

/// <summary>
/// Enumerates possible player states used for animations.
/// </summary>
public enum PlayerState
{
    IDLE, WALK, RUN, JUMP, ATTACK
}