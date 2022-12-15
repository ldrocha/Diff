using Diff.Infrastructure.Entities;

namespace Diff.Infrastructure.Interfaces.Repositories
{
    public interface IRightBase64EncodedBinaryRepository
	{
        Task<RightBase64EncodedBinaryEntity> Get(string id);

        Task AddOrUpdate(RightBase64EncodedBinaryEntity entity);
    }
}

