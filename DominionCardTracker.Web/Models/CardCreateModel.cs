using System.Collections.Generic;
using System.Web.Mvc;
using DominionCardTracker.Models.Tables;

namespace DominionCardTracker.Web.Models
{
    public class CardCreateModel
    {
        public Card NewCard { get; set; }
        public List<SelectListItem> CardSetOptions { get; set; }

        public CardCreateModel(List<CardSet> carSets)
        {
            CardSetOptions = new List<SelectListItem>();
            NewCard = new Card();

            foreach (var set in carSets)
            {
                CardSetOptions.Add(new SelectListItem
                {
                    Text = set.CardSetName,
                    Value = set.CardSetId.ToString()
                });
            }
        }
    }
}