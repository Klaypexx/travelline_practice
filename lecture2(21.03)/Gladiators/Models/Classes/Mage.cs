namespace Gladiators.Models.Classes
{
    public class Mage : IClass
    {
        public string Name { get; } = "Mage";
        public int Health { get; } = 80;

        public int Damage { get; } = 12;

        public int Initiative { get; } = 2;

    }
}