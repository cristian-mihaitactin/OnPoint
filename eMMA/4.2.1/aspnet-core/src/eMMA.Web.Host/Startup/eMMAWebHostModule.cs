using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using eMMA.Configuration;

namespace eMMA.Web.Host.Startup
{
    [DependsOn(
       typeof(eMMAWebCoreModule))]
    public class eMMAWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public eMMAWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(eMMAWebHostModule).GetAssembly());
        }
    }
}
