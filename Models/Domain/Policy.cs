namespace KejaHUnt_PropertiesAPI.Models.Domain
{
    public class Policy
    {
        public long Id { get; set; }
        public string Name { get; set; }

        // Navigation property: one Policy has many PolicyDescriptions
        public ICollection<PolicyDescription> PolicyDescriptions { get; set; } = new List<PolicyDescription>();
    }
}
