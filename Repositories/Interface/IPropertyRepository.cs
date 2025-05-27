using KejaHUnt_PropertiesAPI.Models.Domain;
using KejaHUnt_PropertiesAPI.Models.Dto;

namespace KejaHUnt_PropertiesAPI.Repositories.Interface
{
    public interface IPropertyRepository
    {
        Task<Property> CreatePropertyAsync(Property property, long[] generalFeatureIds, long[] indoorFeaturesIds, long[] outdoorFeaturesIds);

        Task<IEnumerable<Property>> GetAllAsync();

        Task<Property?> GetPropertyByIdAsync(long id);

        Task<Property?> UpdateAsync(Property property);


        Task<Property?> DeleteAync(long id);
    }
}
