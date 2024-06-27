using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    // localhost:<port number>/api/walks
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWalkRepository _walkRepository;

        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            this._mapper = mapper;
            this._walkRepository = walkRepository;
        }

        // CREATE WALK
        // POST: /api/walks
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDTO addWalkRequestDTO)
        {
            // Map DTO to Domain Model
            var walkDomainModel = _mapper.Map<Walk>(addWalkRequestDTO);

            await _walkRepository.CreateAsync(walkDomainModel);

            // Map Domain Model to DTO
            return Ok(_mapper.Map<WalkDTO>(walkDomainModel));

        }

        // GET WALKS
        // GET: /api/walks
        // With filtering: GET: /api/walks?filterOn=Name&filterQuery=Track&sortBy=Name&isAscending=true&pageNumber=1&pageSize=10
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery, 
            [FromQuery] string? sortBy, [FromQuery] bool? isAscending,
            [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1000)
        {
            var walksDomainModel = await _walkRepository.GetAllAsync(filterOn, filterQuery, 
                sortBy, isAscending ?? true, 
                pageNumber, pageSize);

            // MAP Domain Model to DTO
            return Ok(_mapper.Map<List<WalkDTO>>(walksDomainModel));
        }

        // GET Walk by ID
        // Get:/api/Walks/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walkDomainModel = await _walkRepository.GetById(id);

            if (walkDomainModel == null) return NotFound();


            return Ok(_mapper.Map<WalkDTO>(walkDomainModel));
        }

        // UPDATE Walk by ID
        // PUT: /api/Walks/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, UpdateWalkRequestDTO updateWalkRequestDTO)
        {

            // Map DTO to Domain Model
            var walkDomainModel = _mapper.Map<Walk>(updateWalkRequestDTO);
            walkDomainModel = await _walkRepository.UpdateAsync(id, walkDomainModel);

            if (walkDomainModel == null) return NotFound();

            // MAP Domain Model to DTO
            return Ok(_mapper.Map<WalkDTO>(walkDomainModel));
        }

        // DELETE a Walk by ID
        // DELETE: /api/Walks/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedWalkDomainModel = await _walkRepository.DeleteAsync(id);
            if (deletedWalkDomainModel == null) return NotFound();

            // Map DOmain Model to DTO
            return Ok(_mapper.Map<WalkDTO>(deletedWalkDomainModel));
        }
    }
}
