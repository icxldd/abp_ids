using Icxl.Abp.Ids.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Icxl.Abp.Ids.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class IdsController : AbpController
    {
        protected IdsController()
        {
            LocalizationResource = typeof(IdsResource);
        }
    }
}