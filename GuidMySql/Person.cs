using System.ComponentModel.DataAnnotations.Schema;

namespace GuidMySql;

public class Person
{
    [Column(TypeName = "binary(16)")]
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Person(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}
