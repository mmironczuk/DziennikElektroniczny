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

    public class EditMarkModel : PageModel
    {
        [BindProperty]
        public Ocena ocena { get; set; }
        public IConfiguration _configuration { get; }
        public EditMarkModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void OnGet(int id)
        {
            ocena = new Ocena();
            ocena.idoceny = id;
            string DziennikDBcs = _configuration.GetConnectionString("DziennikDB");
            SqlConnection con = new SqlConnection(DziennikDBcs);
            string sql = "SELECT * FROM Ocena WHERE IDoceny=@ID";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ID", ocena.idoceny);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ocena.idoceny = id;
                ocena.mark = reader["wartosc"].ToString();
                ocena.opis = reader["opis"].ToString();
            }
            reader.Close();
            con.Close();
        }
        public IActionResult OnPost(Ocena ocena, int id)
        {
            if (id == 0)
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }
                string DziennikDBcs = _configuration.GetConnectionString("DziennikDB");
                SqlConnection con = new SqlConnection(DziennikDBcs);
                string sql = "UPDATE Ocena SET wartosc=@WARTOSC, opis=@OPIS WHERE IDoceny=@ID";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@ID", ocena.idoceny);
                cmd.Parameters.AddWithValue("@WARTOSC", ocena.mark);
                cmd.Parameters.AddWithValue("@OPIS", ocena.opis);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            if (id == 1)
            {
                string DziennikDBcs = _configuration.GetConnectionString("DziennikDB");
                SqlConnection con = new SqlConnection(DziennikDBcs);
                string sql = "DELETE FROM Ocena WHERE IDoceny=@ID";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@ID", ocena.idoceny);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return RedirectToPage("Index");
        }
    }
}