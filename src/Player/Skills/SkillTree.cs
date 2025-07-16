//Todo: Add a comment to the top of this file explaining what this file is for and what it does.
//Todo: refactor unused using, variables and comments
//Todo: Add XML documentation to all methods and properties
//Todo: move / refactor this file into the fitting category and folder structure

using System.Collections.Generic;

namespace HackenSlay.Core.Skills;

public class Skill
{
    public string Name { get; }
    public Skill(string name) => Name = name;
}

public class SkillTree
{
    private readonly List<Skill> _skills = new();

    public void Unlock(Skill skill)
    {
        if (!_skills.Contains(skill))
            _skills.Add(skill);
    }

    public IReadOnlyList<Skill> Unlocked => _skills;
}
