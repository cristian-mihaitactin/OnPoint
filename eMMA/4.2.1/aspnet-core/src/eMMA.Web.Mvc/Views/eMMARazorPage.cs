using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;

namespace eMMA.Web.Views
{
    public abstract class eMMARazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected eMMARazorPage()
        {
            LocalizationSourceName = eMMAConsts.LocalizationSourceName;
        }
    }
}
