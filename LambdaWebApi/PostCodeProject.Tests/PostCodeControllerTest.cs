using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.TestUtilities;
using Microsoft.AspNetCore.Routing;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.TestUtilities;
using Moq;

using PostCodeProject;
using PostCodeProject.Interface;
using PostCodeProject.Controllers;
using Xunit;
using PostCodeProject.Model;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;

namespace DeveloperTest.Tests
{
    public class PostCodeControllerTest
    {

        /// <summary>
        /// Tests the controller action method Autocomplete_partialpostcode.
        /// </summary>
        /// <param name="postcode">A UK valid postcode.</param>
        /// <returns>returns an OK result wth status code 200</returns>
        [Theory]
        [InlineData("")]
        public async Task TestAutoComplete(string serviceInput)
        {
            var message = new List<string>();
            var mockPostCodeService = new Mock<IPostCodeService>();
            mockPostCodeService.Setup(s => s.AutoCompletePostalCodes(It.IsAny<string>())).Returns(message);
            var controller = new PostcodeController(mockPostCodeService.Object);

            // Act
            var result = controller.AutocompletePartialPostcode(serviceInput);

            // Assert

            var okResult = Assert.IsType<OkObjectResult>(result);

        }

        /// <summary>
        /// Tests the controller action method Lookup_postcode.
        /// </summary>
        /// <param name="postcode">A UK valid postcode.</param>
        /// <returns>returns an OK result wth status code 200</returns>
        [Theory]
        [InlineData("")]
        public async Task TestLookup(string serviceInput)
        {
            var message = new List<PostcodeResult>();
            var mockPostCodeService = new Mock<IPostCodeService>();
            mockPostCodeService.Setup(s => s.GetPostcodeInfo(It.IsAny<string>())).Returns(message);
            var controller = new PostcodeController(mockPostCodeService.Object);

            // Act
            var result = controller.LookupPostcode(serviceInput);

            // Assert

            var okResult = Assert.IsType<OkObjectResult>(result);

        }
    }
}



