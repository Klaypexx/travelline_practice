namespace Gladiators.Models.Archetype
{
    public interface IArchetype
    {
        string Name { get; }
        int Health { get; }
        int Damage { get; }
        int Initiative { get; }
    }
}