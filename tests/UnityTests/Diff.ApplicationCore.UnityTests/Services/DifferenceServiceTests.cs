using System;
using AutoFixture.Idioms;
using Diff.ApplicationCore.Interfaces.Services;
using Diff.ApplicationCore.Services;
using Diff.Helpers.AutoData;

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
    }
}
