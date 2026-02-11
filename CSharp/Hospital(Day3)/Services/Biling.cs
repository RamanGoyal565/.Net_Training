class Billing
{
    public double consultationFee;
    public double testCharges;
    public double roomCharges;

    public double Total()
    {
        return consultationFee + testCharges + roomCharges;
    }
}