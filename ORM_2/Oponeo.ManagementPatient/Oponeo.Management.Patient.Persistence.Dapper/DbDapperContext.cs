namespace Oponeo.ManagementPatient.Persistence.Dapper
{
    internal class DbDapperContext
    {
        public string ConnectionString { get; }

        public DbDapperContext()
        {
            ConnectionString = "data source=WS-140P9K3;initial catalog=Patient_Db_Management;user id=sa;password=SQL2019_adm;MultipleActiveResultSets=True";
        }
    }
}
