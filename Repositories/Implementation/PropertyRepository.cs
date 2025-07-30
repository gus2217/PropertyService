using AutoMapper;
using KejaHUnt_PropertiesAPI.Data;
using KejaHUnt_PropertiesAPI.Models.Domain;
using KejaHUnt_PropertiesAPI.Models.Dto;
using KejaHUnt_PropertiesAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace KejaHUnt_PropertiesAPI.Repositories.Implementation
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IImageRepository _imageRepository;
        private readonly IFeatureRepository _featureRepository;

        public PropertyRepository(ApplicationDbContext dbContext, IMapper mapper, IImageRepository imageRepository, IFeatureRepository featureRepository)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _imageRepository = imageRepository;
            _featureRepository = featureRepository;
        }

        public async Task<Property> AddAsync(Property property)
        {
            await _dbContext.Properties.AddAsync(property);
            await _dbContext.SaveChangesAsync();

            return property;
        }

        public async Task<Property> CreatePropertyAsync(Property property, long[] generalFeatureIds, long[] indoorFeaturesIds, long[] outdoorFeaturesIds)
        {
            // Fetch the actual GeneralFeatures from DB using IDs
            var features = await _dbContext.GeneralFeatures
                .Where(f => generalFeatureIds.Contains(f.Id))
                .ToListAsync();
            var indoorFeatures = await _dbContext.IndoorFeatures
                .Where(f => indoorFeaturesIds.Contains(f.Id))
                .ToListAsync();
            var outDoorFeatures = await _dbContext.OutDoorFeatures
                .Where(f => outdoorFeaturesIds.Contains(f.Id))
                .ToListAsync();

            // Assign features to property
            property.GeneralFeatures = features;
            property.IndoorFeatures = indoorFeatures;
            property.OutdoorFeatures = outDoorFeatures;

            await _dbContext.Properties.AddAsync(property);
            await _dbContext.SaveChangesAsync();

            return property;
        }


        public async Task<Property?> DeleteAync(long id)
        {
            var existingProperty = await _dbContext.Properties.FirstOrDefaultAsync(x => x.Id == id);

            if (existingProperty != null)
            {
                _dbContext.Units.RemoveRange(existingProperty.Units);
                _dbContext.Properties.Remove(existingProperty);
                await _dbContext.SaveChangesAsync();
                return existingProperty;
            }
            return null;
        }

        public async Task<IEnumerable<Property>> GetAllAsync()
        {
            return await _dbContext.Properties.Include(x => x.Units).Include(f => f.IndoorFeatures).Include(f => f.OutdoorFeatures).Include(f => f.GeneralFeatures).Include(p => p.PolicyDescriptions).ToListAsync();
        }

        public async Task<Property?> GetPropertyByIdAsync(long id)
        {
            return await _dbContext.Properties.Include(x => x.Units).Include(f => f.IndoorFeatures).Include(f => f.OutdoorFeatures).Include(f => f.GeneralFeatures).Include(p => p.PolicyDescriptions).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Property>> GetPropertyByEmail(string email)
        {
            return await _dbContext.Properties
                .Include(x => x.Units)
                .Include(f => f.IndoorFeatures)
                .Include(f => f.OutdoorFeatures)
                .Include(f => f.GeneralFeatures)
                .Include(p => p.PolicyDescriptions)
                .Where(x => x.Email == email)
                .ToListAsync();
        }


        public async Task<Property?> UpdateAsync(long id, UpdatePropertyRequestDto request)
        {
            var property = await _dbContext.Properties
                .Include(p => p.GeneralFeatures)
                .Include(p => p.IndoorFeatures)
                .Include(p => p.OutdoorFeatures)
                .Include(p => p.Units)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (property == null)
            {
                return null;
            }

            // Update scalar properties
            _mapper.Map(request, property); // Map fields from request into the existing entity (excluding nav props)

            // Handle Image Upload/Update
            if (request.ImageFile != null)
            {
                var newDocumentId = (request.DocumentId != null && request.DocumentId != Guid.Empty)
                    ? await _imageRepository.Edit(request.DocumentId.Value, request.ImageFile)
                    : await _imageRepository.Upload(request.ImageFile);

                property.DocumentId = newDocumentId;
            }

            // Clear and reassign features
            property.GeneralFeatures?.Clear();
            property.IndoorFeatures?.Clear();
            property.OutdoorFeatures?.Clear();

            var generalFeatures = await _dbContext.GeneralFeatures
                .Where(f => request.GeneralFeatures.Contains(f.Id))
                .ToListAsync();
            var indoorFeatures = await _dbContext.IndoorFeatures
                .Where(f => request.IndoorFeatures.Contains(f.Id))
                .ToListAsync();
            var outdoorFeatures = await _dbContext.OutDoorFeatures
                .Where(f => request.OutDoorFeatures.Contains(f.Id))
                .ToListAsync();

            property.GeneralFeatures = generalFeatures;
            property.IndoorFeatures = indoorFeatures;
            property.OutdoorFeatures = outdoorFeatures;

            // Handle PolicyDescriptions
            if (!string.IsNullOrWhiteSpace(request.PolicyDescriptions))
            {
                try
                {
                    var policies = JsonConvert.DeserializeObject<List<CreatePolicyDto>>(request.PolicyDescriptions);

                    if (policies != null && policies.Any())
                    {
                        foreach (var policy in policies)
                        {
                            await _featureRepository.CreatePolicyDescriptionAsync(policy);
                        }
                    }
                }
                catch (JsonException ex)
                {
                    Console.WriteLine($"Failed to deserialize policy descriptions: {ex.Message}");
                }
            }

            await _dbContext.SaveChangesAsync();

            return property;
        }




    }
}
