namespace KejaHUnt_PropertiesAPI.Models.Dto
{
    public class CreatePolicyDto
    {
        public string Name { get; set; }

        // Foreign key
        public long PolicyId { get; set; }
        public long PropertyId { get; set; }
    }
}
