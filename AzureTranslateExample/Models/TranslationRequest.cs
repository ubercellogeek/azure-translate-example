namespace AzureTranslateExample.Models
{
    public class TranslationRequest
    {
        public string Text { get; set; }
        public string FromLanguageISOCode { get; set; }
        public string ToLanguageISOCode { get; set; }
    }
}