using Candidate.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate.Core
{
	public interface ICandidateRepository
	{
		Task<CandidateEntity?> GetCandidateAsync(string candidateId);

		Task<CandidateEntity?> UpdateCandidateAsync(CandidateEntity candidate);

		Task<bool> DeleteCandidateAsync(string candidateId);
	}
}
