using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Icxl.Abp.Ids.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Domain.Repositories;

namespace Icxl.Abp.Ids.Authorize
{
    [Authorize]
    public class OAuthShowService : IdsAppService, IOAuthShowService
    {
        private readonly IBasicRepository<AppUser, Guid> _appuserRepository;

        public OAuthShowService(IBasicRepository<AppUser, Guid> appuserRepository)
        {
            _appuserRepository = appuserRepository;
        }
        [HttpGet]
        public async Task<AppUserDto> ShowCurrentAccount()
        {
            Debug.Assert(CurrentUser.Id != null, "CurrentUser.Id != null");
            var obj = await _appuserRepository.FindAsync((Guid) CurrentUser.Id);
            return ObjectMapper.Map<AppUser, AppUserDto>(obj);
        }
    }
}