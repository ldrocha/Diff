using System;
using AutoFixture.Idioms;
using Diff.ApplicationCore.Interfaces.Services;
using Diff.ApplicationCore.Services;
using Diff.Helpers.AutoData;

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
    }
}

