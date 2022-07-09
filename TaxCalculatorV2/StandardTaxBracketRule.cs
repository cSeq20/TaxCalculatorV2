using TaxCalculatorV2.Models;

namespace TaxCalculatorV2
{
    public class StandardTaxBracketRule : ITaxBracketRule
    {
        public decimal CalculateTaxInBracket(TaxBracket bracket, decimal earnings)
        {
            if (earnings < bracket.LowerBracket) return 0;
            
            var bandAmount = earnings > bracket.UpperBracket ? bracket.UpperBracket - bracket.LowerBracket : earnings - bracket.LowerBracket;
            return bandAmount * bracket.TaxRate;
        }
    }
}