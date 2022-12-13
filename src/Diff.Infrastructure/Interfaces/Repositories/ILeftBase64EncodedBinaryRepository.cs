using System;
using Diff.Infrastructure.Entities;
using Diff.Infrastructure.Repositories;

namespace Diff.Infrastructure.Interfaces.Repositories
{
	public interface ILeftBase64EncodedBinaryRepository
	{
		Task<LeftBase64EncodedBinary> Get(string id);

		Task AddOrUpdate(LeftBase64EncodedBinary entity);
	}
}

