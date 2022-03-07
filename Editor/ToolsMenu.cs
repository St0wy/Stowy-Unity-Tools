using UnityEditor;
using static UnityEditor.AssetDatabase;

namespace StowyTools.Editor
{
    public static class ToolsMenu
    {
        [MenuItem("Tools/Setup/Create Default Folders")]
        public static void CreateDefaultFolders()
        {
            Folders.CreateDirectories("_Project", "Scripts", "Sprites", "Scenes");
            Refresh();
        }


        [MenuItem("Tools/Setup/Create Git Files")]
        public static async void CreateGitFiles() => await Git.CreateGitFiles();

        [MenuItem("Tools/Setup/Load New Manifest")]
        public static async void LoadNewManifest() =>
            await Packages.ReplacePackagesFromGist("0c04492a8aa4797a3dbe797f1d051220");

        [MenuItem("Tools/Setup/Packages/New Input System")]
        public static void AddInputSystem() => Packages.InstallUnityPackage("inputsystem");

        [MenuItem("Tools/Setup/Packages/Post Processing")]
        public static void AddPostProcessing() => Packages.InstallUnityPackage("postprocessing");
    }
}