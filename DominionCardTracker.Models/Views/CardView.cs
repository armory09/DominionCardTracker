using System.Collections.Generic;
using DominionCardTracker.Models.Tables;

namespace DominionCardTracker.Models.Views
{
    public class CardView : Card
    {
        public List<CardModifierView> Modifiers { get; set; }
        public List<Category> Categories { get; set; }

    }
}
