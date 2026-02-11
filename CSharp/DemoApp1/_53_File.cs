class _53_File
{
    
}



class _53_Program
{
    public void Main()
    {
        string path = "Day14/_53_data.txt";
        File.WriteAllText(path,"File I/O Example in C#");
        Console.WriteLine("Data Writtent in file.");


        string path1 = "Day14/_53_data1.txt";
        File.WriteAllText(path1,"File I/O Example in C#");
        File.WriteAllText(path1,"Replacing the data in file.");
        Console.WriteLine("Data Writtent in file data1.");


        string content  = File.ReadAllText("Day14/_53_data.txt");
        Console.WriteLine("----------------File Content is ---------------- ");
        Console.WriteLine(content);


        using(StreamWriter writer = new StreamWriter("Day14/_53_log.txt"))
        {
            writer.WriteLine("Application Started");
            writer.WriteLine("Processing Data");
            writer.WriteLine("Application Ended");
        }

        using(StreamReader reader = new StreamReader("Day14/_53_log.txt"))
        {
            string line;
            while((line = reader.ReadLine())!= null)
            {
                Console.WriteLine(line);
            }
        }
    }
}