using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace OptionExample
{
    public class ApplicationOptionSetup : IConfigureOptions<ApplicationOptions>
    {
        private readonly IConfiguration _configuration;
        public ApplicationOptionSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void Configure(ApplicationOptions options)
        {
            _configuration.GetSection(nameof(ApplicationOptions)).Bind(options);
        }
    }
}
