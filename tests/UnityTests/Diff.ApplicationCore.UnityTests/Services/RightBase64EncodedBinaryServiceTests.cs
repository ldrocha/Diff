using System;
using AutoFixture.Idioms;
using Diff.ApplicationCore.Interfaces.Services;
using Diff.ApplicationCore.Requests;
using Diff.ApplicationCore.Responses;
using Diff.ApplicationCore.Services;
using Diff.Helpers.AutoData;
using Diff.Infrastructure.Entities;
using FluentAssertions;
using NSubstitute;

namespace Diff.ApplicationCore.UnityTests.Services
{
	public class RightBase64EncodedBinaryServiceTests
	{
        [Theory, AutoNSubstituteData]
        public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(RightBase64EncodedBinaryService).GetConstructors());
        }

        [Theory, AutoNSubstituteData]
        public void Sut_IsAssignableFrom(RightBase64EncodedBinaryService sut)
        {
            Assert.IsAssignableFrom<IRightBase64EncodedBinaryService>(sut);
        }


        [Theory, AutoNSubstituteData]
        public async Task AddOrUpdate_ShouldCallRepositoryAndReturnResponse(
            RightBase64EncodedBinaryRequest request,
            RightBase64EncodedBinaryEntity entity,
            RightBase64EncodedBinaryResponse response,
            RightBase64EncodedBinaryService sut)
        {
            sut.Mapper.Map<RightBase64EncodedBinaryEntity>(request).Returns(entity);
            sut.RightBase64EncodedBinaryRepository.Get(request.Id).Returns(entity);
            sut.Mapper.Map<RightBase64EncodedBinaryResponse>(entity).Returns(response);

            var result = await sut.AddOrUpdate(request);

            sut.Mapper.Received(1).Map<RightBase64EncodedBinaryEntity>(request);
            await sut.RightBase64EncodedBinaryRepository.Received(1).AddOrUpdate(entity);
            await sut.RightBase64EncodedBinaryRepository.Received(1).Get(request.Id);
            sut.Mapper.Received(1).Map<RightBase64EncodedBinaryResponse>(entity);

            result.Should().BeEquivalentTo(response);
        }

        [Theory, AutoNSubstituteData]
        public async Task Get_ShouldCallRepositoryAndReturnResponse_WhenExecuted(
            string id,
            RightBase64EncodedBinaryEntity entity,
            RightBase64EncodedBinaryResponse response,
            RightBase64EncodedBinaryService sut)
        {
            sut.RightBase64EncodedBinaryRepository.Get(id).Returns(entity);
            sut.Mapper.Map<RightBase64EncodedBinaryResponse>(entity).Returns(response);

            var result = await sut.Get(id);

            await sut.RightBase64EncodedBinaryRepository.Received(1).Get(id);
            sut.Mapper.Received(1).Map<RightBase64EncodedBinaryResponse>(entity);

            result.Should().BeEquivalentTo(response);
        }
    }
}

