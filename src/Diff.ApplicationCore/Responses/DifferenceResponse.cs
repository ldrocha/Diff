using System.Text.Json.Serialization;
using Diff.ApplicationCore.Enums;

namespace Diff.ApplicationCore.Responses
{
    public class DifferenceResponse
	{
        public string Id { get; set; } = default!;
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public DifferenceStatus Status { get; set; } = default!;
		public DifferenceDetail Detail { get; set; } = default!;

        public DifferenceResponse(string id)
        {
            Id = id;
        }
    }

    public class DifferenceDetail
    {
        public int Lenght { get; set; }
        public int OffsetLenght { get; set; }
        public List<int> DifferencesOffsets { get; set; } = default!;

        public DifferenceDetail(int lenght, int offsetLenght, List<int> differencesOffsets)
        {
            Lenght = lenght;
            OffsetLenght = offsetLenght;
            DifferencesOffsets = differencesOffsets;
        }
    }
}