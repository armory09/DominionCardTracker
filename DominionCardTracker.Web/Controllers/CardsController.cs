using System.Linq;
using System.Web.Mvc;
using DominionCardTracker.DataLayer.Repository;
using DominionCardTracker.Models.Tables;
using DominionCardTracker.Web.Models;

namespace DominionCardTracker.Web.Controllers
{
    public class CardsController : Controller
    {
        // GET: Card
        public ActionResult Index(int? id)
        {
            var cardSetRepo = new CardSetRepository();
            var model = new CardBrowseModel();

            model.CardSets = cardSetRepo.SelectAll();

            if (id.HasValue)
            {
                var cardsRepo = new CardRepository();
                model.SelectedCards = cardsRepo.SelectAll().Where(c => c.CardSetId == id).ToList();
            }

            return View(model);
        }

        public ActionResult Create()
        {
            var cardSetRepo = new CardSetRepository();
            var model = new CardCreateModel(cardSetRepo.SelectAll());

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Card newCard)
        {
            var cardRepo = new CardRepository();
            cardRepo.Insert(newCard);

            return RedirectToAction("Edit", new {id = newCard.CardId});
        }

        public ActionResult Edit(int id)
        {
            return View();
        }
    }
}