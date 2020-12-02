using Dziennik.DAL;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Driver;
using NHibernate.Connection;
using NHibernate.Tool.hbm2ddl;
using System;
using Oracle.ManagedDataAccess.Client;
using FluentNHibernate.Automapping;
using Dziennik.Mappings;
using NHibernate.Cfg;

namespace Dziennik
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;
        private static ISessionFactory SessionFactory
        {
            get
            {
                if(_sessionFactory==null)
                {
                    InitializeSessionFactory();
                }
                return _sessionFactory;
            }
        }
        private static void InitializeSessionFactory()
        {
            _sessionFactory = Fluently.Configure().Database(OracleManagedDataClientConfiguration.Oracle10
                .ConnectionString("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=212.33.90.213)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=xe)));User Id=SBD_ST_PS4_4;Password=SBD_ST_PS4_4;")
                .Provider<DriverConnectionProvider>().Driver<OracleManagedDataClientDriver>()
                .ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<DAL.Database>())
                .BuildConfiguration()
                .BuildSessionFactory();
        }
        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
