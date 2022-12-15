using System;
using Diff.ApplicationCore.Enums;
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
            var rightBase64EncodedBinary = await RightBase64EncodedBinaryRepository.Get(id);

            if (leftBase64EncodedBinary == null || rightBase64EncodedBinary == null)
                return null;
  
            var differenceResponse = new DifferenceResponse(id);
            
            if (leftBase64EncodedBinary.Data == rightBase64EncodedBinary.Data)
            {
                differenceResponse.Status = DifferenceStatus.Equal;
                return differenceResponse;
            }

            if (leftBase64EncodedBinary.Data.Length != rightBase64EncodedBinary.Data.Length)
            {
                differenceResponse.Status = DifferenceStatus.DifferentLength;
                return differenceResponse;
            }

            differenceResponse.Status = DifferenceStatus.SameLength;
            differenceResponse.Detail = GetDifferenceDetail (leftBase64EncodedBinary.Data, rightBase64EncodedBinary.Data);

            return differenceResponse;
        }

        private DifferenceDetail GetDifferenceDetail(string leftBase64EncodedBinary, string rightBase64EncodedBinary)
        {
            byte[] left = Convert.FromBase64String(leftBase64EncodedBinary);
            byte[] right = Convert.FromBase64String(rightBase64EncodedBinary);
            List<int> offsets = new List<int>();

            for (int i = 0; i < left.Length; i++)
            {
                if (left[i] != right[i])
                {
                    offsets.Add(i);
                }
            }

            var differenceDetail = new DifferenceDetail(leftBase64EncodedBinary.Length, offsets.Count, offsets);

            return differenceDetail;
        }
    }
}