using System;
using System.Collections.Generic;
using System.Text;
using Icxl.Abp.Ids.Localization;
using Volo.Abp.Application.Services;

namespace Icxl.Abp.Ids
{
    /* Inherit your application services from this class.
     */
    public abstract class IdsAppService : ApplicationService
    {
        protected IdsAppService()
        {
            LocalizationResource = typeof(IdsResource);
        }
    }
}
