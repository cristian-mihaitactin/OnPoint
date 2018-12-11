using Abp.Application.Services;
using Abp.Application.Services.Dto;
using eMMA.MultiTenancy.Dto;

namespace eMMA.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
