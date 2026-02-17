namespace Inventory_Management_System
{
    class Clothing : Product
    {
        public string Size { get; set; }
        public string FabricType { get; set; }
        public string Gender { get; set; }
        public string Color { get; set; }
        public override void Verify()
        {
            if (Size != "S" || Size != "M" || Size != "L" || Size != "XL" || Size != "XXL" )
            {
                throw new Exception("Invalid Size");
            }
            if (Gender != "Male" || Gender != "Female" || Gender != "Unisex" )
            {
                throw new Exception("Wrong Gender chosen");
            }
        }

    }

}