namespace DominionCardTracker.Models.Tables
{
    public class CardModifier
    {
        public int CardModifierId { get; set; }
        public int CardId { get; set; }
        public int ModifierTypeId { get; set; }
        public int? ModifierValue { get; set; }
        public string InstructionText { get; set; }

    }
}
