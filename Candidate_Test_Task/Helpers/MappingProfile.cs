using AutoMapper;
using Candidate.Core.Dtos;
using Candidate.Core.Entities;

namespace Candidate_Test_Task.Helpers
{
	public class MappingProfile: Profile
	{
        public MappingProfile()
        {
            CreateMap<CandidateEntity, CandidateDto>().ReverseMap();
        }
    }
}
