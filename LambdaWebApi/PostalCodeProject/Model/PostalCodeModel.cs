using Newtonsoft.Json;

namespace PostCodeProject.Model
{
    public class PostcodeInfo
    {
        //The HTTP status response from Postcodes.IO.
        [JsonProperty("status")]
        public int Status { get; set;}

        //If an error is returned, it is held here.
        [JsonProperty("error")]
        public string Error { get; set;}

        //The actual result of the API call.
        [JsonProperty("result")]
        public PostcodeResult Result { get; set;}
    }

    public class PostcodeResult
    {
        //The returned postcode.
        [JsonProperty("postcode")]
        public string Postcode { get; set;}

        //The quality of the postcode.
        [JsonProperty("quality")]
        public int Quality { get; set;}

        //Eastings, northings.
        [JsonProperty("eastings")]
        public int Eastings { get; set;}

        [JsonProperty("northings")]
        public int Northings { get; set;}

        //Country the postcode is in, region.
        [JsonProperty("country")]
        public string Country { get; set;}

        [JsonProperty("region")]
        public string Region { get; set;}

        //The NHS domain of the postcode, primary care trust.
        [JsonProperty("nhs_ha")]
        public string NHSDomain { get; set;}

        [JsonProperty("primary_care_trust")]
        public string PrimaryCareTrust { get; set;}

        //Longitude, latitude.
        [JsonProperty("longitude")]
        public double Longitude { get; set;}

        [JsonProperty("latitude")]
        public double Latitude { get; set;}

        //The european electoral region of the postcode.
        [JsonProperty("european_electoral_region")]
        public string EuropeanElectoralRegion { get; set;}

        //LSOA, MSOA
        public string LSOA, MSOA;

        //Postcode incode/outcode (region and subregion).
        [JsonProperty("incode")]
        public string Incode { get; set;}

        [JsonProperty("outcode")]
        public string Outcode { get; set;}

        //Parliamentary/council stuff.
        [JsonProperty("parliamentary_constituency")]
        public string ParliamentaryConstituency { get; set;}

        [JsonProperty("admin_district")]
        public string AdminDistrict { get; set;}

        [JsonProperty("parish")]
        public string Parish { get; set;}

        [JsonProperty("admin_ward")]
        public string AdminWard { get; set;}

        [JsonProperty("admin_county")]
        public string AdminCounty { get; set;}

        [JsonProperty("ced")]
        public string CED { get; set;}

        [JsonProperty("ccg")]
        public string CCG { get; set;}

        [JsonProperty("nuts")]
        public string NUTS { get; set;}

        //Codes for this postcode.
        [JsonProperty("codes")]
        PostcodeCodes Codes { get; set;}

        [JsonProperty("area")]
        public string Area { get; set;}
    }

    //The set of assigned codes for this postcode.
    public class PostcodeCodes
    {
        [JsonProperty("parliamentary_constituency")]
        public string ParliamentaryConstituency { get; set;}

        [JsonProperty("admin_district")]
        public string AdminDistrict { get; set;}

        [JsonProperty("parish")]
        public string Parish { get; set;}

        [JsonProperty("admin_ward")]
        public string AdminWard { get; set;}

        [JsonProperty("admin_county")]
        public string AdminCounty { get; set;}

        [JsonProperty("ced")]
        public string CED { get; set;}

        [JsonProperty("ccg")]
        public string CCG { get; set;}

        [JsonProperty("nuts")]
        public string NUTS { get; set;}
    }
}
