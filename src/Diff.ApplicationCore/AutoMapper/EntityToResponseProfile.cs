using AutoMapper;
using Diff.ApplicationCore.Responses;
using Diff.Infrastructure.Entities;

namespace Diff.ApplicationCore.AutoMapper
{
    public class EntityToResponseProfile : Profile
    {
		public EntityToResponseProfile()
		{
            CreateMap<LeftBase64EncodedBinaryEntity, LeftBase64EncodedBinaryResponse>();
            CreateMap<RightBase64EncodedBinaryEntity, RightBase64EncodedBinaryResponse>();
        }
    }
}

