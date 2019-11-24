using Otter;
using Palavrando.Entities;
using System.Collections.Generic;
using System.IO;

namespace Palavrando.Extensions
{
    internal static class GameExtensions
    {
        /// <summary>
        /// Redefin the PickupItem position on screen
        /// </summary>
        public static PickupItem ChangePosition(this PickupItem item)
        {
            var randPosition = Rand.IntXY(
                item.Graphic.Width, MyGlobal.WINDOWWIDTH - (item.Graphic.Width / 2),
                item.Graphic.Height, MyGlobal.WINDOWHEIGHT - (item.Graphic.Height / 2));

            item.SetPosition(randPosition.X, randPosition.Y);
            return item;
        }

        /// <summary>
        /// Recursive function to get all png image files
        /// </summary>
        public static List<Image> ImageListMaker(string targetDirectory, List<Image> imgList = null)
        {
            if (imgList == null)
                imgList = new List<Image>();

            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
                if (fileName.Contains(".png"))
                    imgList.Add(new Image(fileName));

            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                ImageListMaker(subdirectory, imgList);

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