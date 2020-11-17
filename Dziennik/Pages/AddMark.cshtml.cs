using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dziennik.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace Dziennik.Pages
{
    public class AddMarkModel : PageModel
    {
        public Ocena ocena { get; set; }
        public IConfiguration _configuration { get; }
        public AddMarkModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void OnGet(int _iducznia)
        {
            ocena = new Ocena();
            ocena.iducznia = _iducznia;
        }
        public IActionResult OnPost(Ocena ocena)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            string DziennikDBcs = _configuration.GetConnectionString("DziennikDB");
            SqlConnection con = new SqlConnection(DziennikDBcs);
            string sql = "INSERT INTO Ocena (idnauczyciela, idprzedmiotu, iducznia, wartosc, opis) VALUES (@IDNAUCZYCIELA, @IDPRZEDMIOTU, @IDUCZNIA, @WARTOSC, @OPIS)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@IDNAUCZYCIELA", 1);
            cmd.Parameters.AddWithValue("@IDUCZNIA", ocena.iducznia);
            cmd.Parameters.AddWithValue("@IDPRZEDMIOTU", 2);
            cmd.Parameters.AddWithValue("@WARTOSC", ocena.mark);
            cmd.Parameters.AddWithValue("@OPIS", ocena.opis);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return RedirectToPage("Index");
        }
    }
}