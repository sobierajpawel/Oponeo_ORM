## Task 3

### Creating a simple console application in .NET 6 with EF Core and code-first approach

1. Create a new project and choose Console Application as a type of a project. Choose .NET 6 as a framework, download and install it if you do not have it.

2. Add model classes for `Customer` and `Product`. Use base class and use inheritance to keep common properties like `Id`, `CreatedDateTime`, `UpdatedDateTime`.

```cs
public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public DateTime? UpdatedDateTime { get; set; }
    }
```

3. Add DbContext class you can use the following as an example.

```cs
 internal class ModelFirstDbContext : DbContext
    {
        public ModelFirstDbContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("<YOUR_CONNECTION_STRING>");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Products");
        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).UpdatedDateTime = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreatedDateTime = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }
    }
```

4. In the `Program.cs` use `EnsureCreated()` command and check if a database is created. Write a few lines of code to add, modify, remove and select values via EF from database.
