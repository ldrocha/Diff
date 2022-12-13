using System;
using Diff.ApplicationCore.Requests;
using Diff.ApplicationCore.Responses;

namespace Diff.ApplicationCore.Interfaces.Services
{
	public interface ILeftBase64EncodedBinaryService
	{
        Task<LeftBase64EncodedBinaryResponse> Get(string id);

        Task<LeftBase64EncodedBinaryResponse> AddOrUpdate(LeftBase64EncodedBinaryRequest request);
    }
}