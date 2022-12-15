using AutoFixture.Idioms;
using Diff.Helpers.AutoData;
using Diff.Infrastructure.Interfaces.Repositories;
using Diff.Infrastructure.Repositories;

namespace Diff.Infrastructure.UnityTests.Repositories
{
    public class LeftBase64EncodedBinaryRepositoryTests
	{
        [Theory, AutoNSubstituteData]
        public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(LeftBase64EncodedBinaryRepository).GetConstructors());
        }

        [Theory, AutoNSubstituteData]
        public void Sut_IsAssignableFrom(LeftBase64EncodedBinaryRepository sut)
        {
            Assert.IsAssignableFrom<ILeftBase64EncodedBinaryRepository>(sut);
        }
    }
}

