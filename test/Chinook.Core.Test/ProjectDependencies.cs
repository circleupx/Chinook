using System;
using Chinook.Infrastructure;
using FluentAssertions;
using Xunit;

namespace Chinook.Core.Test
{
    public class ProjectDependencies
    {
        [Fact]
        public void CoreProject_Dependencies_ShouldNotContainAReferenceToInfrastructureProject()
        {
            var coreProjectAssembly = typeof(ChinookJsonApiDocumentContext).Assembly;
            var infrastructureProjectAssembly = typeof(ChinookDbContext).Assembly;

            coreProjectAssembly.Should().NotReference(infrastructureProjectAssembly);
        }
    }
}
