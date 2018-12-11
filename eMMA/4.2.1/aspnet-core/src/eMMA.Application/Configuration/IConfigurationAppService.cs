using System.Threading.Tasks;
using eMMA.Configuration.Dto;

namespace eMMA.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
