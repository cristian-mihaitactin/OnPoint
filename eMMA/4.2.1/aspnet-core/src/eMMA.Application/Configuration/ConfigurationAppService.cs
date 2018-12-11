using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using eMMA.Configuration.Dto;

namespace eMMA.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : eMMAAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
