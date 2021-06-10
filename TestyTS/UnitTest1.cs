using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace TestyTS
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<Semestr> sems = new List<Semestr>();
            sems.Add(new Semestr(1, Convert.ToDateTime("20/02/2021"), Convert.ToDateTime("20/06/2021")));
            sems.Add(new Semestr(2, Convert.ToDateTime("01/10/2020"), Convert.ToDateTime("19/02/2021")));
            sems.Add(new Semestr(3, Convert.ToDateTime("20/02/2020"), Convert.ToDateTime("20/06/2020")));

            List<Ocena> oceny = new List<Ocena>();
            oceny.Add(new Ocena(1, 1, 2, "4", "moglo byc lepiej", Convert.ToDateTime("20/04/2021")));
            oceny.Add(new Ocena(2, 1, 2, "4", "mozesz znacznie lepiej", Convert.ToDateTime("20/05/2021")));
            oceny.Add(new Ocena(3, 1, 2, "5", "lepiej byc nie moglo", Convert.ToDateTime("20/01/2021")));

            Assert.AreEqual(Znajdz(oceny, sems[0]), 2);
            Assert.AreEqual(Znajdz(oceny, sems[1]), 1);
            Assert.AreEqual(Znajdz(oceny, sems[2]), 0);
        }

        [TestMethod]
        public void TestMethod2()
        {
            List<Ocena> oceny = new List<Ocena>();
            oceny.Add(new Ocena(1, 1, 2, "4", "moglo byc lepiej", Convert.ToDateTime("20/04/2021")));
            oceny.Add(new Ocena(2, 1, 2, "4", "mozesz znacznie lepiej", Convert.ToDateTime("20/05/2021")));
            oceny.Add(new Ocena(3, 1, 2, "5", "lepiej byc nie moglo", Convert.ToDateTime("20/01/2021")));

            Assert.AreEqual(Wyszukiwarka(oceny, "lepiej"), 3);
            Assert.AreEqual(Wyszukiwarka(oceny, "byc"), 2);
            Assert.AreEqual(Wyszukiwarka(oceny, "tak"), 0);
            Assert.AreEqual(Wyszukiwarka(oceny, "nie"), 2);
        }

        //Symulacja dzia³ania wyszukiwania odpowiednich ocen do semestru
        public int Znajdz(List<Ocena> lista, Semestr sem)
        {
            int count = 0;
            foreach (var item in lista) if (item.dataDodania > sem.dataRozpoczecia && item.dataDodania < sem.dataZakonczenia) count++;

            return count;
        }

        //Symulacja dzia³ania filtrowania np. wiadomoœci
        public int Wyszukiwarka(List<Ocena> lista, string toSearch)
        {
            List<Ocena> result = new List<Ocena>();

            string[] words = toSearch.Split(' ');
            words = words.Where(item => item != "").ToArray();
            foreach (var item in lista)
                foreach (var word in words) if (item.opis.Contains(word) && !result.Contains(item)) result.Add(item); 

            return result.Count;
        }
    }
}
