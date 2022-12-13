using System;
using Diff.ApplicationCore.Responses;

namespace Diff.ApplicationCore.Interfaces.Services
{
	public interface IDifferenceService
	{
		DifferenceResponse Get(string id);
	}
}

