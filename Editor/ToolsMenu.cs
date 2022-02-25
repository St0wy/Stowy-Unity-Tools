using UnityEditor;
using static System.IO.Directory;
using static System.IO.Path;
using static UnityEngine.Application;
using static UnityEditor.AssetDatabase;

namespace Editor
{
    public static class ToolsMenu
    {
        [MenuItem("Tools/Setup/Create Default Folders")]
        public static void CreateDefaultFolders()
        {
            CreateDirectories("_Project", "Scripts", "Sprites", "Scenes");
            Refresh();
        }

        public static void CreateDirectories(string root, params string[] directories)
        {
            string fullPathString = Combine(dataPath, root);
            foreach (string directory in directories)
            {
                CreateDirectory(Combine(fullPathString, directory));
            }
        }
    }
}