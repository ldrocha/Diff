using System;
using Diff.ApplicationCore.Enums;

namespace Diff.ApplicationCore.Responses
{
	public class DifferenceResponse
	{
        public string Id { get; set; } = default!;
        public DifferenceStatus Status { get; set; } = default!;
		public DifferenceDetail Detail { get; set; } = default!;

        public class DifferenceDetail
        {
            public int Lenght { get; set; }
            public List<int> OffsetDifferences { get; set; } = default!;
        }
    }
}


