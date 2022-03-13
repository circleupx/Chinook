using System;
using FluentAssertions;
using Xunit;

namespace Chinook.Core.Test
{
    public class ProjectDependencies
    {
        [Fact]
        public void CoreProject_Dependencies_ShouldNotContainAReferenceToInfrastructureProject()
        {
            var coreProjectAssembly = typeof(Chinook.Core.ChinookJsonApiDocumentContext).Assembly;
            var infrastructureProjectAssembly = typeof(Chinook.Infrastructure.Database.ChinookDbContext).Assembly;

            coreProjectAssembly.Should().NotReference(infrastructureProjectAssembly);
        }
    }
}
