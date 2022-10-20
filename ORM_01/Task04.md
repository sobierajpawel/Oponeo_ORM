## Task 4

### Creating migrations for EF code-first approach

1. Use the application created in the previous exercise and install package Microsoft.EntityFrameworkCore.Tools. Then restart Visual Studio.

2. In Package Manager Console run command ```add-migration``` and see what will happen. 

3. If a migration folder and file are created run command ```update-database``` and check if a database will be created.

4. Write `Order` and `OrderLines`. `Order` should containt a foreign key to `Customer` class, `OrderLines` should contain two foreign keys for corresponding `Order` and `Product`.
Use composed primary key which contain `LineNumber` and `OrderId` in `OrderLine`.

5. Add migration and update database.

6. Write a few piece of codes in order to add data to all created tables.
