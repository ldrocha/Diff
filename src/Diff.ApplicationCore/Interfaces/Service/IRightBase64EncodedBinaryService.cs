using System;
using Diff.ApplicationCore.Requests;
using Diff.ApplicationCore.Responses;

namespace Diff.ApplicationCore.Interfaces.Services
{
	public interface IRightBase64EncodedBinaryService
	{
        RightBase64EncodedBinaryResponse Get(string id);

        RightBase64EncodedBinaryResponse AddOrUpdate(RightBase64EncodedBinaryRequest request);
    }
}