using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace GuidMySql;

public class DbContextTests
{
    private static readonly string connectionString =
        "server=localhost;user=root;password=root;database=blogsample";

    private SampleDbContext CreateDbContext()
    {
        var serverVersion = ServerVersion.Create(8, 0, 35, ServerType.MySql);
        var optionsBuilder = new DbContextOptionsBuilder<SampleDbContext>()
            .UseMySql(connectionString, serverVersion)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();

        return new SampleDbContext(optionsBuilder.Options);
    }

    [Test]
    public void CreateAndReadPerson()
    {
        var newPerson = new Person("John", "Doe");

        using (var context = CreateDbContext())
        {
            context.Add(newPerson);
            context.SaveChanges();
        }

        using (var context = CreateDbContext())
        {
            var person = context.Persons.Single(p => p.Id == newPerson.Id);

            person.Id.Should().Be(newPerson.Id);
            person.FirstName.Should().Be(newPerson.FirstName);
            person.LastName.Should().Be(newPerson.LastName);
        }
    }
}
