namespace KejaHUnt_PropertiesAPI.Models.Domain
{
    public class PolicyDescription
    {
        public long Id { get; set; }
        public string Name { get; set; }

        // Foreign key
        public long PolicyId { get; set; }

        // Navigation property
        public Policy Policy { get; set; }

        // Foreign key
        public long PropertyId { get; set; }

        // Navigation property
        public Property Property { get; set; }
    }
}
