namespace KejaHUnt_PropertiesAPI.Models.Domain
{
    public class OutDoorFeatures
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public ICollection<Property> Properties { get; set; }
    }
}
