using System;
using Diff.ApplicationCore.Requests;
using Diff.ApplicationCore.Responses;

namespace Diff.ApplicationCore.Interfaces.Services
{
	public interface ILeftBase64EncodedBinaryService
	{
        LeftBase64EncodedBinaryResponse Get(string id);

        LeftBase64EncodedBinaryResponse AddOrUpdate(LeftBase64EncodedBinaryRequest request);
    }
}