using AzureTranslateExample.Interfaces;
using AzureTranslateExample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;

namespace AzureTranslateExample.Controllers
{
    [Route("api/translation")]
    public class TranslationController : Controller
    {
        private ITranslationService _service;

        public TranslationController(ITranslationService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("languages")]
        public async Task<IActionResult> GetSupportedLanguageCodes()
        {
            return Ok(await _service.GetSupportedLanguageCodes());
        }

        [HttpPost]
        public async Task<IActionResult> Translate([FromBody] TranslationRequest request)
        {
            if(!ModelState.IsValid)
            {
                return StatusCode(422);
            }
            
            TranslateArrayRequest arrayRequest = new TranslateArrayRequest();
            arrayRequest.From = request.FromLanguageISOCode;
            arrayRequest.To = request.ToLanguageISOCode.First();
            List<string> texts = request.Text.Split("\n")?.ToList();

            arrayRequest.Texts = texts.ToArray();

            TranslationResponse arrayTranslationResponse = await _service.TranslateArray(arrayRequest);
            return Ok(arrayTranslationResponse);
        }
    }
}