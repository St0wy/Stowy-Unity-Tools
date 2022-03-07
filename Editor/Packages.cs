using System.Threading.Tasks;

namespace StowyTools.Editor
{
    public static class Packages
    {
        public static async Task ReplacePackagesFromGist(string id, string user = "St0wy")
        {
            string url = GithubGist.GetGistUrl(id, user);
            string contents = await GithubGist.GetContents(url);
            ReplacePackageFile(contents);
        }

        public static void ReplacePackageFile(string contents)
        {
            FileHelper.WriteFileInProject("Packages/manifest.json", contents);
            UnityEditor.PackageManager.Client.Resolve();
        }

        public static void InstallUnityPackage(string packageName) =>
            UnityEditor.PackageManager.Client.Add($"com.unity.{packageName}");
    }
}