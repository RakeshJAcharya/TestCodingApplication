using PostCodeProject.Model;

namespace PostCodeProject.Interface
{
    public interface IPostCodeService
    {
        List<string> AutoCompletePostalCodes(string postcode);

        List<PostcodeResult> GetPostcodeInfo(string postcode);
        
    }
}
