using TaxCalculatorV2.Models;

namespace TaxCalculatorV2
{
    public class TaxCalculator
    {
        private List<TaxBracket> _taxBrackets;

        public TaxCalculator()
        {
            _taxBrackets = new List<TaxBracket>()
            {
                new TaxBracket { TaxRate = 0.33M, LowerBracket = 0, UpperBracket = 24000},
                new TaxBracket { TaxRate = 0.175M, LowerBracket = 48000, UpperBracket = 80000 },
                new TaxBracket { TaxRate = 0.2M, LowerBracket = 24000, UpperBracket = 48000 },
                new TaxBracket { TaxRate = 0.48M, LowerBracket = 80000, UpperBracket = decimal.MaxValue }
            };
            _taxBrackets = _taxBrackets.OrderBy(bracket => bracket.LowerBracket).ToList();
        }

        public decimal CalculateTax(Func<decimal, decimal> prepareEarnings, decimal earnings, ITaxBracketRule rule, bool taxExempt = false)
        {
            return taxExempt ? 0 
                : _taxBrackets.Sum(bracket => rule.CalculateTaxInBracket(bracket, prepareEarnings(earnings)));
        }
    }
}