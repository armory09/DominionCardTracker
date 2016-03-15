using System.Collections.Generic;
using System.Web.Mvc;
using DominionCardTracker.Models.Tables;
using DominionCardTracker.Models.Views;

namespace DominionCardTracker.Web.Models
{
    public class CardEditModel
    {
        public CardView Card { get; set; }
        public List<SelectListItem> CardSetOptions { get; set; }
        public List<SelectListItem> CardModifierOptions { get; set; }

        public CardEditModel(CardView card, List<CardSet> cardSet, List<ModifierType> cardModifiers)
        {
            CardSetOptions = new List<SelectListItem>();
            CardModifierOptions = new List<SelectListItem>();
            Card = card;

            foreach (var set in cardSet)
            {
                CardSetOptions.Add(new SelectListItem
                {
                    Text = set.CardSetName,
                    Value = set.CardSetId.ToString()
                });
            }
            foreach (var mod in cardModifiers)
            {
                CardModifierOptions.Add(new SelectListItem
                {
                    Text = mod.ModifierTypeName,
                    Value = mod.ModifierTypeId.ToString()
                });
            }
        }
    }
}