﻿using System.Linq;
using System.Net;
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
            var cardSetRepo = new CardSetRepository();
            var cardRepo = new CardRepository();
            var modifierTypeRepo = new ModifierTypeRepository();

            var model = new CardEditModel(cardRepo.SelectView(id), cardSetRepo.SelectAll(), modifierTypeRepo.SelectAll());

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Card card)
        {
            var cardRepo = new CardRepository();
            cardRepo.Update(card);

            return RedirectToAction("Index", "Cards");
        }

        [HttpPost]
        public ActionResult Removemodifier(int id)
        {
            var cardModifierRepo = new CardModifierRepository();
            cardModifierRepo.Delete(id);

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        [HttpPost]
        public JsonResult AddModifier(CardModifier model)
        {
            var cardModifierRepo = new CardModifierRepository();
            var cardRepo = new CardRepository();

            cardModifierRepo.Insert(model);
            return Json(cardRepo.SelectView(model.CardId), JsonRequestBehavior.AllowGet);
        }
    }
}