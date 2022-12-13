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
                var list = new List<LeftBase64EncodedBinary>
                {
                    new LeftBase64EncodedBinary
                    {
                        Id = "123",
                        Data = "MTIzIDEyMyAxMjMgMTIzIDEyMw=="
                    },
                    new LeftBase64EncodedBinary
                    {
                        Id = "456",
                        Data = "NDU2IDQ1NiA0NTYgNDU2IDQ1Ng=="
                    },
                    new LeftBase64EncodedBinary
                    {
                        Id = "456",
                        Data = "Nzg5IDc4OSA3ODkgNzg5IDc4OQ=="
                    },
                };

                context.LeftBase64EncodedBinary.AddRange(list);
                context.SaveChanges();
            }
        }

        public async Task<LeftBase64EncodedBinary> Get(string id)
        {
            using (var context = new DiffDbContext())
            {
                var entity = await context.LeftBase64EncodedBinary
                    .FirstOrDefaultAsync(x => x.Id == id);

                return entity;
            }
        }

        public async Task AddOrUpdate(LeftBase64EncodedBinary entity)
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

