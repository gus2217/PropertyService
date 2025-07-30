namespace KejaHUnt_PropertiesAPI.Models.Domain
{
    public class PendingPolicyDescription
    {
        public long Id { get; set; }
        public string Name { get; set; }

        // Foreign key
        public long PolicyId { get; set; }

        // Navigation property
        public Policy Policy { get; set; }

        // Foreign key
        public long PendingPropertyId { get; set; }

        // Navigation property
        public PendingProperty PendingProperty { get; set; }
    }
}
