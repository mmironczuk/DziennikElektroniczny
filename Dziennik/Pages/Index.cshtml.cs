using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dziennik.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Dziennik.Pages
{
    public class IndexModel : PageModel
    {
        public List<Uczen> uczniowie_test = new List<Uczen>();
        private readonly ILogger<IndexModel> _logger;
        public IConfiguration _configuration { get; }
        public IndexModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public int lastID;
        public void OnGet()
        {
            /*string DziennikDBcs = _configuration.GetConnectionString("DziennikDB");
            SqlConnection con = new SqlConnection(DziennikDBcs);
            string sql = "SELECT * FROM Uczen";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Uczen p = new Uczen();
                p.id = Convert.ToInt32(reader["Id"].ToString());
                p.name = reader["name"].ToString();
                p.surname = reader["surname"].ToString();
                uczniowie_test.Add(p);
            }
            reader.Close();
            con.Close();*/
            uczniowie_test.Add(new Uczen { id=0, name="Wojtek", surname="Kowalski"});
            uczniowie_test.Add(new Uczen { id = 1, name = "Konrad", surname = "Nowak" });
            uczniowie_test.Add(new Uczen { id = 2, name = "Grzegorz", surname = "Mickiewicz" });
            lastID = uczniowie_test.Count;
        }
    }
}
