using AutoFixture.Idioms;
using Diff.Api.Controllers;
using Diff.Helpers.AutoData;

namespace Diff.Api.UnityTests.Controllers
{
    public class DifferenceControllerTests
	{
        [Theory, AutoNSubstituteData]
        public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(DifferenceController).GetConstructors());
        }
    }
}

