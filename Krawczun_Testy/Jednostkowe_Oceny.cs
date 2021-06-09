using Dziennik.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Krawczun_Testy
{
    [TestClass]
    public class Jednostkowe_Oceny
    {
        /// <summary>
        /// Liczenie średnich z wartości ocen w sposób identyczny jak na stronie z ocenami
        /// </summary>
        List<Ocena> listaOcen = new List<Ocena>();
        public void Stworz_Liste_Oceny()
        {
            Ocena ocena1 = new Ocena()
            {
                data = DateTime.Today,
                wartosc = "3",
                KontoId = 1,
                opis = "pierwsza",
                koncowa = 1
            };
            Ocena ocena2 = new Ocena()
            {
                data = DateTime.Today,
                wartosc = "2",
                KontoId = 1,
                opis = "druga",
                koncowa = 1
            };
            Ocena ocena3 = new Ocena()
            {
                data = DateTime.Today,
                wartosc = "4+",
                KontoId = 1,
                opis = "trzecia",
                koncowa = 1
            };
            
            listaOcen.Add(ocena1); listaOcen.Add(ocena2); listaOcen.Add(ocena3);
        }
        [TestMethod]
        public void Srednia_Ocen()
        {
            Stworz_Liste_Oceny();
            double srednia = 0;
            int ilosc = 0;
            foreach(var u in listaOcen)
            {
                    ilosc++;
                    if ((u.wartosc).Contains('+'))
                    {
                        if (u.wartosc == "1+") { srednia += 1.5; }
                        if (u.wartosc == "2+") { srednia += 2.5; }
                        if (u.wartosc == "3+") { srednia += 3.5; }
                        if (u.wartosc == "4+") { srednia += 4.5; }
                        if (u.wartosc == "5+") { srednia += 5.5; }
                    }
                    else if ((u.wartosc).Contains('-'))
                    {
                        if (u.wartosc == "2-") { srednia += 1.75; }
                        if (u.wartosc == "3-") { srednia += 2.75; }
                        if (u.wartosc == "4-") { srednia += 3.75; }
                        if (u.wartosc == "5-") { srednia += 4.75; }
                        if (u.wartosc == "6-") { srednia += 5.75; }
                    }
                    else { srednia += Convert.ToDouble(u.wartosc); }
                    
            }
            srednia /= ilosc;
            Assert.AreEqual((4.5+3+2)/3, srednia);
        }
    }
}
