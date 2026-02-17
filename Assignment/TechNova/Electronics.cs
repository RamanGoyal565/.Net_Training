namespace Inventory_Management_System
{
    class Electronics : Product
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int WarrantPeriod { get; set; }
        public int PowerUsage { get; set; }
        public DateTime ManufacturingDate { get; set; }

        public override void Verify()
        {
            if (WarrantPeriod<0)
            {
                throw new Exception("Warranty months cannot be negative");
            }
            if (ManufacturingDate>DateTime.Now)
            {
                throw new Exception("Manufacturing Date is incorrect");
            }
        }


    }
}