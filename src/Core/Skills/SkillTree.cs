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
