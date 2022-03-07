using System.IO;
using UnityEngine;

namespace StowyTools.Editor
{
    public static class FileHelper
    {
        public static void WriteFileInProject(string filename, string contents)
        {
            string path = Path.Combine(Application.dataPath, $"../{filename}");
            File.WriteAllText(path, contents);
        }
    }
}