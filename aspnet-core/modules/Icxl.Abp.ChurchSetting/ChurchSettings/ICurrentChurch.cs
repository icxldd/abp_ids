using Volo.Abp.DependencyInjection;

namespace Icxl.Abp.ChurchSetting.ChurchSettings
{
    public interface ICurrentChurch : ITransientDependency
    {
        public string UserId { get; set; }

        public string GuildId { get; set; }
    }
}