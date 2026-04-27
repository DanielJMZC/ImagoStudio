namespace AWAQTrainingGrounds.Models
{
    public class Cosmetic
    {
        public int cosmetic_id { get; set; }
        public int cosmeticType_id { get; set; }
        public int price { get; set; }
        public string? cosmetic_name { get; set; }
        public string? profile_url { get; set; }
        public string? avatar_url { get; set; }
    }
}
