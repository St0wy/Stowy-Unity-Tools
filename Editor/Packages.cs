using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;

namespace StowyTools.Editor
{
    public static class Packages
    {
        public static async Task ReplacePackagesFromGist(string id, string user = "St0wy")
        {
            string url = GetGistUrl(id, user);
            string contents = await GetContents(url);
            ReplacePackageFile(contents);
        }

        public static string GetGistUrl(string id, string user = "St0wy") =>
            $"https://gist.githubusercontent.com/{user}/{id}/raw/";

        public static async Task<string> GetContents(string url)
        {
            using var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            string content = await response.Content.ReadAsStringAsync();
            return content;
        }

        public static void ReplacePackageFile(string contents)
        {
            string existing = Path.Combine(Application.dataPath, "../Packages/manifest.json");
            File.WriteAllText(existing, contents);
            UnityEditor.PackageManager.Client.Resolve();
        }

        public static void InstallUnityPackage(string packageName) =>
            UnityEditor.PackageManager.Client.Add($"com.unity.{packageName}");
    }
}