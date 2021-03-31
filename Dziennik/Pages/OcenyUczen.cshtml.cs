using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Dziennik.DAL;
using Dziennik.Models;
using FluentNHibernate.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dziennik.Pages
{
    public class OcenyUczenModel : PageModel
    {
        public ObservableCollection<Przedmiot> przedmioty = new ObservableCollection<Przedmiot>();
        private MainDatabase mainDatabase = new MainDatabase();
        public int id_ucznia;
        public double srednia_ucznia;
        public double[] srednie_uczniow = new double[1000];
        public List<double> lista_srednich = new List<double>();
        public double[] licznosci_ocen_uczniow = new double[1000];
        public int ranking_ucznia;
        public int ilosc_uczniow;

        [BindProperty]
        public string semesterTitle { get; set; }
        public void OnGet()
        {
            Ocena ocena = new Ocena();
            DateTime datka = ocena.Przedmiot.Nauczanie[0].Lekcja[0].data;
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            var id = Int32.Parse(claim.Value);
            id_ucznia = id;
            przedmioty = mainDatabase.GetPrzedmiotyAll();

            foreach (var przedmiot in przedmioty)
            {
                foreach (var uczen in przedmiot.Ocena.ToList())
                {
                    var id_temp = uczen.Uczen.Id_ucznia;
                    if (licznosci_ocen_uczniow[id_temp] > -1)
                    {
                        licznosci_ocen_uczniow[id_temp]++;
                    }
                    else
                    {
                        licznosci_ocen_uczniow[id_temp] = 0;
                        srednie_uczniow[id_temp] = 0;
                    }
                    if ((uczen.ocena).Contains('+'))
                    {
                        if (uczen.ocena == "1+") { srednie_uczniow[id_temp] += 1.5; }
                        if (uczen.ocena == "2+") { srednie_uczniow[id_temp] += 2.5; }
                        if (uczen.ocena == "3+") { srednie_uczniow[id_temp] += 3.5; }
                        if (uczen.ocena == "4+") { srednie_uczniow[id_temp] += 4.5; }
                        if (uczen.ocena == "5+") { srednie_uczniow[id_temp] += 5.5; }
                    }
                    else if ((uczen.ocena).Contains('-'))
                    {
                        if (uczen.ocena == "2-") { srednie_uczniow[id_temp] += 1.75; }
                        if (uczen.ocena == "3-") { srednie_uczniow[id_temp] += 2.75; }
                        if (uczen.ocena == "4-") { srednie_uczniow[id_temp] += 3.75; }
                        if (uczen.ocena == "5-") { srednie_uczniow[id_temp] += 4.75; }
                        if (uczen.ocena == "6-") { srednie_uczniow[id_temp] += 5.75; }
                    }
                    else { srednie_uczniow[id_temp] += Convert.ToDouble(uczen.ocena); }
                }
            }
            int counter = 0;
            while (srednie_uczniow.Length > counter)
            {
                srednie_uczniow[counter] = srednie_uczniow[counter] / licznosci_ocen_uczniow[counter];
                if (srednie_uczniow[counter] > 0) lista_srednich.Add(srednie_uczniow[counter]);
                counter++;
            }
            lista_srednich.Sort();
            ranking_ucznia = lista_srednich.IndexOf(srednie_uczniow[id])+1;
            ilosc_uczniow = lista_srednich.Count;
            srednia_ucznia = Math.Round(srednie_uczniow[id],2);
        }

        public IActionResult OnPost(int id)
        {
            if(id == 1)
            {

            }
            if(id == 2)
            {

            }
            return RedirectToPage("OcenyUczen");
        }
    }
}