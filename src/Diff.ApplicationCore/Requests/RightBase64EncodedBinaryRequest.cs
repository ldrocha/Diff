using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Diff.ApplicationCore.Requests

{
    public class RightBase64EncodedBinaryRequest
    {
        [JsonIgnore]
        public string Id { get; set; } = default!;
        [Required]
        public string Data { get; set; } = default!;
	}
}