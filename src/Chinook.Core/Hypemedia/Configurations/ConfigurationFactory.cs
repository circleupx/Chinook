using Chinook.Core.ServiceModels;
using JsonApiFramework.Conventions;
using JsonApiFramework.ServiceModel;
using JsonApiFramework.ServiceModel.Configuration;

namespace Chinook.Core.Hypemedia.Configurations
{
    public static class ConfigurationFactory
    {
        public static IServiceModel CreateServiceModel()
        {
            var serviceModelBuilder = new ServiceModelBuilder();
            serviceModelBuilder.Configurations.Add(new HomeServiceModelConfiguration());
            serviceModelBuilder.Configurations.Add(new CustomerServiceModelConfiguration());
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