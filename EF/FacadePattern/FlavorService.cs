using System;
using System.Collections.Generic;
using System.Text;

namespace FacadePattern
{
    public class FlavorService
    {
        public string GetFlavor()
        {
            Console.WriteLine("Checking Available flavours...");
            return "Flavour";
        }
    }
}
