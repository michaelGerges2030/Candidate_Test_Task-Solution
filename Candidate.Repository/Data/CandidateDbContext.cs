using Candidate.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}

		public DbSet<CandidateEntity> Candidates { get; set; }
    }
}
