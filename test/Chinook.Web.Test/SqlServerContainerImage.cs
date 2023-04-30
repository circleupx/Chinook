using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Containers;
using DotNet.Testcontainers.Images;
using System.Threading.Tasks;
using Xunit;

namespace Chinook.Web.UnitTest
{
    public class SqlServerContainerImage : IAsyncLifetime
    {
        private readonly IFutureDockerImage _sqlServerContainerImage;
        private readonly IContainer _sqlServerContainer;

        public SqlServerContainerImage()
        {
            var projectDirectory = CommonDirectoryPath.GetProjectDirectory();
            _sqlServerContainerImage = new ImageFromDockerfileBuilder()
                .WithDockerfileDirectory(projectDirectory, string.Empty)
                .WithDockerfile("Dockerfile")
                .WithName("mssql-application-factory")
                .Build();

            const int mssqlBindPort = 1433;
            _sqlServerContainer = new ContainerBuilder()
                .WithImage("mssql-application-factory")
                .WithPortBinding(mssqlBindPort, mssqlBindPort)
                .WithWaitStrategy(Wait.ForUnixContainer().UntilPortIsAvailable(mssqlBindPort))
                .Build();
        }

        /// <summary>
        /// Clean up process, delete images and containers
        /// </summary>
        /// <returns></returns>
        public async Task DisposeAsync()
        {
            await _sqlServerContainerImage
                .DeleteAsync()
                .ConfigureAwait(false);

            await _sqlServerContainer
                .DisposeAsync()
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Bootstrap process, create image and containers.
        /// </summary>
        /// <returns></returns>
        public async Task InitializeAsync()
        {
            await _sqlServerContainerImage
                .CreateAsync()
                .ConfigureAwait(false);

            await _sqlServerContainer
                .StartAsync()
                .ConfigureAwait(false);
        }
    }
}
