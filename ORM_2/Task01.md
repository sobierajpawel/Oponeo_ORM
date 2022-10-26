## Task 1

### Use advance functions of EF 

1. Clone the solution from the previous exercise.

2. Change table name in `OrdersDbContext` for Orders and add Order as a `DataSet` in the context class. Add `ProductId` foreign key to `OrderLine`.

3. Create a migration to this change and then use `Get-Migration` command, after that `Update-Database`. 

4. Downgrade database with `Update-Database` to the previous migration.

5. Use `Remove-Migration` and inspect what will happen. 

6. In console application create a few commands with using SQL raw query. Use:
- raw query
- interporaled query
- mixture with LINQ

7. Write a service which uses transaction which add order with order lines with products (if they do not exist in db you need to add them). Use `commit` and `rollback` 
to specify the result of the transaction. 
