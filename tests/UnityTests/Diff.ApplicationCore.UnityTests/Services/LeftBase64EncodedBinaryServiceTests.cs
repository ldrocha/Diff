using System;
using AutoFixture.Idioms;
using AutoMapper;
using Diff.ApplicationCore.Interfaces.Services;
using Diff.ApplicationCore.Requests;
using Diff.ApplicationCore.Responses;
using Diff.ApplicationCore.Services;
using Diff.Helpers.AutoData;
using Diff.Infrastructure.Entities;
using Diff.Infrastructure.Repositories;
using FluentAssertions;
using NSubstitute;

namespace Diff.ApplicationCore.UnityTests.Services
{
    public class LeftBase64EncodedBinaryServiceTests
    {
        [Theory, AutoNSubstituteData]
        public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(LeftBase64EncodedBinaryService).GetConstructors());
        }

        [Theory, AutoNSubstituteData]
        public void Sut_IsAssignableFrom(LeftBase64EncodedBinaryService sut)
        {
            Assert.IsAssignableFrom<ILeftBase64EncodedBinaryService>(sut);
        }

        [Theory, AutoNSubstituteData]
        public async Task AddOrUpdate_ShouldCallRepositoryAndReturnResponse_WhenExecuted(
            LeftBase64EncodedBinaryRequest request,
            LeftBase64EncodedBinaryEntity entity,
            LeftBase64EncodedBinaryResponse response,
            LeftBase64EncodedBinaryService sut)
        {
            sut.Mapper.Map<LeftBase64EncodedBinaryEntity>(request).Returns(entity);
            sut.LeftBase64EncodedBinaryRepository.Get(request.Id).Returns(entity);
            sut.Mapper.Map<LeftBase64EncodedBinaryResponse>(entity).Returns(response);

            var result = await sut.AddOrUpdate(request);

            sut.Mapper.Received(1).Map<LeftBase64EncodedBinaryEntity>(request);
            await sut.LeftBase64EncodedBinaryRepository.Received(1).AddOrUpdate(entity);
            await sut.LeftBase64EncodedBinaryRepository.Received(1).Get(request.Id);
            sut.Mapper.Received(1).Map<LeftBase64EncodedBinaryResponse>(entity);

            result.Should().BeEquivalentTo(response);
        }

        [Theory, AutoNSubstituteData]
        public async Task WhenExecutedGet_ShouldCallRepositoryAndReturnResponse_WhenExecuted(
            string id,
            LeftBase64EncodedBinaryEntity entity,
            LeftBase64EncodedBinaryResponse response,
            LeftBase64EncodedBinaryService sut)
        {
            sut.LeftBase64EncodedBinaryRepository.Get(id).Returns(entity);
            sut.Mapper.Map<LeftBase64EncodedBinaryResponse>(entity).Returns(response);

            var result = await sut.Get(id);

            await sut.LeftBase64EncodedBinaryRepository.Received(1).Get(id);
            sut.Mapper.Received(1).Map<LeftBase64EncodedBinaryResponse>(entity);

            result.Should().BeEquivalentTo(response);
        }
    }
}

