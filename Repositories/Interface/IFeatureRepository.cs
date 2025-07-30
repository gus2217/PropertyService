using KejaHUnt_PropertiesAPI.Models.Domain;
using KejaHUnt_PropertiesAPI.Models.Dto;

namespace KejaHUnt_PropertiesAPI.Repositories.Interface
{
    public interface IFeatureRepository
    {
        Task<GeneralFeatures> CreateGenralFeatureAsync(GeneralFeatures request);
        Task<List<FeaturesDto>> GetAllGeneralFeaturesAsync();
        Task<IndoorFeatures> CreateIndoorFeatureAsync(IndoorFeatures request);
        Task<List<FeaturesDto>> GetAllIndoorFeaturesAsync();
        Task<OutDoorFeatures> CreateOutdoorFeatureAsync(OutDoorFeatures request);
        Task<List<FeaturesDto>> GetAllOutdoorFeaturesAsync();
        Task<List<PolicyDto>> GetAllPoliciessAsync();
        Task<PolicydescriptionDto> CreatePolicyDescriptionAsync(CreatePolicyDto request);
        Task<PolicydescriptionDto> AddPolicyDescriptionAsync(PolicyDescription request);
        Task<PolicydescriptionDto?> UpdatePolicyDescriptionAsync(UpdatePolicyDescriptionDto request);
        Task<PolicyDto?> GetPolicyByIdAsync(long id);
        Task<List<PendingPolicyDescription?>> GetPolicyDescriptionByPropertyIdAsync(long id);
    }
}
