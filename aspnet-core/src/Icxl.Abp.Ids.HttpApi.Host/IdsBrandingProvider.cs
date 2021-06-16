using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Icxl.Abp.Ids
{
    [Dependency(ReplaceServices = true)]
    public class IdsBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Ids";
    }
}
