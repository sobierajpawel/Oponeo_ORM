## Task 1

### Create seeding data mechanism for EF

1. Use the application from previous exercise or use your own implementation.

2. Create your own class to seed data for a few patients in EF and use it in presentation layer.

3. Create a new empty migration wich will be responsible to add a few doctors. Use `Add-Migration "Empty-Migration"` and write your code according the example below.

```cs
public partial class Empty_migrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "FirstName", "LastName", "BirthDate" },
                values: new object[] { "Adam", "Migracyjny", DateTime.Now });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
```

4. Inspect if records are added to database.
