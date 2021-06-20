using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities.Auditing;

namespace Icxl.Abp.ChurchSetting.Domain
{
    public class ChurchSetting: FullAuditedAggregateRoot<Guid>
    {
        protected ChurchSetting()
        {
        }
        public ChurchSetting(
            [NotNull] string churchSettingName,
            bool enable,
            [NotNull] string providerName,
            [CanBeNull] string providerKey,
            ICollection<ChurchSettingNode> churchSettingNodes = null)
        {
            ChurchSettingName = churchSettingName;
            Enable = enable;
            ProviderName = providerName;
            ProviderKey = providerKey;
            ChurchSettingNodes = churchSettingNodes ?? new List<ChurchSettingNode>();
        }
        
        [NotNull] public virtual string ChurchSettingName { get; protected set; }
        
        public virtual bool Enable { get; protected set; }
        
        [NotNull] public virtual string ProviderName { get; protected set; }
        
        [CanBeNull] public virtual string ProviderKey { get; protected set; }
        
        public int NodesMaxIndex { get; set; }
        
        public virtual ICollection<ChurchSettingNode> ChurchSettingNodes { get; protected set; }
        
    }
}