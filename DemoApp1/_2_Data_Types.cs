class Data_Types{
    int NumInt;
    long NumLong;
    float NumFloat;
    double NumDouble;
    bool BoolInp;
    char CharInp;
    string StringInp;

    public Data_Types()
    {
        NumInt = 1000;
        NumLong = 1001L;
        NumFloat = 1002F;
        NumDouble = 1003.05D;
        BoolInp = false;
        CharInp = 'S';
        StringInp = "Sandeep";
    }

    public void PrintAll()
    {
        Console.WriteLine("int Data Type ::>> "+NumInt);
        Console.WriteLine("long Data Type ::>> "+NumLong);
        Console.WriteLine("float Data Type ::>> "+NumFloat);
        Console.WriteLine("double Data Type ::>> "+NumDouble);
        Console.WriteLine("bool Data Type ::>> "+BoolInp);
        Console.WriteLine("char Data Type ::>> "+CharInp);
        Console.WriteLine("string Data Type ::>> "+StringInp);
    }

}