## Task 3

### Create NHibernate persistence layer

1. In the `Patient management` project attached to previous session add new persistence project for NHibernate `Persistence.NHibernate`

2. Add `FluentNHibernateHelper` class like below.
```cs
 public static class FluentNHibernateHelper
    {
        public static ISession OpenSession()
        {
            string connectionString = "<YOUR_CONNECTION_STRING>";

            ISessionFactory sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                  .ConnectionString(connectionString).ShowSql()
                )
                .Mappings(m =>
                          m.FluentMappings
                              .AddFromAssemblyOf<DoctorMap>())
                .ExposeConfiguration(cfg => new SchemaExport(cfg)
                .Create(false, false))
                .BuildSessionFactory();

            return sessionFactory.OpenSession();

        }
```
3. Add map classes for all entites

```cs
internal class DoctorMap : ClassMap<Doctor>
    {
        public DoctorMap()
        {
            Id(x => x.Id);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Table("Doctors");
        }
    }
```

4. Implement all repositories using NHibernate ORM.

5. Provide implementations of repositories to the UI when service is invoked.
