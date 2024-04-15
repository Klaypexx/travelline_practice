using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain;
public class Actor
{
    public int Id { get; private init; }
    public string Name { get; private set; }
    public string Surname { get; private set; }
    public string PhoneNumber { get; private set; }
    public DateTime DateOfBirth { get; private init; }

    public string FullName => $"{Surname} {Name}";

    public IReadOnlyList<Play> Plays { get; private init; } = new List<Play>();
    public Actor(
        string name,
        string surname,
        string phoneNumber,
        DateTime dateOfBirth )
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException($"'{nameof(name)}' cannot be null or empty.", nameof(name));
        }

        if (string.IsNullOrEmpty(surname))
        {
            throw new ArgumentException($"'{nameof(surname)}' cannot be null or empty.", nameof(surname));
        }

        if (string.IsNullOrEmpty(phoneNumber))
        {
            throw new ArgumentException($"'{nameof(phoneNumber)}' cannot be null or empty.", nameof(phoneNumber));
        }

        Name = name;
        Surname = surname;
        PhoneNumber = phoneNumber;
        DateOfBirth = dateOfBirth;
    }
}
