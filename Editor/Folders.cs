using System.IO;
using UnityEngine;

namespace StowyTools.Editor
{
    public static class Folders
    {
        public static void CreateDirectories(string root, params string[] directories)
        {
            string fullPathString = Path.Combine(Application.dataPath, root);
            foreach (string directory in directories)
            {
                Directory.CreateDirectory(Path.Combine(fullPathString, directory));
            }
        }
    }
}