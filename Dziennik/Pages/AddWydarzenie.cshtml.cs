using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dziennik.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dziennik.Pages
{
    public class AddWydarzenieModel : PageModel
    {
        public Wydarzenie wydarzenie;
        public static DateTime datka = DateTime.Now;
        public static List<Klasa> klasy;
        public static List<Przedmiot> przedmioty;

        public void OnGet(int idNauczyciela)
        {
            wydarzenie = new Wydarzenie();

            klasy = new List<Klasa>();
            for (int i = 0; i < 5; i++)
            {
                var elo = new Klasa();
                elo.nazwa = i.ToString();

                klasy.Add(elo);
            }

            przedmioty = new List<Przedmiot>();
            for (int i = 0; i < 5; i++)
            {
                var elo = new Przedmiot();
                elo.nazwa = (i * 2).ToString();

                przedmioty.Add(elo);
            }
        }

        public IActionResult OnPost()
        {
            return null;
        }
    }
}