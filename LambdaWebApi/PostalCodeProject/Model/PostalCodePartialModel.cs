using Newtonsoft.Json;

namespace PostCodeProject.Model
{
    public class PostalCodePartialModel
    {
        //The HTTP status response from Postcodes.IO.
        [JsonProperty("status")]
        public int Status;

        //If an error is returned, it is held here.
        [JsonProperty("error")]
        public string Error;

        //The actual result of the API call.
        [JsonProperty("result")]
        public List<string> Result;
    }
}
