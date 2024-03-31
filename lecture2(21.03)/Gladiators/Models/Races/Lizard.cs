namespace Gladiators.Models.Races
{
    public class Lizard : IRace
    {
        public string Name { get; } = "Lizard";
        public int Damage { get; } = 5;

        public int Health { get; } = 150;

        public int Armor { get; } = 15;

        public int Initiative { get; } = 4;
    }
}