using System;
using Diff.ApplicationCore.Interfaces.Services;
using Diff.ApplicationCore.Requests;
using Diff.ApplicationCore.Responses;
using Diff.Infrastructure.Entities;
using Diff.Infrastructure.Interfaces.Repositories;
using Diff.Infrastructure.Repositories;

namespace Diff.ApplicationCore.Services
{
	public class LeftBase64EncodedBinaryService : ILeftBase64EncodedBinaryService
    {
        public ILeftBase64EncodedBinaryRepository LeftBase64EncodedBinaryRepository { get; }

        public LeftBase64EncodedBinaryService(ILeftBase64EncodedBinaryRepository leftBase64EncodedBinaryRepository)
        {
            LeftBase64EncodedBinaryRepository = leftBase64EncodedBinaryRepository ?? throw new ArgumentNullException(nameof(leftBase64EncodedBinaryRepository));
        }

        public async Task<LeftBase64EncodedBinaryResponse> AddOrUpdate(LeftBase64EncodedBinaryRequest request)
        {
            var entity = new LeftBase64EncodedBinary();
            await LeftBase64EncodedBinaryRepository.AddOrUpdate(entity);
            entity = await LeftBase64EncodedBinaryRepository.Get(request.Id);
            return new LeftBase64EncodedBinaryResponse();
        }

        public async Task<LeftBase64EncodedBinaryResponse> Get(string id)
        {
            var entity = await LeftBase64EncodedBinaryRepository.Get(id);
            return new LeftBase64EncodedBinaryResponse();
        }
    }
}

