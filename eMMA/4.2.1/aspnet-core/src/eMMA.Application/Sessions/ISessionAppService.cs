using System.Threading.Tasks;
using Abp.Application.Services;
using eMMA.Sessions.Dto;

namespace eMMA.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
