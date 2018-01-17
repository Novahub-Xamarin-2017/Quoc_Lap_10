namespace Exercise2.Models
{
    public class Product
    {
        public string Name { get; set; }
        public int UnitPrice { get; set; }
        public string UnitType { get; set; }
        public int Count { get; set; }
        public string Image { get; set; }

        public int Price => Count * UnitPrice;
    }
}