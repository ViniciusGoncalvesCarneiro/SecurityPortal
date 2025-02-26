using System.Reflection;
using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace GumAdvisor.Localization
{
    public static class GumAdvisorLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(
                    GumAdvisorConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(GumAdvisorLocalizationConfigurer).GetAssembly(),
                        "GumAdvisor.Localization.GumAdvisor"
                    )
                )
            );
        }
    }
}