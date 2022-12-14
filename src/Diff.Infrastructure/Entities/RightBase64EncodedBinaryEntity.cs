using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diff.Infrastructure.Entities
{
	public class RightBase64EncodedBinaryEntity
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; } = default!;
        public string Data { get; set; } = default!;
    }
}

