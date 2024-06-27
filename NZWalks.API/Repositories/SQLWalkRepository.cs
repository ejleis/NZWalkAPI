using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using System.Linq;

namespace NZWalks.API.Repositories
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly NzWalksDbContext _context;

        public SQLWalkRepository(NzWalksDbContext context)
        {
            this._context = context;
        }
        public async Task<Walk> CreateAsync(Walk walk)
        {
            await _context.Walks.AddAsync(walk);
            await _context.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk?> DeleteAsync(Guid id)
        {
            var existingWalk = await _context.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (existingWalk == null) return null;

            _context.Walks.Remove(existingWalk);
            await _context.SaveChangesAsync();

            return existingWalk;
        }

        public async Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null, 
            string? sortBy = null, bool isAscending = true, 
            int pageNumber = 1, int pageSize = 1000)
        {
            var walks = _context.Walks.Include("Difficulty").Include("Region").AsQueryable();

            //  Filtering
            if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = walks.Where(x => x.Name.Contains(filterQuery));
                }
            }

            // Sorting
            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAscending ? walks.OrderBy(x => x.Name) : walks.OrderByDescending(x => x.Name);
                }
                else if (sortBy.Equals("Length", StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAscending ? walks.OrderBy(x => x.LengthInKm) : walks.OrderByDescending(x => x.LengthInKm);
                }
            }

            // Pagination
            var skipResult = (pageNumber - 1) * pageSize;

            return await walks.Skip(skipResult).Take(pageSize).ToListAsync();

            //return await _context.Walks
            //    .Include("Difficulty")
            //    .Include("Region")
            //    .ToListAsync();
        }

        public async Task<Walk?> GetById(Guid id)
        {
            return await _context.Walks
                .Include("Difficulty")
                .Include("Region")
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Walk?> UpdateAsync(Guid id, Walk walk)
        {
            var existingWalk = await _context.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (existingWalk == null) return null;

            existingWalk.Name = walk.Name;
            existingWalk.Description = walk.Description;
            existingWalk.LengthInKm = walk.LengthInKm;
            existingWalk.WalkImageUrl = walk.WalkImageUrl;
            existingWalk.DifficultyId = walk.DifficultyId;
            existingWalk.RegionId = walk.RegionId;

            await _context.SaveChangesAsync();

            return existingWalk;
        }
    }
}
