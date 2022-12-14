using System;
using AutoMapper;
using Diff.ApplicationCore.Requests;
using Diff.ApplicationCore.Responses;
using Diff.Infrastructure.Entities;

namespace Diff.ApplicationCore.AutoMapper
{
	public class RequestToEntityProfile : Profile
	{
		public RequestToEntityProfile()
		{
            CreateMap<LeftBase64EncodedBinaryRequest, LeftBase64EncodedBinaryEntity > ();
            CreateMap<RightBase64EncodedBinaryRequest, RightBase64EncodedBinaryEntity > ();
        }
	}
}

