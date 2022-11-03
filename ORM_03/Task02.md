## Task 2

### Use fluentAPI convention and shadow properties

1. Remove all adnotations from current domain model and try to write all of relationships, keys and the like in the `OnModelCreating` method

```cs
  protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Patient>()
               .HasKey(x => x.Id);
               ...
               
```

2. Remove all migrations from database and clear all tables in database.

3. Add `Initial` migration and then update database. Inspect if all necessary relationship has been added to database.

4. Add shadow properties for `UpdateDateTime` and `CreateDateTime`.

5. Add migration and update database.

6. Inspect if properties are added to database.

7. Write a code in overrided `SaveChanges` method to fill these parameters.
