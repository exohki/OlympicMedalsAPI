namespace OlympicMedalsApi.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // Navigation property
        public List<Medal> Medals { get; set; } = new();
    }
}

