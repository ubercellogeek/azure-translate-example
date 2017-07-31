using AzureTranslateExample.Interfaces;
using AzureTranslateExample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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

        [HttpPost]
        public async Task<IActionResult> Translate([FromBody] TranslationRequest request)
        {
            TranslationResponse translationResponse = await _service.Translate(request);
            return Ok(translationResponse);
        }
    }
}