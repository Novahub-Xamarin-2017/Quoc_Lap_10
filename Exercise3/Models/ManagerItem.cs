using System.Runtime.Serialization;

namespace Exercise3.Models
{
    public class ManagerItem 
    {
        public int Image { get; set; }

        public string Name { get; set; }

        public ManagerItem()
        {
        }

        public ManagerItem(int image, string name)
        {
            Image = image;
            Name = name;
        }
    }
}