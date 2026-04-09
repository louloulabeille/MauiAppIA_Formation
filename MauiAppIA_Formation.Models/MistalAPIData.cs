namespace MauiAppIA_Formation.Models
{
    public class MistalAPIData
    {
        public string? Agent_id { get; set; }
        public int? Agent_Version { get; set; }
        public List<Imput>? Imputs { get; set; } = new List<Imput>();
    }
}
