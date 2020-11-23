using Dziennik.Models;
using Microsoft.Azure.Amqp.Framing;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Dziennik.DAL
{
    public class MainDatabase:Database
    {
        private readonly ISession _session;
        private ITransaction _transaction;

        /*public MainDatabase(ISession session)
        {
            _session = session;
        }*/
        public override IList<Uczen> GetUczniowie()
        {
            using(NHibernate.ISession session=NHibernateHelper.OpenSession())
            {
                var Uczniowie = session.Query<Uczen>().ToList();
                return Uczniowie;
            }
            
        }
    }
}
