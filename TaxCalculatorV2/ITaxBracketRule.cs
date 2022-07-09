using TaxCalculatorV2.Models;

namespace TaxCalculatorV2
{
    public interface ITaxBracketRule
    {
        decimal CalculateTaxInBracket(TaxBracket bracket, decimal earnings);
    }
}
