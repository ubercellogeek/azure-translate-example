using AzureTranslateExample.Interfaces;
using AzureTranslateExample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using Microsoft.Extensions.Caching.Memory;

namespace AzureTranslateExample.Controllers
{
    [Route("api/translation")]
    public class TranslationController : Controller
    {
        private ITranslationService _service;
        private IMemoryCache _memCache;

        public TranslationController(ITranslationService service, IMemoryCache memCache)
        {
            _service = service;
            _memCache = memCache;
        }

        [HttpGet]
        [Route("languages")]
        public async Task<IActionResult> GetSupportedLanguageCodes()
        {
            if(!_memCache.TryGetValue<List<LanguageInformation>>("languageInformation", out var infos))
            {
                infos = await _service.GetSupportedLanguageCodes();
                _memCache.Set<List<LanguageInformation>>("languageInformation", infos);
                return Ok(infos);
            }
            else
            {
                if(infos.Count < 1)
                {
                    infos = await _service.GetSupportedLanguageCodes();
                    _memCache.Set<List<LanguageInformation>>("languageInformation", infos);
                }
               
                return Ok(infos);
            }

            
        }

        [HttpPost]
        public async Task<IActionResult> Translate([FromBody] TranslationRequest request)
        {
            if(!ModelState.IsValid)
            {
                return StatusCode(422);
            }

            var response = await _service.Translate(request);
            return Ok(response);

            //TranslateArrayRequest arrayRequest = new TranslateArrayRequest();
            //arrayRequest.From = request.FromLanguageISOCode;
            //arrayRequest.To = request.ToLanguageISOCode.First();
            //List<string> texts = request.Text.Split("\n")?.ToList();

            //arrayRequest.Texts = texts.ToArray();

            //TranslationResponse arrayTranslationResponse = await _service.TranslateArray(arrayRequest);
            //return Ok(arrayTranslationResponse);
        }
    }
}