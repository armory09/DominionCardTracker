using System.Linq;
using DominionCardTracker.DataLayer.Repository;
using DominionCardTracker.Models.Tables;
using NUnit.Framework;

namespace DominionCardTracker.IntegrationTest
{
    [TestFixture]
    public class CardSetTests
    {
        [SetUp]
        public void Init()
        {
            var repo = new DatabaseResetRepository();
            repo.ResetDatabase();
        }

        [Test]
        public void SelectAllTest()
        {
            var repo = new CardSetRepository();
            var results = repo.SelectAll();

            Assert.AreEqual(8, results.Count());
        }

        [Test]
        public void InsertTest()
        {
            var repo =  new CardSetRepository();
            var newCardSet = new CardSet {CardSetName = "Seaside"};

            repo.Insert(newCardSet);

            Assert.AreEqual(9, repo.SelectAll().Count());
        }
    }
}
