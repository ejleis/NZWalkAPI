using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    // https://localhost:<port number>/api/regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NzWalksDbContext _dbContext;
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;

        public RegionsController(NzWalksDbContext dbContext, IRegionRepository regionRepository, IMapper mapper)
        {
            _dbContext = dbContext;
            _regionRepository = regionRepository;
            _mapper = mapper;
        }

        // GET ALL REGIONS
        // Get: https://localhost:<port number>/api/regions
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Get data from database - Domain Models
            var regionsDomain = await _regionRepository.GetAllAsync();

            /* Code below was replaced by code above
            // old code v1 - var regionsDomain = _dbContext.Regions.ToList();
            // old code v2 -  var regionsDomain = await _dbContext.Regions.ToListAsync(); // ToListAsync() is coming from Microsoft.EntityFrameworkCore
            */

            /* // Map Domain models to DTOs
            var regionsDto = new List<RegionDTO>();
            foreach (var regionDomain in regionsDomain)
            {
                regionsDto.Add(new RegionDTO()
                {
                    Id = regionDomain.Id,
                    Code = regionDomain.Code,
                    Name = regionDomain.Name,
                    RegionImageUrl = regionDomain.RegionImageUrl
                });
            }
            */

            //OR

            // Map domain models to DTOs
            var regionsDto = _mapper.Map<List<RegionDTO>>(regionsDomain);

            // Return DTOs
            return Ok(regionsDto);

            // OR
            //return Ok(_mapper.Map<List<RegionDTO>>(regionsDomain));
        }

        // GET SINGLE REGION (GET REGION BY ID)
        // Get: https://localhost:<port number>/api/regions/<id>
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            // var region = _dbContext.Regions.Find(id);
            // another way
            var regionsDomain = await _regionRepository.GetByIdAsync(id);
            // old code - var regionsDomain = await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id); // Get region domain model from database

            if (regionsDomain == null)
            {
                return NotFound();
            }

            // Map / Convert Domain model to DTOs
            /*
            var regionDto = new RegionDTO
            {
                Id = regionsDomain.Id,
                Code = regionsDomain.Code,
                Name = regionsDomain.Name,
                RegionImageUrl = regionsDomain.RegionImageUrl
            };
            */

            // OR

            var regionDTO = _mapper.Map<RegionDTO>(regionsDomain);

            // Return DTO back to client
            return Ok(regionDTO);
        }

        // POST To create new Region
        // POST: https://localhost:<port number>/api/regions
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDTO addRegionRequestDTO)
        {

            // Map or Convert DTO to Domain Model
            /*
            var regionDomainModel = new Region
            {
                Code = addRegionRequestDTO.Code,
                Name = addRegionRequestDTO.Name,
                RegionImageUrl = addRegionRequestDTO.RegionImageUrl
            };
            */

            // OR 
            var regionDomainModel = _mapper.Map<Region>(addRegionRequestDTO);

            // Use Domain Model To create Region
            regionDomainModel = await _regionRepository.CreateAsync(regionDomainModel);

            /* OLD CODE (already used on the code above this)
            await _dbContext.Regions.AddAsync(regionDomainModel);
            await _dbContext.SaveChangesAsync();
            */

            // Map Domain Model back to DTO
            /*
            var regionDTO = new RegionDTO
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };
            */
            //OR
            var regionDTO = _mapper.Map<RegionDTO>(regionDomainModel);

            return CreatedAtAction(nameof(GetById), new { id = regionDomainModel.Id }, regionDTO);

        }

        // Update region
        // PUT: https://localhost:<port number>/api/regions/<id>
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDTO updateRegionRequestDTO)
        {

            /* OLD CODE
            // check if region exist
            var regionDomainModel = await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (regionDomainModel == null) return NotFound();
            */

            // Map DTO to Domain Model
            /*
             * var regionDomainModel = new Region()
            {
                Code = updateRegionRequestDTO.Code, 
                Name = updateRegionRequestDTO.Name,
                RegionImageUrl= updateRegionRequestDTO.RegionImageUrl
            };
            */
            //OR
            var regionDomainModel = _mapper.Map<Region>(updateRegionRequestDTO);

            // check if region exist
            regionDomainModel = await _regionRepository.UpdateAsync(id, regionDomainModel);
            if (regionDomainModel == null) return NotFound();

            // Convert Domain Model to DTO
            /*
            var regionDTO = new RegionDTO
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };
            */
            // OR
            var regionDTO = _mapper.Map<RegionDTO>(regionDomainModel);

            return Ok(regionDTO);

        }

        // Delete Region
        // DELETE: https://localhost:<port number>/api/regions/<id>
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            /* OLD Code
            // check if region exist
            var regionDomainModel = await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (regionDomainModel == null) return NotFound();

            // Delete Region
            _dbContext.Regions.Remove(regionDomainModel);
            await _dbContext.SaveChangesAsync();
            */

            var regionDomainModel = await _regionRepository.DeleteAsync(id);
            if (regionDomainModel == null) return NotFound();

            // return deleted Region back
            // map domain model to DTO
            // OLD CODE
            /*
            var regionDTO = new RegionDTO
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };
            */

            var regionDTO = _mapper.Map<RegionDTO>(regionDomainModel);

            return Ok(regionDTO);
        }
    }
}