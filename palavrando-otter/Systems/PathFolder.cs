using System;
using System.IO;

namespace Palavrando.Systems
{
    public class PathFolder
    {
        static public string GetDirectory()
        {
            string i = Environment.CurrentDirectory;
            string newPath = Path.GetFullPath(Path.Combine(i, @"..\..\"));
            return newPath;
        }
    }
}