using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using eMMA.Authorization;

namespace eMMA
{
    [DependsOn(
        typeof(eMMACoreModule), 
        typeof(AbpAutoMapperModule))]
    public class eMMAApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<eMMAAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(eMMAApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
