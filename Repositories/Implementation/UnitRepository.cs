﻿using KejaHUnt_PropertiesAPI.Data;
using KejaHUnt_PropertiesAPI.Models.Domain;
using KejaHUnt_PropertiesAPI.Models.Dto;
using KejaHUnt_PropertiesAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace KejaHUnt_PropertiesAPI.Repositories.Implementation
{
    public class UnitRepository : IUnitRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UnitRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> CreateUnitAsync(Unit unit)
        {
            await _dbContext.Units.AddAsync(unit);
            await _dbContext.SaveChangesAsync();
            return unit;
        }

        public async Task<Unit?> DeleteAync(long id)
        {
            var existingUnit = await _dbContext.Units.FirstOrDefaultAsync(x => x.Id == id);

            if (existingUnit != null)
            {
                _dbContext.Units.Remove(existingUnit);
                await _dbContext.SaveChangesAsync();
                return existingUnit;
            }
            return null;
        }

        public async Task<IEnumerable<Unit>> GetAllAsync()
        {
            //fetch only open units.......where status is not booked or reserved
            return await _dbContext.Units.ToListAsync();
        }

        public async Task<Unit?> GetUnitByIdAsync(long id)
        {
            return await _dbContext.Units.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Unit?> UpdateAsync(Unit unit)
        {
            var existingUnit = await _dbContext.Units.FirstOrDefaultAsync(x => x.Id == unit.Id);

            if (existingUnit == null)
            {
                return null;
            }
            // Update basic fields
            existingUnit.Price = unit.Price;
            existingUnit.Type = unit.Type;
            existingUnit.Bathrooms = unit.Bathrooms;
            existingUnit.Size = unit.Size;
            existingUnit.Floor = unit.Floor;
            existingUnit.DoorNumber = unit.DoorNumber;
            existingUnit.Status = unit.Status;
            existingUnit.PropertyId = unit.PropertyId;
            if (unit.DocumentId != null && unit.DocumentId != Guid.Empty)
            {
                existingUnit.DocumentId = unit.DocumentId;
            }
            else
            {
                // If the document ID is not provided, keep the existing one
                existingUnit.DocumentId = existingUnit.DocumentId;
            }

            // Save changes
            await _dbContext.SaveChangesAsync();

            return existingUnit;
        }

        public async Task<IEnumerable<Unit>> GetUnitsByPropertyIdAsync(long propertyId)
        {
            return await _dbContext.Units
                .Where(u => u.PropertyId == propertyId)
                .ToListAsync();
        }

        public async Task<Unit?> UpdateUnitStatusAsync(UnitStatusDto request)
        {
            var existingUnit = await _dbContext.Units.FirstOrDefaultAsync(x => x.Id == request.UnitId);

            if (existingUnit == null)
            {
                throw new InvalidOperationException("Unit not found.");
            }

            var currentStatus = existingUnit.Status;
            var newStatus = request.Status;

            // Valid transitions:
            if (currentStatus == "Available" &&
                (newStatus == "Reserved" || newStatus == "Booked" || newStatus == "Paying"))
            {
                existingUnit.Status = newStatus;
            }
            else if (currentStatus == "Reserved" &&
                     (newStatus == "Booked" || newStatus == "Paying"))
            {
                existingUnit.Status = newStatus;
            }
            else if (currentStatus == "Paying" &&
                     (newStatus == "Booked" || newStatus == "Reserved" || newStatus == "Available" || newStatus == "Paying"))
            {
                existingUnit.Status = newStatus;
            }
            else
            {
                throw new InvalidOperationException(
                    $"Cannot change unit status from '{currentStatus}' to '{newStatus}'.");
            }

            await _dbContext.SaveChangesAsync();

            return existingUnit;
        }

    }
}
