using System;
using Diff.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Diff.Infrastructure.Context
{
	public class DiffDbContext : DbContext
	{
		public DiffDbContext()
		{
		}

        protected override void OnConfiguring
       (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "DiffDb");
        }

        public DbSet<LeftBase64EncodedBinaryEntity> LeftBase64EncodedBinary { get; set; }
        public DbSet<RightBase64EncodedBinaryEntity> RightBase64EncodedBinary { get; set; }
    }
}

