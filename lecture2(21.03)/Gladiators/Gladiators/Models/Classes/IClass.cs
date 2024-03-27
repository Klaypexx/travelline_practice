namespace Gladiators.Models.Classes
{
    public interface IClass
    {
        string Name { get; }
        int Health { get; }

        int Damage { get; }

        int Initiative { get; }

    }
}