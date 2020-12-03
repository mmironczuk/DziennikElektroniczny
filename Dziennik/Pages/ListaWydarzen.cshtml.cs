using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Dziennik.DAL;
using Dziennik.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dziennik.Pages
{
    public class ListaWydarzenModel : PageModel
    {
        public static ObservableCollection<Wydarzenie> wydarzenia;

        public static int typ_uzytkownika;

        public MainDatabase db = new MainDatabase();

        public void OnGet()
        {
            wydarzenia = db.GetWydarzeniaAll();


            /*for (int i = 0; i < 6; i++)
            {
                Wydarzenie rect = new Wydarzenie();
                rect.nazwa = "Sprawdzianik";
                rect.opis = "odbedzie sie sprawdzianik numer " + i;

                Nauczyciel na = new Nauczyciel();
                na.imie = "Alicja";
                na.nazwisko = "Brycha";

                rect.Nauczyciel = na;

                //DateTime czas = new DateTime(DateTime.Now);
                rect.data = DateTime.Now;

                Przedmiot prze = new Przedmiot();
                prze.nazwa = "Pszyrka";

                rect.Przedmiot = prze;

                wydarzenia.Add(rect);
            }*/
        }

        public IActionResult OnPost()
        {
            return null;
        }
    }
}