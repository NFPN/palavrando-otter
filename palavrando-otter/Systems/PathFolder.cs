using System;
using System.IO;

namespace Palavrando.Systems
{
    public class PathFolder
    {
        static public string GetDirectory()
        {
            string current = Environment.CurrentDirectory;
            string newPath = Path.GetFullPath(Path.Combine(current, @"..\..\"));
            return newPath;
        }
    }
}