using System.Web.Mvc;
using DominionCardTracker.DataLayer.Repository;
using DominionCardTracker.Models.Tables;

namespace DominionCardTracker.Web.Controllers
{
    public class CardSetController : Controller
    {
        // GET: CardSet


        private readonly CardSetRepository _repo = new CardSetRepository();
        public ActionResult Index()
        {
            var model = _repo.SelectAll();
            return View(model);
        }

        public ActionResult Create()
        {
            var model = new CardSet();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(string cardSetName)
        {
            var newCardset = new CardSet()
            {
                CardSetName = cardSetName
            };
            _repo.Insert(newCardset);
            return RedirectToAction("Index");
        }
    }
}