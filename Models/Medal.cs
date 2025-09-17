namespace OlympicMedalsApi.Models
{
    public class Medal
    {
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty; // e.g., Gold, Silver, Bronze
        public int CountryId { get; set; }

        // Navigation property
        public Country Country { get; set; }
    }
}
