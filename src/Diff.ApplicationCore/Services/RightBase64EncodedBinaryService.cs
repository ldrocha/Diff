using System;
using Diff.ApplicationCore.Interfaces.Services;
using Diff.ApplicationCore.Requests;
using Diff.ApplicationCore.Responses;
using Diff.Infrastructure.Entities;
using Diff.Infrastructure.Interfaces.Repositories;
using Diff.Infrastructure.Repositories;

namespace Diff.ApplicationCore.Services
{
	public class RightBase64EncodedBinaryService : IRightBase64EncodedBinaryService
    {
        public IRightBase64EncodedBinaryRepository RightBase64EncodedBinaryRepository { get; }

        public RightBase64EncodedBinaryService(IRightBase64EncodedBinaryRepository rightBase64EncodedBinaryRepository)
		{
            RightBase64EncodedBinaryRepository = rightBase64EncodedBinaryRepository ?? throw new ArgumentNullException(nameof(rightBase64EncodedBinaryRepository));
        }

        public async Task<RightBase64EncodedBinaryResponse> AddOrUpdate(RightBase64EncodedBinaryRequest request)
        {
            var entity = new RightBase64EncodedBinary();
            await RightBase64EncodedBinaryRepository.AddOrUpdate(entity);
            entity = await RightBase64EncodedBinaryRepository.Get(request.Id);
            return new RightBase64EncodedBinaryResponse();
        }

        public async Task<RightBase64EncodedBinaryResponse> Get(string id)
        {
            var entity = await RightBase64EncodedBinaryRepository.Get(id);
            return new RightBase64EncodedBinaryResponse();
        }
    }
}

