using Chinook.Core.ServiceModels;
using JsonApiFramework.Conventions;
using JsonApiFramework.ServiceModel;
using JsonApiFramework.ServiceModel.Configuration;

namespace Chinook.Core.HypemediaConfiguration
{
    public static class ConfigurationFactory
    {
        public static IServiceModel CreateServiceModel()
        {
            var serviceModelBuilder = new ServiceModelBuilder();
            serviceModelBuilder.Configurations.Add(new HomeServiceModelConfiguration());
            serviceModelBuilder.Configurations.Add(new CustomerServiceModelConfiguration());
            serviceModelBuilder.Configurations.Add(new AlbumServiceModelConfiguration());
            serviceModelBuilder.Configurations.Add(new ArtistServiceModelConfiguration());
            serviceModelBuilder.Configurations.Add(new EmployeeServiceModelConfiguration());
            serviceModelBuilder.Configurations.Add(new GenreServiceModelConfiguration());
            serviceModelBuilder.Configurations.Add(new InvoiceServiceModelConfiguration());
            serviceModelBuilder.Configurations.Add(new InvoiceItemServiceModelConfiguration());
            serviceModelBuilder.Configurations.Add(new MediaTypeModelConfiguration());
            serviceModelBuilder.Configurations.Add(new PlaylistModelConfiguration());
            serviceModelBuilder.Configurations.Add(new TrackModelConfiguration());
            serviceModelBuilder.HomeResource<Home>();

            var createConventions = CreateConventions();
            var serviceModel = serviceModelBuilder.Create(createConventions);
            return serviceModel;
        }

        public static IConventions CreateConventions()
        {
            var conventionsBuilder = new ConventionsBuilder();

            conventionsBuilder.ApiAttributeNamingConventions()
                              .AddStandardMemberNamingConvention();

            conventionsBuilder.ApiTypeNamingConventions()
                              .AddPluralNamingConvention()
                              .AddStandardMemberNamingConvention();

            conventionsBuilder.ResourceTypeConventions()
                              .AddPropertyDiscoveryConvention();

            var conventions = conventionsBuilder.Create();
            return conventions;
        }
    }
}