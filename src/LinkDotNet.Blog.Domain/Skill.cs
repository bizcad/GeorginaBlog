﻿using System;

namespace LinkDotNet.Blog.Domain;

public class Skill : Entity
{
    private Skill()
    {
    }

    private Skill(string name, string iconUrl, string capability, ProficiencyLevel proficiencyLevel)
    {
        IconUrl = iconUrl;
        Name = name;
        Capability = capability;
        ProficiencyLevel = proficiencyLevel;
    }

    public string IconUrl { get; private set; }

    public string Name { get; private set; }

    public string Capability { get; private set; }

    public ProficiencyLevel ProficiencyLevel { get; private set; }

    public static Skill Create(string name, string iconUrl, string capability, string proficiencyLevel)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException(nameof(name));
        }

        if (string.IsNullOrWhiteSpace(capability))
        {
            throw new ArgumentNullException(nameof(capability));
        }

        var level = ProficiencyLevel.Create(proficiencyLevel);

        iconUrl = string.IsNullOrWhiteSpace(iconUrl) ? null : iconUrl;
        return new Skill(name.Trim(), iconUrl, capability.Trim(), level);
    }

    public void SetProficiencyLevel(ProficiencyLevel level)
    {
        ArgumentNullException.ThrowIfNull(level);
        ProficiencyLevel = level;
    }
}
