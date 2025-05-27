﻿namespace KejaHUnt_PropertiesAPI.Models.Domain
{
    public class Property
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public Guid? DocumentId { get; set; }
        public ICollection<Unit?> Units { get; set; } = new List<Unit>();
        public ICollection<GeneralFeatures?> GeneralFeatures { get; set; } = new List<GeneralFeatures>();
        public ICollection<IndoorFeatures?> IndoorFeatures { get; set; } = new List<IndoorFeatures>();
        public ICollection<OutDoorFeatures?> OutdoorFeatures { get; set; } = new List<OutDoorFeatures>();
        public ICollection<PolicyDescription?> PolicyDescriptions { get; set; }
    }
}
