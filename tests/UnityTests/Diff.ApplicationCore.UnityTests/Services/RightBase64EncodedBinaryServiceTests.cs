using System;
using AutoFixture.Idioms;
using Diff.ApplicationCore.Interfaces.Services;
using Diff.ApplicationCore.Services;
using Diff.Helpers.AutoData;

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
    }
}

