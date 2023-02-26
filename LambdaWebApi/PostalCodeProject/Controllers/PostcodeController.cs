using PostCodeProject.Interface;
using PostCodeProject.Model;
using PostCodeProject.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Amazon.Lambda.APIGatewayEvents;

namespace PostCodeProject.Controllers
{
    [EnableCors]
    [Route("api/[controller]/")]
    public class PostcodeController : ControllerBase
    {
        private readonly IPostCodeService _postCodeService;
        public PostcodeController(IPostCodeService postCodeService) 
        {
            _postCodeService = postCodeService;

        }

        /// <summary>
        /// Lookup a postcode partial.
        /// </summary>
        /// <param name="postcode">A UK valid postcode.</param>
        /// <returns>returns an OK result wth status code 200</returns>

        [EnableCors]
        // GET api/postcode
        [HttpGet("lookup")]
        [Produces("application/json")]
        public IActionResult LookupPostcode([FromQuery]string postcode)
        {
            //"FK6 6BL"
            return Ok(_postCodeService.GetPostcodeInfo(postcode));            
        }

        /// <summary>
        /// Autocomplete a postcode partial.
        /// </summary>
        /// <param name="postcode">A UK valid postcode.</param>
        /// <returns>returns an OK result wth status code 200</returns>
        [EnableCors]
        // GET api/postcode
        [HttpGet("autocomplete")]
        public IActionResult AutocompletePartialPostcode([FromQuery]string postcode)
        {
            //"FK6 6BL"
            return Ok( _postCodeService.AutoCompletePostalCodes(postcode));
        }

    }
}
