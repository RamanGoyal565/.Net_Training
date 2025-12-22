class InsuranceService
{
    public static double ApplyCoverage(double billAmount, int coveragePercent)
    {
        double discount = billAmount * coveragePercent / 100.0;
        double finalAmount = billAmount - discount;
        return finalAmount;
    }
}