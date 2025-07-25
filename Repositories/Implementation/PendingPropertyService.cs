using AutoMapper;
using KejaHUnt_PropertiesAPI.Models.Domain;
using KejaHUnt_PropertiesAPI.Models.Dto;
using KejaHUnt_PropertiesAPI.Repositories.Interface;

namespace KejaHUnt_PropertiesAPI.Repositories.Implementation
{
    public class PendingPropertyService : IPendingPropertyService
    {
        private readonly IPendingPropertyRepository _pendingRepo;
        private readonly IPropertyRepository _propertyRepo;
        private readonly IMapper _mapper;
        private readonly IFeatureRepository _featureRepository;

        public PendingPropertyService(IPendingPropertyRepository pendingRepo, IPropertyRepository propertyRepo, IMapper mapper, IFeatureRepository featureRepository)
        {
            _pendingRepo = pendingRepo;
            _propertyRepo = propertyRepo;
            _mapper = mapper;
            _featureRepository = featureRepository;
        }

        public async Task<PendingPropertyDto> SubmitAsync(PendingPropertyRequestDto dto, string userId, Guid documentId)
        {
            var pendingEntity = _mapper.Map<PendingProperty>(dto);
            pendingEntity.SubmittedByUserId = userId;
            pendingEntity.DocumentId = documentId;
            var property = await _pendingRepo.AddAsync(pendingEntity, dto.OutdoorFeatures, dto.IndoorFeatures, dto.GeneralFeatures);
            return property;
        }

        public async Task<IEnumerable<PendingPropertyRequestDto>> GetAllPendingAsync()
        {
            var pendingEntities = await _pendingRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<PendingPropertyRequestDto>>(pendingEntities);
        }

        public async Task ApproveAsync(long id)
        {
            var pending = await _pendingRepo.GetByIdAsync(id);
            if (pending == null)
                throw new Exception("Pending property not found.");
            var pendingPolicyDescriptions = await _featureRepository.GetPolicyDescriptionByPropertyIdAsync(id);
            var approvedProperty = _mapper.Map<Property>(pending);
            await _propertyRepo.AddAsync(approvedProperty);

            // Map and save policy descriptions with the generated PropertyId
            foreach (var pendingPolicy in pendingPolicyDescriptions)
            {
                var approvedPolicy = new PolicyDescription
                {
                    Name = pendingPolicy.Name,
                    PolicyId = pendingPolicy.PolicyId,
                    PropertyId = approvedProperty.Id // Use the now-generated ID
                };

                await _featureRepository.AddPolicyDescriptionAsync(approvedPolicy);
            }
            await _pendingRepo.DeleteAsync(pending);
        }
    }
}
