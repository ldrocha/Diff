using Diff.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Diff.Infrastructure.Context
{
    public class DiffDbContext : DbContext
	{
        public DbSet<LeftBase64EncodedBinaryEntity> LeftBase64EncodedBinary { get; set; }
        public DbSet<RightBase64EncodedBinaryEntity> RightBase64EncodedBinary { get; set; }

        public DiffDbContext()
		{
		}

        protected override void OnConfiguring
       (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "DiffDataBase");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LeftBase64EncodedBinaryEntity>().HasData(
                new LeftBase64EncodedBinaryEntity
                {
                    Id = "123",
                    Data = "MTIzIDEyMyAxMjMgMTIzIDEyMw=="
                },
                new LeftBase64EncodedBinaryEntity
                {
                    Id = "456",
                    Data = "NDU2IDQ1NiA0NTYgNDU2IDQ1Ng=="
                },
                new LeftBase64EncodedBinaryEntity
                {
                    Id = "789",
                    Data = "Nzg5IDc4OSA3ODkgNzg5IDc4OQ=="
                }
            );

            modelBuilder.Entity<RightBase64EncodedBinaryEntity>().HasData(
               new RightBase64EncodedBinaryEntity
               {
                   Id = "123",
                   Data = "MTIzIDEyMyAxMjMgMTIzIDEyMw=="
               },
                new RightBase64EncodedBinaryEntity
                {
                    Id = "456",
                    Data = "NDU2IDQ1NiA0NTYgNDU2IA=="
                },
                new RightBase64EncodedBinaryEntity
                {
                    Id = "789",
                    Data = "Nzg5IDc4OSAwMDAgNzg5IDAwMA=="
                }
           );
        }
    }
}

