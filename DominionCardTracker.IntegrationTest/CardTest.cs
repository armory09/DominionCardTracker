using System.Linq;
using DominionCardTracker.DataLayer.Repository;
using DominionCardTracker.Models.Tables;
using NUnit.Framework;

namespace DominionCardTracker.IntegrationTest
{
    [TestFixture]
    public class CardTest
    {
        [SetUp]
        public void Init()
        {
            var repo = new DatabaseResetRepository();
            repo.ResetDatabase();
        }

        [Test]
        public void InsertTest()
        {
            var repo = new CardRepository();

            var newCard = new Card
            {
                CardSetId = 1,
                CardCost = 2,
                CardTitle = "Estate",
                ImagePath = "estate.jpg"
            };

            var result = repo.Insert(newCard);

            Assert.AreEqual(84, result.CardId);
        }
        [Test]
        public void SelectAllTest()
        {
            var repo = new CardRepository();
            var result = repo.SelectAll();

            Assert.AreEqual(83, result.Count());
        }

        [Test]
        public void UpdateTest()
        {
            var repo = new CardRepository();
            var card = new Card
            {
                CardId = 1,
                CardSetId = 1,
                CardTitle = "Updated",
                CardCost = 5,
                ImagePath = "foo.jpg"
            };

            repo.Update(card);
        }

        [Test]
        public void SelectByIdtest()
        {
            var repo = new CardRepository();
            var id = 1;
            var result = repo.SelectById(id);

            Assert.AreEqual(1,result.Count());
        }

        [Test]
        public void DeleteTest()
        {
            var repo =new CardRepository();
            repo.Delete(1);

            var result = repo.SelectAll();
            Assert.AreEqual(82, result.Count());
        }

        [Test]
        public void SelectViewTest()
        {
            var repo = new CardRepository();
            var result = repo.SelectView(1);

            Assert.AreEqual(1, result.Categories.Count);
            Assert.AreEqual(1,result.Modifiers.Count);
        }

    }
}
