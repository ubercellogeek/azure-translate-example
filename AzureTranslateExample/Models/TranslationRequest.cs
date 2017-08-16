using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace AzureTranslateExample.Models
{
    public class TranslationRequest
    {
        [Required]
        public string Text { get; set; }
        [Required]
        public string FromLanguageISOCode { get; set; }
        [Required]
        public List<string> ToLanguageISOCode { get; set; }
    }
}