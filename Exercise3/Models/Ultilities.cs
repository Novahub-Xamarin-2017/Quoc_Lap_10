using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Exercise3.Models
{
    public class Ultilities
    {
        public static List<ManagerItem> GetFileNames(string path)
        {
            var mList = new List<ManagerItem>();
            var fileAndFolderNames = Directory.GetFileSystemEntries(path);
            foreach (var name in fileAndFolderNames)
            {
                if (IsFolder(name))
                {
                    mList.Add(new ManagerItem(Resource.Drawable.folder32, name));
                }
                else if (IsMediaFile(name))
                {
                    mList.Add(new ManagerItem(Resource.Drawable.videofile32, name));
                }
                else if (IsImage(name))
                {
                    mList.Add(new ManagerItem(Resource.Drawable.image32, name));
                }
                else
                {
                    mList.Add(new ManagerItem(Resource.Drawable.file32, name));
                }
            }
            return mList;
        }

        private static bool IsImage(string name)
        {
            var imageExtensions = new[] { ".png", ".jpg", ".gif" };
            return imageExtensions.Any(name.EndsWith);
        }

        private static bool IsMediaFile(string name)
        {
            var mediaExtensions = new[] { ".avi", ".mp4", ".mkv", ".flv", ".mp3" };
            return mediaExtensions.Any(name.EndsWith);
        }

        private static bool IsFolder(string name) => Directory.Exists(name);
    }
}