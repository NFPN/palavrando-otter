using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace palavrando_otter.Systems
{
    class PathFolder
    {
        static public string getDirectory()
        {
            string i = Environment.CurrentDirectory;
            string newPath = Path.GetFullPath(Path.Combine(i, @"..\..\"));
            return newPath;
        }
    }
}
