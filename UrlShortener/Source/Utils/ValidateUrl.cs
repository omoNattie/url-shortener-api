using System.Net;

namespace UrlShortener.Source.Utils;

public static class Validator
{
    public static async Task<bool> ValidateUrl(string url)
    {
        using var client = new HttpClient();
        try
        {
            using var response = await client.GetAsync(url);
            return (response.StatusCode == HttpStatusCode.OK);
            
        }
        catch (Exception e)
        {
            Console.Write(e.Message);
            return false;
        }
    }
}