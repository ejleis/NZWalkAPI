using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public WalksController(IMapper mapper, IWalkRepository walkRepository) {
            this._mapper = mapper;
            this._walkRepository = walkRepository;
        }

        // CREATE WALK
        // POST: /api/walks
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDTO addWalkRequestDTO)
        {
            // Map DTO to Domain Model
            var walkDomainModel = _mapper.Map<Walk>(addWalkRequestDTO);

            await _walkRepository.CreateAsync(walkDomainModel);

            // Map Domain Model to DTO


            return Ok(_mapper.Map<WalkDTO>(walkDomainModel));
        }
    }
}
