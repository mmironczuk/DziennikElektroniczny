using Dziennik.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Dziennik.DAL
{
    public abstract class Database
    {
        //public abstract ObservableCollection<Test> GetTests();
        public abstract IList<Uczen> GetUczniowie();
    }
}
