using System;
using Diff.ApplicationCore.Requests;
using Diff.ApplicationCore.Responses;

namespace Diff.ApplicationCore.Interfaces.Services
{
	public interface IRightBase64EncodedBinaryService
	{
        Task<RightBase64EncodedBinaryResponse> Get(string id);

        Task<RightBase64EncodedBinaryResponse> AddOrUpdate(RightBase64EncodedBinaryRequest request);
    }
}