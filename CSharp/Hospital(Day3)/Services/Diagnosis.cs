class Diagnosis
{
    public static void Evaluate(in int age,ref string condition,out string riskLevel,params int[] testScores)
    {
        int sum = 0;
        foreach (int score in testScores)
        {
            sum += score;
        }
        static bool IsCritical(int total)
        {
            return total > 250;
        }
        if (IsCritical(sum) || age > 60)
        {
            condition = "Serious";
            riskLevel = "High";
        }
        else
        {
            riskLevel = "Moderate";
        }
    }
}