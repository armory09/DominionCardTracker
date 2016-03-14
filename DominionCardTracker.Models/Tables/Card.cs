namespace DominionCardTracker.Models.Tables
{
    public class Card
    {
        public int CardId { get; set; }
        public int CardSetId { get; set; }
        public int CardCost { get; set; }
        public string CardTitle { get; set; }
        public string ImagePath { get; set; }
    }
}
