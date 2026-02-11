class InputValidator
{
    public static int ReadAge(string input)
    {
        if (int.TryParse(input, out int age))
        {
            return age;
        }
        else
        {
            throw new Exception("Invalid age input. Please enter a valid integer.");
        }
    }
}