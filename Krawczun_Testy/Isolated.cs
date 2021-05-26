using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Krawczun_Testy
{
    class Isolated : Attribute, ITestAction
    {
        private TransactionScope _transactionScope;
        public ActionTargets Targets 
        {
            get { return ActionTargets.Test; }
        }

        public void BeforeTest(ITest test)
        {
            _transactionScope = new TransactionScope();
        }

        public void AfterTest(ITest test)
        {
            _transactionScope.Dispose();
        }

    }
}
