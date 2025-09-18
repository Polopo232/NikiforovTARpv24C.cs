namespace EsimeneTund.OOP
{
    internal class Palka : OOP.Töötaja
    {
        public decimal Palk;

        public void NäitaPalk()
        {
            Console.WriteLine($"{Nimi} teenib {Palk} EUR kuus.");

            decimal taxFreeAllowance = 654m;
            decimal taxableIncome = Palk - taxFreeAllowance;

            if (taxableIncome < 0)
                taxableIncome = 0;

            decimal incomeTaxRate = 0.20m;
            decimal incomeTax = taxableIncome * incomeTaxRate;

            decimal netSalary = Palk - incomeTax;

            Console.WriteLine($"Peale maksude tasumist on netopalk {netSalary} EUR.");
        }
    }
}
