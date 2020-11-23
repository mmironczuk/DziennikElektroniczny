using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Dziennik.DAL;
using Dziennik.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
//using Oracle.ManagedDataAccess.Client;
//using Oracle.DataAccess.Client;

namespace Dziennik.Pages
{
    public class IndexModel : PageModel
    {
        public List<Uczen2> uczniowie_test=new List<Uczen2>();
        private readonly ILogger<IndexModel> _logger;
        //private MainDatabase mainDatabase=new MainDatabase();
        public IConfiguration _configuration { get; }
        public IndexModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public int lastID;
        public Ocena ocena;
        public List<Ocena> marks;
        public void OnGet()
        {
            uczniowie_test.Add(new Uczen2 { Id_ucznia=0, imie="Wojtek", nazwisko="Kowalski"});
            uczniowie_test.Add(new Uczen2 { Id_ucznia = 1, imie = "Konrad", nazwisko = "Nowak" });
            uczniowie_test.Add(new Uczen2 { Id_ucznia = 2, imie = "Grzegorz", nazwisko = "Mickiewicz" });
            lastID = uczniowie_test.Count;
            //-- Do połączenia z bazą --
            //uczniowie_test = mainDatabase.GetUczniowie();
            //string DziennikDBcs = _configuration.GetConnectionString("DziennikDB");
            //SqlConnection con = new SqlConnection(DziennikDBcs);
            foreach (Uczen2 u in uczniowie_test)
            {
                marks = new List<Ocena>();
                u.oceny = marks;
                //-- Podzapytanie do bazy lokalnej --
                /*string sql = "SELECT IDoceny, wartosc FROM Ocena WHERE IDucznia=@ID";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@ID", u.id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ocena = new Ocena();
                    ocena.idoceny = Int32.Parse(reader["IDoceny"].ToString());
                    ocena.mark = reader["wartosc"].ToString();
                    marks.Add(ocena);
                }
                reader.Close();
                u.oceny = marks;
                con.Close();*/
            }
        }
    }
}
