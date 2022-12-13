using System;
using Diff.ApplicationCore.Interfaces.Services;
using Diff.ApplicationCore.Responses;
using Diff.Infrastructure.Interfaces.Repositories;

namespace Diff.ApplicationCore.Services
{
	public class DifferenceService : IDifferenceService
    {
        public ILeftBase64EncodedBinaryRepository LeftBase64EncodedBinaryRepository { get; }
        public IRightBase64EncodedBinaryRepository RightBase64EncodedBinaryRepository { get; }

        public DifferenceService(
            ILeftBase64EncodedBinaryRepository leftBase64EncodedBinaryRepository,
            IRightBase64EncodedBinaryRepository rightBase64EncodedBinaryRepository)
		{
            LeftBase64EncodedBinaryRepository = leftBase64EncodedBinaryRepository ?? throw new ArgumentNullException(nameof(leftBase64EncodedBinaryRepository));
            RightBase64EncodedBinaryRepository = rightBase64EncodedBinaryRepository ?? throw new ArgumentNullException(nameof(rightBase64EncodedBinaryRepository));
        }

        public async Task<DifferenceResponse> Get(string id)
        {
            var leftBase64EncodedBinary = await LeftBase64EncodedBinaryRepository.Get(id);
            var rightBase64EncodedBinary = await LeftBase64EncodedBinaryRepository.Get(id);

            if (leftBase64EncodedBinary == null || rightBase64EncodedBinary == null)
                return null;
  
            var differenceResponse = new DifferenceResponse {Id = id};



            return differenceResponse;
        }
    }
}

