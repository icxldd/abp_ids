using System;
using System.Collections.Generic;
using Volo.Abp.Localization;

namespace Icxl.Abp.ChurchSetting.ChurchSettings.Definitions
{
    public class ChurchSettingDefinition
    {
        public string Name { get; set; }

        public Guid? DefaultValue { get; set; }

        public List<string> Providers { get; set; }

        private ILocalizableString _displayName;

        public ILocalizableString DisplayName
        {
            get => _displayName;
            set => _displayName = value;
        }
        public ChurchSettingDefinition(string name, ILocalizableString displayName = null)
        {
            Name = name;
            DisplayName = displayName;
            Providers = new List<string>();
        }
        public virtual ChurchSettingDefinition WithProviders(params string[] providers)
        {
            if (!providers.IsNullOrEmpty())
            {
                Providers.AddRange(providers);
            }

            return this;
        }
    }
}