using System;
using AutoMapper;
using Diff.ApplicationCore.Requests;
using Diff.Helpers.AutoData;
using Diff.Infrastructure.Entities;
using FluentAssertions;

namespace Diff.ApplicationCore.UnityTests.AutoMapper
{
	public class RequestToEntityProfileTests
	{
        private MapperConfiguration _configuration;

        public RequestToEntityProfileTests()
        {
            _configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<LeftBase64EncodedBinaryRequest, LeftBase64EncodedBinaryEntity>();
                cfg.CreateMap<RightBase64EncodedBinaryRequest, RightBase64EncodedBinaryRequest>();
            });
        }

        [Fact]
        public void Mapper_AssertConfigurationIsValid()
        {
            _configuration.AssertConfigurationIsValid();
        }

        [Theory, AutoNSubstituteData]
        public void Mapper_ShouldMapLeftBase64EncodedBinary(LeftBase64EncodedBinaryRequest request)
        {
            var mapper = _configuration.CreateMapper();

            var result = mapper.Map<LeftBase64EncodedBinaryRequest, LeftBase64EncodedBinaryEntity>(request);

            result.Id.Should().Be(request.Id);
            result.Data.Should().Be(request.Data);
        }

        [Theory, AutoNSubstituteData]
        public void Mapper_ShouldMapRightBase64EncodedBinary(RightBase64EncodedBinaryRequest request)
        {
            var mapper = _configuration.CreateMapper();

            var result = mapper.Map<RightBase64EncodedBinaryRequest, RightBase64EncodedBinaryRequest>(request);

            result.Id.Should().Be(request.Id);
            result.Data.Should().Be(request.Data);
        }
    }
}

