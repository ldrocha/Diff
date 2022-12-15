using Diff.Infrastructure.Entities;

namespace Diff.Infrastructure.Interfaces.Repositories
{
    public interface ILeftBase64EncodedBinaryRepository
	{
		Task<LeftBase64EncodedBinaryEntity> Get(string id);

		Task AddOrUpdate(LeftBase64EncodedBinaryEntity entity);
	}
}

