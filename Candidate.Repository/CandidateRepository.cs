using Candidate.Core;
using Candidate.Core.Entities;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Candidate.Repository
{
	public class CandidateRepository : ICandidateRepository
	{
		private readonly IDatabase _database;

		public CandidateRepository(IConnectionMultiplexer redis)
        {
			_database =  redis.GetDatabase();
		}


        public async Task<bool> DeleteCandidateAsync(string candidateId)
		{
			return await _database.KeyDeleteAsync(candidateId);
		}

		public async Task<CandidateEntity?> GetCandidateAsync(string candidateId)
		{
			var candidate = await _database.StringGetAsync(candidateId);
			return candidate.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CandidateEntity>(candidate);
		}

		public async Task<CandidateEntity?> UpdateCandidateAsync(CandidateEntity candidate)
		{
			var createdOrUpdated = await _database.StringSetAsync(candidate.Id, JsonSerializer.Serialize(candidate), TimeSpan.FromDays(30));
			if (!createdOrUpdated) return null;
			return await GetCandidateAsync(candidate.Id);
		}
	}
}
