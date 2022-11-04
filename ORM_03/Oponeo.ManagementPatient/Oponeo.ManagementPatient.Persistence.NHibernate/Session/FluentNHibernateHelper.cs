using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Oponeo.ManagementPatient.Persistence.NHibernate.Mappings;

namespace Oponeo.ManagementPatient.Persistence.NHibernate.Session
{
    internal static class FluentNHibernateHelper
    {
        public static ISession OpenSession()
        {
            string connectionString = "data source=WS-140P9K3;initial catalog=Patient_Db_Management_NHibernate;user id=sa;password=SQL2019_adm;MultipleActiveResultSets=True";

            ISessionFactory sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                .ConnectionString(connectionString).ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<DoctorMap>())
                .ExposeConfiguration(cfg => new SchemaExport(cfg)
                .Create(true, false))
                .BuildSessionFactory();

            return sessionFactory.OpenSession();
        }

    }
}
