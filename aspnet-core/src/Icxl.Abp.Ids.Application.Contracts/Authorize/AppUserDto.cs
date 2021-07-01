using System;
using Volo.Abp.Application.Dtos;

namespace Icxl.Abp.Ids.Authorize
{
    public class AppUserDto:FullAuditedEntityDto<Guid>
    {

        public virtual Guid? TenantId { get; private set; }
        public virtual string UserName { get; private set; }
        public virtual string Name { get; private set; }
        public virtual string Surname { get; private set; }
        public virtual string Email { get; private set; }
        public virtual bool EmailConfirmed { get; private set; }
        public virtual string PhoneNumber { get; private set; }
        public virtual bool PhoneNumberConfirmed { get; private set; }
        public virtual string NormalizedUserName { get; private set; }
        public virtual string NormalizedEmail { get; private set; }
        public virtual string SecurityStamp { get; private set; }

        public int Sex { get; set; }

        public string QQ { get; set; }
    }
}