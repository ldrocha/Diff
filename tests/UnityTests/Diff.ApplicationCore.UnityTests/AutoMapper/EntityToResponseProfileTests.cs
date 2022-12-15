using AutoMapper;
using Diff.ApplicationCore.Responses;
using Diff.Helpers.AutoData;
using Diff.Infrastructure.Entities;
using FluentAssertions;

namespace Diff.ApplicationCore.UnityTests.AutoMapper
{
    public class EntityToResponseProfileTests
	{
        private MapperConfiguration _configuration;

        public EntityToResponseProfileTests()
        {
            _configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<LeftBase64EncodedBinaryEntity, LeftBase64EncodedBinaryResponse>();
                cfg.CreateMap<RightBase64EncodedBinaryEntity, RightBase64EncodedBinaryResponse>();
            });
        }

        [Fact]
        public void Mapper_AssertConfigurationIsValid()
        {
            _configuration.AssertConfigurationIsValid();
        }

        [Theory, AutoNSubstituteData]
        public void Mapper_ShouldMapLeftBase64EncodedBinary(LeftBase64EncodedBinaryEntity entity)
        {
            var mapper = _configuration.CreateMapper();

            var result = mapper.Map<LeftBase64EncodedBinaryEntity, LeftBase64EncodedBinaryResponse>(entity);

            result.Id.Should().Be(entity.Id);
            result.Data.Should().Be(entity.Data);
        }

        [Theory, AutoNSubstituteData]
        public void Mapper_ShouldMapRightBase64EncodedBinary(RightBase64EncodedBinaryEntity entity)
        {
            var mapper = _configuration.CreateMapper();

            var result = mapper.Map<RightBase64EncodedBinaryEntity, RightBase64EncodedBinaryResponse>(entity);

            result.Id.Should().Be(entity.Id);
            result.Data.Should().Be(entity.Data);
        }
    }
}
