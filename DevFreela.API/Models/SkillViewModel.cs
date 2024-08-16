﻿using DevFreela.API.Entities;

namespace DevFreela.API.Models;

public class SkillViewModel
{
    public SkillViewModel(string description)
    {
        Description = description;
    }

    public string Description { get; private set; }
}