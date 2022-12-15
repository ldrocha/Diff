using AutoMapper;
using Diff.ApplicationCore.Interfaces.Services;
using Diff.ApplicationCore.Requests;
using Diff.ApplicationCore.Responses;
using Diff.Infrastructure.Entities;
using Diff.Infrastructure.Interfaces.Repositories;

namespace Diff.ApplicationCore.Services
{
    public class LeftBase64EncodedBinaryService : ILeftBase64EncodedBinaryService
    {
        public IMapper Mapper { get; set; }
        public ILeftBase64EncodedBinaryRepository LeftBase64EncodedBinaryRepository { get; }

        public LeftBase64EncodedBinaryService(
            IMapper mapper,
            ILeftBase64EncodedBinaryRepository leftBase64EncodedBinaryRepository)
        {
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            LeftBase64EncodedBinaryRepository = leftBase64EncodedBinaryRepository ?? throw new ArgumentNullException(nameof(leftBase64EncodedBinaryRepository));
        }

        public async Task<LeftBase64EncodedBinaryResponse> AddOrUpdate(LeftBase64EncodedBinaryRequest request)
        {
            var entityRequest = Mapper.Map<LeftBase64EncodedBinaryEntity>(request);
            await LeftBase64EncodedBinaryRepository.AddOrUpdate(entityRequest);

            var entityResponse = await LeftBase64EncodedBinaryRepository.Get(request.Id);
            var response = Mapper.Map<LeftBase64EncodedBinaryResponse>(entityResponse);

            return response;
        }

        public async Task<LeftBase64EncodedBinaryResponse> Get(string id)
        {
            var entityResponse = await LeftBase64EncodedBinaryRepository.Get(id);
            var response = Mapper.Map<LeftBase64EncodedBinaryResponse>(entityResponse);

            return response;
        }
    }
}

