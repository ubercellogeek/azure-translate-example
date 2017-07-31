
using AzureTranslateExample.Models;
using System.Threading.Tasks;

namespace AzureTranslateExample.Interfaces
{
  public interface ITranslationService
  {
      Task<TranslationResponse> Translate(TranslationRequest request);
  }
}