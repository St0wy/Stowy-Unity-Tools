using System.Threading.Tasks;

namespace StowyTools.Editor
{
    public static class Git
    {
        public static async Task CreateGitFiles()
        {
            const string gistId = "c4a79cb5bfec0c472f32a6b313ca1fa4";
            await CreateGitignoreFromGist(gistId);
            await CreateGitattributesFromGist(gistId);
        }

        public static async Task CreateGitignoreFromGist(string id, string user = "St0wy")
        {
            string url = GithubGist.GetGistUrl(id, user, ".gitignore");
            string contents = await GithubGist.GetContents(url);
            FileHelper.WriteFileInProject(".gitignore", contents);
        }

        public static async Task CreateGitattributesFromGist(string id, string user = "St0wy")
        {
            string url = GithubGist.GetGistUrl(id, user, ".gitattributes");
            string contents = await GithubGist.GetContents(url);
            FileHelper.WriteFileInProject(".gitattributes", contents);
        }
    }
}