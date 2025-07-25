using AutoMapper;
using KejaHUnt_PropertiesAPI.Data;
using KejaHUnt_PropertiesAPI.Models.Domain;
using KejaHUnt_PropertiesAPI.Models.Dto;
using KejaHUnt_PropertiesAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace KejaHUnt_PropertiesAPI.Repositories.Implementation
{
    public class PendingPropertyRepository : IPendingPropertyRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PendingPropertyRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PendingPropertyDto> AddAsync(PendingProperty pendingProperty, long[] generalFeatureIds, long[] indoorFeaturesIds, long[] outdoorFeaturesIds)
        {
            // Fetch the actual GeneralFeatures from DB using IDs
            var features = await _context.GeneralFeatures
                .Where(f => generalFeatureIds.Contains(f.Id))
                .ToListAsync();
            var indoorFeatures = await _context.IndoorFeatures
                .Where(f => indoorFeaturesIds.Contains(f.Id))
                .ToListAsync();
            var outDoorFeatures = await _context.OutDoorFeatures
                .Where(f => outdoorFeaturesIds.Contains(f.Id))
                .ToListAsync();

            // Assign features to property
            pendingProperty.GeneralFeatures = features;
            pendingProperty.IndoorFeatures = indoorFeatures;
            pendingProperty.OutdoorFeatures = outDoorFeatures;
            var property = await _context.PendingProperties.AddAsync(pendingProperty);
            await _context.SaveChangesAsync();
            return _mapper.Map<PendingPropertyDto>(property.Entity);
        }

        public async Task<PendingProperty?> GetByIdAsync(long id)
        {
            return await _context.PendingProperties
                .Include(x => x.Units)
                .Include(f => f.IndoorFeatures)
                .Include(f => f.OutdoorFeatures)
                .Include(f => f.GeneralFeatures)
                .Include(p => p.PendingPolicyDescriptions)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<PendingProperty>> GetAllAsync()
        {
            return await _context.PendingProperties.ToListAsync();
        }

        public async Task DeleteAsync(PendingProperty pendingProperty)
        {
            _context.PendingProperties.Remove(pendingProperty);
            await _context.SaveChangesAsync();
        }
    }
}
