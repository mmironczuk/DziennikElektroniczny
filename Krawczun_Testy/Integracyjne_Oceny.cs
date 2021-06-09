using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dziennik.Models;
using Dziennik.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using Xunit;
using System;

namespace Krawczun_Testy
{
    [TestClass]
    public class Integracyjne_Oceny : IDisposable
    {
        private ApplicationDbContext _context;
        public void DB_Creation()
        {
            var serviceProvider = new ServiceCollection().AddEntityFrameworkSqlServer().BuildServiceProvider();
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

            builder.UseSqlServer($"server=212.33.90.100;port=3306;user=cb20dzeluser;password=sdfg324fsd!@;database=cb20dzel").UseInternalServiceProvider(serviceProvider);

            _context = new ApplicationDbContext(builder.Options);
            _context.Database.Migrate();
        }
        [Fact]
        public void AddAGradeTest()
        {
            _context.Ocena.Add(new Ocena { data = DateTime.Today, wartosc = "3", 
                                            KontoId = 1, opis = "test", koncowa = 1 });
            _context.SaveChanges();
            Assert.Equals(1, 1);
        }
        public void Dispose()
        {
            _context.Database.EnsureDeleted();
        }
    }
}
