using KejaHUnt_PropertiesAPI.Data;
using KejaHUnt_PropertiesAPI.Migrations;
using KejaHUnt_PropertiesAPI.Models.Domain;
using KejaHUnt_PropertiesAPI.Models.Dto;
using KejaHUnt_PropertiesAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace KejaHUnt_PropertiesAPI.Repositories.Implementation
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PropertyRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
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
            return await _dbContext.Properties.Include(x => x.Units).Include(f => f.IndoorFeatures).Include(f => f.OutdoorFeatures).Include(f => f.GeneralFeatures).Include(f => f.PolicyDescriptions).ToListAsync();
        }

        public async Task<Property?> GetPropertyByIdAsync(long id)
        {
            return await _dbContext.Properties.Include(x => x.Units).Include(f => f.IndoorFeatures).Include(f => f.OutdoorFeatures).Include(f => f.GeneralFeatures).Include(f => f.PolicyDescriptions).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Property?> UpdateAsync(Property property)
        {
            var existingProperty = await _dbContext.Properties
                .Include(x => x.Units)
                .FirstOrDefaultAsync(x => x.Id == property.Id);

            if (existingProperty == null)
            {
                return null;
            }

            // Update basic fields
            existingProperty.Name = property.Name;
            existingProperty.Location = property.Location;
            existingProperty.Type = property.Type;
            if (property.DocumentId != null && property.DocumentId != Guid.Empty)
            {
                existingProperty.DocumentId = property.DocumentId;
            }
            else
            {
                // If the document ID is not provided, keep the existing one
                existingProperty.DocumentId = existingProperty.DocumentId;
            }

            // Save changes
            await _dbContext.SaveChangesAsync();

            return existingProperty;
        }




    }
}
