/// <summary>
/// Simple skill tree implementation for unlocking abilities.
/// </summary>

using System.Collections.Generic;

namespace HackenSlay.Core.Skills;

/// <summary>
/// Represents a single skill that can be unlocked.
/// </summary>
public class Skill
{
    /// <summary>
    /// Gets the display name of the skill.
    /// </summary>
    public string Name { get; }

    public Skill(string name) => Name = name;
}

/// <summary>
/// Holds the player's unlocked skills.
/// </summary>
public class SkillTree
{
    private readonly List<Skill> _skills = new();

    /// <summary>
    /// Adds a skill to the unlocked list if not present.
    /// </summary>
    public void Unlock(Skill skill)
    {
        if (!_skills.Contains(skill))
            _skills.Add(skill);
    }

    /// <summary>
    /// Gets the list of unlocked skills.
    /// </summary>
    public IReadOnlyList<Skill> Unlocked => _skills;
}
