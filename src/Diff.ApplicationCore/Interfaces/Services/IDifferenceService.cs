using Diff.ApplicationCore.Responses;

namespace Diff.ApplicationCore.Interfaces.Services
{
    public interface IDifferenceService
	{
		Task<DifferenceResponse> Get(string id);
	}
}

