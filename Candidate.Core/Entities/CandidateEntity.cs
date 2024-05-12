using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate.Core.Entities
{
	public class CandidateEntity
	{
		public int Id { get; set; }
		public string FirstName { get; set; } = null!;
		public string LastName { get; set; } = null!;
		public string PhoneNumber { get; set; } = null!;
		public string Email { get; set; } = null!;
		public string TimeInterval { get; set; } = null!;
		public string LinkedInProfileUrl { get; set; } = null!;
		public string GitHubProfileUrl { get; set; } = null!;
		public string Comment { get; set; } = null!;
	}
}
