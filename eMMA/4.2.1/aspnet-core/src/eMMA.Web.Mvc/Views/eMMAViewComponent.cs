using Abp.AspNetCore.Mvc.ViewComponents;

namespace eMMA.Web.Views
{
    public abstract class eMMAViewComponent : AbpViewComponent
    {
        protected eMMAViewComponent()
        {
            LocalizationSourceName = eMMAConsts.LocalizationSourceName;
        }
    }
}
