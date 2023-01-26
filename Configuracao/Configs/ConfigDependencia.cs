
using Microsoft.Extensions.Configuration;



namespace Microsoft.Extensions.DependencyInjection
{
    public static class MyConfigServiceCollectionExtensions
    {
        public static IServiceCollection AddConfig(
            this IServiceCollection services, IConfiguration config)
        {
            var assemblies = new[]
            {
                typeof(IConfiguration).Assembly,
            };
			
			return services;
        }


    }
}