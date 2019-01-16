using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using eMMA.Uni.Instances.Dto;

namespace eMMA.Uni.Instances
{
    public interface ILabAppService : IAsyncCrudAppService<InstanceDto, Guid, PagedResultRequestDto, InstanceDto, InstanceDto>
    {
        Task<InstanceDto> AddIUniClass(InstanceDto instanceDto);
    }
}
