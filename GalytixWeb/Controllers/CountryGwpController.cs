using GalytixWeb.ApiModels;
using GalytixWeb.Services.Abstractions;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace GalytixWeb.Controllers
{
    [ApiController]
    [Route("api/gwp")]
    public class CountryGwpController : ControllerBase
    {
        private readonly IGWPService _gwpService;

        public CountryGwpController([NotNull] IGWPService gwpService)
        {
            _gwpService = gwpService;
        }

        [Route("avg")]
        public async Task<Dictionary<string, double>> Post([FromBody]GWPRequest gwp)
        {
            return await _gwpService.CalculateForCountryAndLob(gwp.Country, gwp.LOB);
        }
    }
}
