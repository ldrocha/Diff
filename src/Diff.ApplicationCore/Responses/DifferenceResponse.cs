using System;
using Diff.ApplicationCore.Enums;

namespace Diff.ApplicationCore.Responses
{
	public class DifferenceResponse
	{
        public string Id { get; set; } = default!;
        public DifferenceStatus Status { get; set; } = default!;
		public DifferenceDetail Detail { get; set; } = default!;

        public DifferenceResponse(string id)
        {
            Id = id;
        }
    }

    public class DifferenceDetail
    {
        public DifferenceDetail(int offsetLenght, List<int> differencesOffsets)
        {
            OffsetLenght = offsetLenght;
            DifferencesOffsets = differencesOffsets;
        }

        public int OffsetLenght { get; set; }
        public List<int> DifferencesOffsets { get; set; } = default!;
    }
}