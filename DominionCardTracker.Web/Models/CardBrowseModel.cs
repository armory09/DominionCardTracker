using System.Collections.Generic;
using DominionCardTracker.Models.Tables;

namespace DominionCardTracker.Web.Models
{
    public class CardBrowseModel
    {
        public List<CardSet> CardSets { get; set; }
        public List<Card> SelectedCards { get; set; }
    }
}