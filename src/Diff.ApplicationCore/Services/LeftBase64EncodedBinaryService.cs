using System;
using Diff.ApplicationCore.Interfaces.Services;
using Diff.ApplicationCore.Requests;
using Diff.ApplicationCore.Responses;

namespace Diff.ApplicationCore.Services
{
	public class LeftBase64EncodedBinaryService : ILeftBase64EncodedBinaryService

    {
		public LeftBase64EncodedBinaryService()
		{
		}

        public LeftBase64EncodedBinaryResponse AddOrUpdate(LeftBase64EncodedBinaryRequest request)
        {
            throw new NotImplementedException();
        }

        public LeftBase64EncodedBinaryResponse Get(string id)
        {
            throw new NotImplementedException();
        }
    }
}

