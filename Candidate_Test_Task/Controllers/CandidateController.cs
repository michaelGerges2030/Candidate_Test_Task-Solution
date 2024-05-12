using AutoMapper;
using Candidate.Core;
using Candidate.Core.Dtos;
using Candidate.Core.Entities;
using Candidate.Repository;
using Candidate.Repository.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Candidate_Test_Task.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CandidateController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly ICandidateRepository _candidateRepository;
		private readonly IMemoryCache _cache;
		private readonly CandidateDbContext _context;

		public CandidateController(
			IMapper mapper,
			ICandidateRepository candidateRepository,
			IMemoryCache cache,
			CandidateDbContext context)
        {
			_mapper = mapper;
			_candidateRepository = candidateRepository;
			_cache = cache;
			_context = context;
		}

		[HttpGet]
		public IActionResult GetCandidates()
		{
			const string cacheKey = "Candidates";

			if (_cache.TryGetValue(cacheKey, out List<CandidateDto> cachedCandidates))
			{
				return Ok(cachedCandidates);
			}

			var candidatesFromDataSource = _context.Candidates.ToList();

			var candidateMap = _mapper.Map<List<CandidateDto>>(candidatesFromDataSource);

			// Cache the data
			var cacheOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(10));
			_cache.Set(cacheKey, candidateMap, cacheOptions);

			return Ok(candidateMap);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<CandidateEntity>> GetCandidate(string id)
		{
			var candidate = await _candidateRepository.GetCandidateAsync(id);
			return Ok(candidate ?? new CandidateEntity());
		}

		[HttpPost]
		public async Task<ActionResult<CandidateEntity>> UpdateBasket(CandidateDto candidate)
		{
			var mappedBasket = _mapper.Map<CandidateDto, CandidateEntity>(candidate);
			var createdOrUpdatedBasket = await _candidateRepository.UpdateCandidateAsync(mappedBasket);
			if (createdOrUpdatedBasket is null) return BadRequest();
			return Ok(createdOrUpdatedBasket);
		}


		[HttpDelete]
		public async Task DeleteBasket(string id)
		{
			await _candidateRepository.DeleteCandidateAsync(id);
		}


	}
}
