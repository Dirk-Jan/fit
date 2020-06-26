using System.Linq;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OefeningService.DAL;
using OefeningService.Models;
using OefeningService.Repositories;
using OefeningService.Repositories.Abstractions;

namespace OefeningService.Test.Repository
{
    [TestClass]
    public class OefeningRepositoryTest
    {
        private static SqliteConnection _connection;
        private static DbContextOptions<OefeningContext> _options;
        private static OefeningContext _oefeningContext;

        [TestInitialize]
        public void ClassInitialize()
        {
            _connection = new SqliteConnection("DataSource=:memory:");
            _connection.Open();
            _options = new DbContextOptionsBuilder<OefeningContext>()
                .UseSqlite(_connection).Options;

            using var context = new OefeningContext(_options);
            context.Database.EnsureCreated();
            
            _oefeningContext = new OefeningContext(_options);
        }

        [TestCleanup]
        public void ClassCleanup()
        {
            _oefeningContext.Dispose();
            _connection.Close();
        }

        private IOefeningRepository GetOefeningRepository() => new OefeningRepository(_oefeningContext);
        private OefeningContext GetContext() => new OefeningContext(_options);
        
        [TestMethod]
        public void Add_ShouldIncrementDatabaseRowCount()
        {
            // Arrange
            var oefening = new Oefening();
            var target = GetOefeningRepository();

            // Act
            target.Add(oefening);

            // Assert
            using var context = GetContext();
            Assert.AreEqual(1, context.Oefeningen.Count());
        }
        
        [TestMethod]
        [DataRow("Bicep Curl", "Gebruik de bicep")]
        [DataRow("Lunges", "Gebruik de beentjes")]
        public void Add_ShouldAddItemToDatabase(string naam, string omschrijving)
        {
            // Arrange
            var oefening = new Oefening
            {
                Naam = naam,
                Omschrijving = omschrijving
            };
            var target = GetOefeningRepository();

            // Act
            target.Add(oefening);

            // Assert
            using var context = GetContext();
            var result = context.Oefeningen.Find(oefening.Id);
            Assert.AreEqual(oefening.Naam, result.Naam);
            Assert.AreEqual(oefening.Omschrijving, result.Omschrijving);
        }
    }
}