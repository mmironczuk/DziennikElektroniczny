using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySqlX.XDevAPI;

namespace Dziennik.Pages
{
    public class TestPAgeModel : PageModel
    {
        NHibernate.ISession session = NHibernateHelper.OpenSession();
        public void OnGet()
        {
        }
    }
}