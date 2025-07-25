using Microsoft.AspNetCore.Mvc;

namespace KejaHUnt_PropertiesAPI.Models.Dto
{
    public class PendingPropertyRequestDto
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }

        [FromForm(Name = "generalFeatures")]
        public long[]? GeneralFeatures { get; set; }

        [FromForm(Name = "indoorFeatures")]
        public long[]? IndoorFeatures { get; set; }

        [FromForm(Name = "outdoorFeatures")]
        public long[]? OutdoorFeatures { get; set; }

        [FromForm(Name = "imageFile")]
        public IFormFile ImageFile { get; set; }
    }
}
