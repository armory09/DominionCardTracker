using System.ComponentModel;

namespace DominionCardTracker.Models.Tables
{
    public class CardSet
    {
        public int CardSetId { get; set; }

        [DisplayName("Card Set")]
        public string CardSetName { get; set; }
    }
}
