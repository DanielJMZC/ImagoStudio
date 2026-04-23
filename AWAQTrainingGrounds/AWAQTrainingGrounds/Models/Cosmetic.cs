// Nuestro modelo cosmetic con su respectiva información.
namespace AWAQTrainingGrounds.Models
{
    public class Cosmetic
    {
        public int cosmetic_id { get; set; }
        public int cosmeticType_id { get; set; }
        public int price { get; set; }
        public string image_path { get; set; }
    }
}

