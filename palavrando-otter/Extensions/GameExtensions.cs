using Otter;
using Palavrando.Entities;
using System.Collections.Generic;
using System.IO;

namespace Palavrando.Extensions
{
    internal static class GameExtensions
    {
        static public List<string> pathList;

        /// <summary>
        /// Redefin the PickupItem position on screen
        /// </summary>
        public static PickupItem ChangePosition(this PickupItem item)
        {
            var set = 100;
            var randPosition = Rand.IntXY(
                set, MyGlobal.WINDOWWIDTH - set,
                set, MyGlobal.WINDOWHEIGHT - set);

            item.SetPosition(randPosition.X, randPosition.Y);
            return item;
        }

        /// <summary>
        /// Recursive function to get all png image files
        /// </summary>
        public static List<Image> ImageListMaker(string targetDirectory, out List<string> paths, string wordName = null, List<Image> imgList = null)
        {
            if (imgList == null)
                imgList = new List<Image>();

            if (pathList == null)
                pathList = new List<string>();

            paths = pathList;

            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
            {
                var hasPng = fileName.Contains(".png");
                if (wordName != null)
                {
                    if (fileName.Contains(wordName) && hasPng)
                    {
                        pathList.Add(fileName);
                        imgList.Add(new Image(fileName));
                    }
                }
                else if (hasPng)
                {
                    pathList.Add(fileName);
                    imgList.Add(new Image(fileName));
                }
            }

            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                ImageListMaker(subdirectory, out paths, wordName, imgList);

            

            return imgList;
        }
    }

    public enum Tag
    {
        Player,
        PickupItem,
        Enemy,
    }
}