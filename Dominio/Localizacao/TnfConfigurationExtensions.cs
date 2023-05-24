using ExempleAPI.Dominio.Localizacao;
using Tnf.Configuration;
using Tnf.Localization;
using Tnf.Localization.Dictionaries;

namespace ExemploAPI.Dominio.Localizacao
{
    public static class TnfConfigurationExtensions
    {
        public static void UseDomainLocalization(this ITnfConfiguration tnfConfiguration)
        {
            tnfConfiguration.Localization.Languages.Add(new LanguageInfo("pt-BR", isDefault: true));

            tnfConfiguration.Localization.Sources.Add(
                new DictionaryBasedLocalizationSource(LocalizacaoCaminho.MensagensErro,
                new JsonEmbeddedFileLocalizationDictionaryProvider(
                    typeof(LocalizacaoCaminho).Assembly,
                    "Modelo.Dominio.Localizacao.Origem")));
        }

    }
}
