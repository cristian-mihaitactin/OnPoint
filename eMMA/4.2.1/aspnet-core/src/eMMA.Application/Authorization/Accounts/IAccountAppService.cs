using System.Threading.Tasks;
using Abp.Application.Services;
using eMMA.Authorization.Accounts.Dto;

namespace eMMA.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
