using KejaHUnt_PropertiesAPI.Models.Domain;
using KejaHUnt_PropertiesAPI.Models.Dto;

namespace KejaHUnt_PropertiesAPI.Repositories.Interface
{
    public interface IPendingPropertyRepository
    {
        Task<PendingPropertyDto> AddAsync(PendingProperty pendingProperty, long[] generalFeatureIds, long[] indoorFeaturesIds, long[] outdoorFeaturesIds);
        Task<PendingProperty?> GetByIdAsync(long id);
        Task<IEnumerable<PendingProperty>> GetAllAsync();
        Task DeleteAsync(PendingProperty pendingProperty);
    }
}
