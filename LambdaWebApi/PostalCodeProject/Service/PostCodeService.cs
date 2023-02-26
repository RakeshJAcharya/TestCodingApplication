using PostCodeProject.Interface;
using PostCodeProject.Model;
using Newtonsoft.Json;

namespace PostCodeProject.Service
{
    public class PostCodeService: IPostCodeService
    {
        private static string baseUrl { get; set; } = "http://api.postcodes.io/postcodes/";


        /// <summary>
        /// Autocomplete a postcode partial.
        /// </summary>
        /// <param name="postcode">A UK valid postcode.</param>
        /// <returns>returns an list of matching postcodes</returns>
        public  List<string> AutoCompletePostalCodes(string postcode)
        {
            try
            {
                if (!string.IsNullOrEmpty(postcode))
                {
                    string contents = GetRawResponse(postcode + "/autocomplete");

                    //Deserializing using Newtonsoft.JSON to a PostcodeInfo object.
                    var postcodeInfo = JsonConvert.DeserializeObject<PostalCodePartialModel>(contents);

                    //Checking for errors.
                    if (postcodeInfo.Status != 200)
                    {
                        return new List<string>();
                    }

                    //Returning.
                    return postcodeInfo.Result;
                }
                else
                    return new List<string>();
            }
            catch(Exception ex)
            {
                return new List<string>();
            }
        }


        /// <summary>
        /// Get the information about a given postcode in class form.
        /// </summary>
        /// <param name="postcode">A UK valid postcode.</param>
        /// <returns>A PostcodeResult object.</returns>
        public List<PostcodeResult> GetPostcodeInfo(string postcode)
        {
            try
            {
                if (!string.IsNullOrEmpty(postcode))
                {
                    string contents = GetRawResponse(postcode);

                    //Deserializing using Newtonsoft.JSON to a PostcodeInfo object.
                    var postcodeInfo = JsonConvert.DeserializeObject<PostcodeInfo>(contents);

                    //Checking for errors.
                    if (postcodeInfo.Status != 200)
                    {
                        return new List<PostcodeResult>();
                    }

                    //Returning.

                    return CalculateArea(postcodeInfo.Result);
                }
                else
                    return new List<PostcodeResult>();
            }
            catch(Exception ex)
            {
                return new List<PostcodeResult>();
            }
        }


        /// <summary>
        /// Get the raw JSON response from the API for a given postcode.
        /// </summary>
        /// <param name="postcode">The postcode to fetch.</param>
        /// <returns>Raw JSON string.</returns>
        private string GetRawResponse(string postcode)
        {
            string contents="";
            if (!string.IsNullOrEmpty(postcode))
            {
                //Replace any spaces in the postcode with "%20" for URL encoding.
                postcode = postcode.Replace(" ", "%20");

                //Grabbing the JSON string from API.
                
                using (var wc = new System.Net.WebClient())
                {
                    contents = wc.DownloadString(baseUrl + postcode);
                }
            }
            return contents;
        }


        private List<PostcodeResult> CalculateArea(PostcodeResult postcodeResult)
        {
            double latitude = postcodeResult.Latitude;

            string area = "";
            if (latitude < 52.229466)
                area= "South";
            if (latitude >= 52.229466 && latitude < 53.27169)
                area= "Midlands";
            if (latitude >= 53.27169)
                area= "North";

            postcodeResult.Area = area;
            List<PostcodeResult> codeResult = new List<PostcodeResult>
            {
                postcodeResult
            };

            return codeResult;
        }
    }
}
