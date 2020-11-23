using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.AspNetCore.Http;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dziennik.DAL;
using NHibernate;
using MySqlX.XDevAPI;
using NHibernate.Tool.hbm2ddl;
using Dziennik.Mappings;

namespace Dziennik
{
    public class NHibernateHelper
    {
        private static NHibernate.ISessionFactory _sessionFactory;
        private static NHibernate.ISessionFactory SessionFactory
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
            _sessionFactory = Fluently.Configure().Database(OracleClientConfiguration.Oracle10
                .Driver<NHibernate.Driver.OracleManagedDataClientDriver>()
                .ConnectionString("Data Source=212.33.90.213:1521/XE;User Id=SBD_ST_PS4_4;Password=SBD_ST_PS4_4"))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Database>())
                //.Mappings(m => m.FluentMappings.Add<Mappings.UczenMapping>())
                //.ExposeConfiguration(cfg=>new SchemaExport(cfg).Create(true,true))
                .ExposeConfiguration(config =>
                {
                  SchemaExport schemaExport = new SchemaExport(config);
                })
                .BuildSessionFactory();
        }
        public static NHibernate.ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
