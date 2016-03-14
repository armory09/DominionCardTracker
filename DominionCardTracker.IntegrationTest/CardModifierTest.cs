using DominionCardTracker.DataLayer.Repository;
using NUnit.Framework;

namespace DominionCardTracker.IntegrationTest
{
    [TestFixture]
    public class CardModifierTest
    {
        [SetUp]
        public void Init()
        {
            var repo = new DatabaseResetRepository();
            repo.ResetDatabase();
        }

        [Test]
        public void SelectByCardIdTest()
        {
            var repo = new CardModifierRepository();
            var result = repo.SelectByCardId(2);
             Assert.AreEqual(0, result.Count);
        }
    }
}
