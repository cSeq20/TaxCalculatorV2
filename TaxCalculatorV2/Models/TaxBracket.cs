namespace TaxCalculatorV2.Models
{
    public record TaxBracket
    {
        public decimal LowerBracket { get; set; }
        public decimal UpperBracket { get; set; }
        public decimal TaxRate { get; set; }
    }
}
