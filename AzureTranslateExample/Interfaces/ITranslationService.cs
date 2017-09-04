using AzureTranslateExample.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AzureTranslateExample.Interfaces
{
  public interface ITranslationService
  {
      Task<TranslationResponse> Translate(TranslationRequest request);
      Task<TranslationResponse> TranslateArray(TranslateArrayRequest request);
      Task<List<LanguageInformation>> GetSupportedLanguageCodes(string isoCode = "en");
  }
}