## Task 2

### Creating a simple application in WinForms (using .NET Framework and EF6 with database first approach)

1. Create a new project and choose WinForms (.NET Framework) as a technology.

2. When a project is ready please find and install a nuget with EF6 (take a look to use EF6 not EFCore version). 

3. Then add new item to the project and select Data from the left menu and then ADO.NET Entity Data Model. Enter OrderModel as the name and click OK. This launches the Entity Data Model Wizard
.Select Generate from Database and click Next.

4. Select the connection to the database you created in previous task, enter OrdersDbContext as the name of the connection string and click Next.

5. Click the checkbox next to ‘Tables’ to import all tables and click ‘Finish’.

6. Add buttons, datagridview to your application and provide simple features like:
- adding new product 
- showing all products
