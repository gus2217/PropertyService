using AutoMapper;
using KejaHUnt_PropertiesAPI.Data;
using KejaHUnt_PropertiesAPI.Models.Domain;
using KejaHUnt_PropertiesAPI.Models.Dto;
using KejaHUnt_PropertiesAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace KejaHUnt_PropertiesAPI.Repositories.Implementation
{
    public class FeatureRepository : IFeatureRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public FeatureRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<GeneralFeatures> CreateGenralFeatureAsync(GeneralFeatures request)
        {
            await _dbContext.GeneralFeatures.AddAsync(request);
            await _dbContext.SaveChangesAsync();
            return request;
        }

        public async Task<IndoorFeatures> CreateIndoorFeatureAsync(IndoorFeatures request)
        {
            await _dbContext.IndoorFeatures.AddAsync(request);
            await _dbContext.SaveChangesAsync();
            return request;
        }

        public async Task<OutDoorFeatures> CreateOutdoorFeatureAsync(OutDoorFeatures request)
        {
            await _dbContext.OutDoorFeatures.AddAsync(request);
            await _dbContext.SaveChangesAsync();
            return request;
        }

        public async Task<PolicydescriptionDto> CreatePolicyDescriptionAsync(CreatePolicyDto request)
        {
            var policyDescription = _mapper.Map<PolicyDescription>(request);
            await _dbContext.PolicyDescriptions.AddAsync(policyDescription);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<PolicydescriptionDto>(policyDescription);
        }

        public async Task<List<FeaturesDto>> GetAllGeneralFeaturesAsync()
        {

            return _mapper.Map<List<FeaturesDto>>(await _dbContext.GeneralFeatures.ToListAsync());
        }

        public async Task<List<FeaturesDto>> GetAllIndoorFeaturesAsync()
        {
            return _mapper.Map<List<FeaturesDto>>(await _dbContext.IndoorFeatures.ToListAsync());
        }

        public async Task<List<FeaturesDto>> GetAllOutdoorFeaturesAsync()
        {
            return _mapper.Map<List<FeaturesDto>>(await _dbContext.OutDoorFeatures.ToListAsync());
        }

        public async Task<List<PolicyDto>> GetAllPoliciessAsync()
        {
           return _mapper.Map<List<PolicyDto>>(await _dbContext.Policies
                .Include(p => p.PolicyDescriptions)
                .ToListAsync());
        }

        public async Task<PolicyDto?> GetPolicyByIdAsync(long id)
        {
            return _mapper.Map<PolicyDto>(await _dbContext.Policies
                .Include(p => p.PolicyDescriptions)
                .FirstOrDefaultAsync(p => p.Id == id));
        }
    }
}
