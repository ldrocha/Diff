using System;
using Diff.Infrastructure.Entities;

namespace Diff.Infrastructure.Interfaces.Repositories
{
	public interface IRightBase64EncodedBinaryRepository
	{
        Task<RightBase64EncodedBinary> Get(string id);

        Task AddOrUpdate(RightBase64EncodedBinary entity);
    }
}

