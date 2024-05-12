using Candidate.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate.Repository.Config
{
	internal class CandidateConfigurations : IEntityTypeConfiguration<CandidateEntity>
	{
		public void Configure(EntityTypeBuilder<CandidateEntity> builder)
		{
			builder.Property(P => P.FirstName)
				.IsRequired();

			builder.Property(P => P.LastName)
			.IsRequired();

			builder.Property(P => P.Email)
			.IsRequired();

			builder.Property(P => P.Comment)
			.IsRequired();
			
		}
	}
}
