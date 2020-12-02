using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dziennik.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dziennik.Pages
{
    public class EdycjaWydarzeniaModel : PageModel
    {
        public Wydarzenie wydarzenie;
        public static Wydarzenie wydarzenieToShow;
        public static List<Przedmiot> przedmioty;
        public static List<Klasa> klasy;

        public void OnGet(int idWydarzenia)
        {
            klasy = new List<Klasa>();
            przedmioty = new List<Przedmiot>();
            wydarzenie = new Wydarzenie();
            wydarzenieToShow = new Wydarzenie();

            wydarzenieToShow = wydarzenie;

            wydarzenieToShow.nazwa = "abc";
            wydarzenieToShow.opis = "opis";
            wydarzenieToShow.data = DateTime.Now;
        }
    }
}