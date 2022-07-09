namespace TaxCalculatorV2Tests
{
    public class StandardTaxBrackTests
    {
        [Fact]
        public void Test_tax_is_zero_given_earnings_are_zero()
        {
            var taxCalculator = new TaxCalculator();
            var taxAmount = taxCalculator.CalculateTax(earning => Math.Floor(earning), 0, new StandardTaxBracketRule());
            Assert.Equal(0, taxAmount);
        }

        [Fact]
        public void Test_tax_is_zero_if_earner_is_tax_exempt()
        {
            var taxCalculator = new TaxCalculator();
            var taxAmount = taxCalculator.CalculateTax(earning => Math.Floor(earning), 50000, new StandardTaxBracketRule(), true);
            Assert.Equal(0, taxAmount);
        }

        [Fact]
        public void Test_tax_calculation_if_earnings_input_is_decimal()
        {
            var taxCalculator = new TaxCalculator();
            var taxAmountWithDecimal = taxCalculator.CalculateTax(earning => Math.Floor(earning), 50000.65M, new StandardTaxBracketRule());

            var taxAmountWithoutDecimal = taxCalculator.CalculateTax(earning => Math.Floor(earning), 50000, new StandardTaxBracketRule());
            Assert.Equal(taxAmountWithDecimal, taxAmountWithoutDecimal);
        }

        [Fact]
        public void Test_tax_calculation_if_earnings_in_lowest_bracket()
        {
            var taxCalculator = new TaxCalculator();
            var taxAmount = taxCalculator.CalculateTax(earning => Math.Floor(earning), 20000, new StandardTaxBracketRule());
            Assert.Equal(6600, taxAmount);
        }

        [Fact]
        public void Test_tax_calculation_if_earnings_in_second_bracket()
        {
            var taxCalculator = new TaxCalculator();
            var taxAmount = taxCalculator.CalculateTax(earning => Math.Floor(earning), 40000, new StandardTaxBracketRule());
            Assert.Equal(11120, taxAmount);
        }

        [Fact]
        public void Test_tax_calculation_if_earnings_in_third_bracket()
        {
            var taxCalculator = new TaxCalculator();
            var taxAmount = taxCalculator.CalculateTax(earning => Math.Floor(earning), 60000, new StandardTaxBracketRule());
            Assert.Equal(14820, taxAmount);
        }

        [Fact]
        public void Test_tax_calculation_if_earnings_in_fourth_bracket()
        {
            var taxCalculator = new TaxCalculator();
            var taxAmount = taxCalculator.CalculateTax(earning => Math.Floor(earning), 150000, new StandardTaxBracketRule()); //chris' salary
            Assert.Equal(51920, taxAmount);
        }
    }
}