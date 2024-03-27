namespace Gladiators.Models.Armors
{
    public class NoArmor : IArmor
    {
        public string Name { get; } = "No armor";
        public int Armor { get; } = 0;
    }
}