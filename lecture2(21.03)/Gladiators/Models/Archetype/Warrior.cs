﻿namespace Gladiators.Models.Archetype
{
    public class Warrior : IArchetype
    {
        public string Name { get; } = "Warrior";
        public int Health { get; } = 100;
        public int Damage { get; } = 10;
        public int Initiative { get; } = 1;
    }
}