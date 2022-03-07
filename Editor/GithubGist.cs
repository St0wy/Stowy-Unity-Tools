using System.Net.Http;
using System.Threading.Tasks;

namespace StowyTools.Editor
{
    public static class GithubGist
    {
        public static string GetGistUrl(string gistId, string user = "St0wy", string filename = "") =>
            $"https://gist.githubusercontent.com/{user}/{gistId}/raw/{filename}";

        public static async Task<string> GetContents(string url)
        {
            using var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            string content = await response.Content.ReadAsStringAsync();
            return content;
        }
    }
}