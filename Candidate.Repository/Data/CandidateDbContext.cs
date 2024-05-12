using Candidate.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Candidate.Repository.Data
{
	public class CandidateDbContext: DbContext
	{
        public CandidateDbContext(DbContextOptions<CandidateDbContext> options)
            :base(options)
        {
            
        }

        public DbSet<CandidateEntity> MyProperty { get; set; }
    }
}
