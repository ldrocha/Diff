using System;
using Diff.Infrastructure.Context;
using Diff.Infrastructure.Entities;
using Diff.Infrastructure.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Diff.Infrastructure.Repositories
{
	public class LeftBase64EncodedBinaryRepository : ILeftBase64EncodedBinaryRepository
    {
        public LeftBase64EncodedBinaryRepository()
        {
            using (var context = new DiffDbContext())
            {
                context.Database.EnsureCreated();
            }
        }

        public async Task<LeftBase64EncodedBinaryEntity> Get(string id)
        {
            using (var context = new DiffDbContext())
            {
                var entity = await context.LeftBase64EncodedBinary
                    .FirstOrDefaultAsync(x => x.Id == id);

                return entity;
            }
        }

        public async Task AddOrUpdate(LeftBase64EncodedBinaryEntity entity)
        {
            using (var context = new DiffDbContext())
            {
                if (context.LeftBase64EncodedBinary.Any(x => x.Id == entity.Id))
                    context.LeftBase64EncodedBinary.Update(entity);
                else
                    await context.LeftBase64EncodedBinary.AddAsync(entity);

                await context.SaveChangesAsync();
            }
        }
    }
}

