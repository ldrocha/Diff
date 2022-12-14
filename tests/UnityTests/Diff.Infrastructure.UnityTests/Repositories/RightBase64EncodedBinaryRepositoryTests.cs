using System;
using AutoFixture.Idioms;
using Diff.Helpers.AutoData;
using Diff.Infrastructure.Interfaces.Repositories;
using Diff.Infrastructure.Repositories;

namespace Diff.Infrastructure.UnityTests.Repositories
{
	public class RightBase64EncodedBinaryRepositoryTests
	{
        [Theory, AutoNSubstituteData]
        public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(RightBase64EncodedBinaryRepository).GetConstructors());
        }

        [Theory, AutoNSubstituteData]
        public void Sut_IsAssignableFrom(RightBase64EncodedBinaryRepository sut)
        {
            Assert.IsAssignableFrom<IRightBase64EncodedBinaryRepository>(sut);
        }
    }
}

