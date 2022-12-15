using System;
using AutoFixture.Idioms;
using Diff.ApplicationCore.Enums;
using Diff.ApplicationCore.Interfaces.Services;
using Diff.ApplicationCore.Responses;
using Diff.ApplicationCore.Services;
using Diff.Helpers.AutoData;
using Diff.Infrastructure.Entities;
using FluentAssertions;
using NSubstitute;

namespace Diff.ApplicationCore.UnityTests.Services
{
	public class DifferenceServiceTests
	{
        [Theory, AutoNSubstituteData]
        public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(DifferenceService).GetConstructors());
        }

        [Theory, AutoNSubstituteData]
        public void Sut_IsAssignableFrom(DifferenceService sut)
        {
            Assert.IsAssignableFrom<IDifferenceService>(sut);
        }

        [Theory]
        [InlineAutoNSubstituteData("123", null)]
        [InlineAutoNSubstituteData("456", null, null)]
        public async Task Get_WhenDataToCompareIsNull_ShoulReturnNull(
            string id,
            LeftBase64EncodedBinaryEntity leftEntity,
            RightBase64EncodedBinaryEntity rightEntity,
            DifferenceService sut
            )
        { 
            sut.LeftBase64EncodedBinaryRepository.Get(id).Returns(leftEntity);
            sut.RightBase64EncodedBinaryRepository.Get(id).Returns(rightEntity);

            var result = await sut.Get(id);

            await sut.LeftBase64EncodedBinaryRepository.Received(1).Get(id);
            await sut.RightBase64EncodedBinaryRepository.Received(1).Get(id);
            result.Should().Be(null);
        }

        [Theory]
        [InlineAutoNSubstituteData("123", "MTIzIDEyMyAxMjMgMTIzIDEyMw==", "MTIzIDEyMyAxMjMgMTIzIDEyMw==", DifferenceStatus.Equal)]
        [InlineAutoNSubstituteData("456", "NDU2IDQ1NiA0NTYgNDU2IDQ1Ng==", "NDU2IDQ1NiA0NTYgNDU2IA==", DifferenceStatus.DifferentLength)]
        [InlineAutoNSubstituteData("789", "Nzg5IDc4OSA3ODkgNzg5IDc4OQ==", "Nzg5IDc4OSAwMDAgNzg5IDAwMA==", DifferenceStatus.SameLength)]
        public async Task Get_WhenExecuted_ShouldReturnCorrectResponse(
            string id,
            string leftData,
            string rightData,
            DifferenceStatus status,
            DifferenceService sut
            )
        {
            var leftEntity = new LeftBase64EncodedBinaryEntity { Id = id, Data = leftData };
            var rightEntity = new RightBase64EncodedBinaryEntity { Id = id, Data = rightData };

            sut.LeftBase64EncodedBinaryRepository.Get(id).Returns(leftEntity);
            sut.RightBase64EncodedBinaryRepository.Get(id).Returns(rightEntity);

            var result = await sut.Get(id);

            await sut.LeftBase64EncodedBinaryRepository.Received(1).Get(id);
            await sut.RightBase64EncodedBinaryRepository.Received(1).Get(id);
            result.Id.Should().Be(id);
            result.Status.Should().Be(status);
        }

        [Theory]
        [AutoNSubstituteData]
        public async Task Get_WhenStatusIsSameLenght_ShouldReturnResponseWithDetail(
        string id,
        DifferenceService sut)
        {
            var leftEntity = new LeftBase64EncodedBinaryEntity { Id = id, Data = "Nzg5IDc4OSA3ODkgNzg5IDc4OQ=="};
            var rightEntity = new RightBase64EncodedBinaryEntity { Id = id, Data = "Nzg5IDc4OSAwMDAgNzg5IDAwMA==" };
            var status = DifferenceStatus.SameLength;
            var differenceDetail = new DifferenceDetail(leftEntity.Data.Length, 6, new List<int> { 8, 9, 10, 16, 17, 18});
            
            sut.LeftBase64EncodedBinaryRepository.Get(id).Returns(leftEntity);
            sut.RightBase64EncodedBinaryRepository.Get(id).Returns(rightEntity);

            var result = await sut.Get(id);

            await sut.LeftBase64EncodedBinaryRepository.Received(1).Get(id);
            await sut.RightBase64EncodedBinaryRepository.Received(1).Get(id);
            result.Id.Should().Be(id);
            result.Status.Should().Be(status);
            result.Detail.Should().BeEquivalentTo(differenceDetail);
        }
    }
}