using Microsoft.EntityFrameworkCore;

namespace GuidMySql;

public class SampleDbContext : DbContext
{
    public SampleDbContext(DbContextOptions<SampleDbContext> options)
        : base(options) { }

    public DbSet<Person> Persons => Set<Person>();
}
