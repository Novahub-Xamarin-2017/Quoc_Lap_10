using System.Runtime.Serialization;

namespace Exercise3.Models
{
    public class ManagerItem : ISerializable
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

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}