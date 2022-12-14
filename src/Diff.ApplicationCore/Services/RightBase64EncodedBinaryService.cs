using System;
using AutoMapper;
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
        public IMapper Mapper { get; set; }
        public IRightBase64EncodedBinaryRepository RightBase64EncodedBinaryRepository { get; }

        public RightBase64EncodedBinaryService(
            IMapper mapper,
            IRightBase64EncodedBinaryRepository rightBase64EncodedBinaryRepository)
		{
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            RightBase64EncodedBinaryRepository = rightBase64EncodedBinaryRepository ?? throw new ArgumentNullException(nameof(rightBase64EncodedBinaryRepository));
        }

        public async Task<RightBase64EncodedBinaryResponse> AddOrUpdate(RightBase64EncodedBinaryRequest request)
        {
            var entityRequest = Mapper.Map<RightBase64EncodedBinaryEntity>(request);
            await RightBase64EncodedBinaryRepository.AddOrUpdate(entityRequest);

            var entityResponse = await RightBase64EncodedBinaryRepository.Get(request.Id);
            var response = Mapper.Map<RightBase64EncodedBinaryResponse>(entityResponse);

            return response;
        }

        public async Task<RightBase64EncodedBinaryResponse> Get(string id)
        {
            var entityResponse = await RightBase64EncodedBinaryRepository.Get(id);
            var response = Mapper.Map<RightBase64EncodedBinaryResponse>(entityResponse);

            return response;
        }
    }
}