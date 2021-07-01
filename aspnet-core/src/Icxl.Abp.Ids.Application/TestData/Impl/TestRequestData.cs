using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using Volo.Abp.Security.Claims;
using System.Linq;
using Icxl.Abp.Ids.Permissions;

namespace Icxl.Abp.Ids.TestData.Impl
{
    [Authorize]
    public class TestRequestData : IdsAppService, IRequestData
    {
        private readonly ICurrentPrincipalAccessor _currentPrincipalAccessor;

        public TestRequestData(ICurrentPrincipalAccessor currentPrincipalAccessor
        )
        {
            _currentPrincipalAccessor = currentPrincipalAccessor;
        }

        public string GetCurrentData()
        {
            return JsonConvert.SerializeObject(CurrentUser.UserName);
        }
    }
}