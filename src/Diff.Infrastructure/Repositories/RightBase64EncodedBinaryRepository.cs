using System;
using Diff.Infrastructure.Context;
using Diff.Infrastructure.Entities;
using Diff.Infrastructure.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Diff.Infrastructure.Repositories
{
	public class RightBase64EncodedBinaryRepository : IRightBase64EncodedBinaryRepository
    {
		public RightBase64EncodedBinaryRepository()
		{
            using (var context = new DiffDbContext())
            {
                var list = new List<RightBase64EncodedBinary>
                {
                    new RightBase64EncodedBinary
                    {
                        Id = "123",
                        Data = "MTIzIDEyMyAxMjMgMTIzIDEyMw=="
                    },
                    new RightBase64EncodedBinary
                    {
                        Id = "456",
                        Data = "NDU2IDQ1NiA0NTYgNDU2IA=="
                    },
                    new RightBase64EncodedBinary
                    {
                        Id = "456",
                        Data = "Nzg5IDc4OSAwMDAgNzg5IDAwMA=="
                    },
                };

                context.RightBase64EncodedBinary.AddRange(list);
                context.SaveChanges();
            }
        }

        public async Task<RightBase64EncodedBinary> Get(string id)
        {
            using (var context = new DiffDbContext())
            {
                var entity = await context.RightBase64EncodedBinary
                    .FirstOrDefaultAsync(x => x.Id == id);

                return entity;
            }
        }

        public async Task AddOrUpdate(RightBase64EncodedBinary entity)
        {
            using (var context = new DiffDbContext())
            {
                if (context.RightBase64EncodedBinary.Any(x => x.Id == entity.Id))
                    context.RightBase64EncodedBinary.Update(entity);
                else
                    await context.RightBase64EncodedBinary.AddAsync(entity);

                await context.SaveChangesAsync();
            }
        }
    }
}

