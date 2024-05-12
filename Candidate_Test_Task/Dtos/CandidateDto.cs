using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate.Core.Dtos
{
	public class CandidateDto
	{
		public string FirstName { get; set; } = null!;
		public string LastName { get; set; } = null!;
		public string PhoneNumber { get; set; } = null!;
		public string Email { get; set; } = null!;
	}
}
