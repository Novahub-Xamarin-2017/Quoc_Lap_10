using System.Collections.Generic;
using System.IO;
using Android.App;
using Android.Graphics;
using Android.Util;
using Newtonsoft.Json;
using Environment = System.Environment;
using Path = System.IO.Path;

namespace Exercise2.Models
{
    public class Ultilities
    {
        public static Bitmap Base64ToBitmap(string base64String)
        {
            var imageAsBytes = Base64.Decode(base64String, Base64Flags.Default);
            return BitmapFactory.DecodeByteArray(imageAsBytes, 0, imageAsBytes.Length);
        }

        public static List<T> GetDefaultData<T>(string fileName)
        {
            using (var stream = Application.Context.Assets.Open(fileName))
            {
                var streamReader = new StreamReader(stream);
                var content = streamReader.ReadToEnd();
                return JsonConvert.DeserializeObject<List<T>>(content);
            }
        }

        public static List<T> GetData<T>(string fileName)
        {
            var filePath = GetFilePath(fileName);
            if (!File.Exists(filePath))
            {
                return new List<T>();
            }
            var data = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<T>>(data);
        }

        public static void SaveJson<T>(List<T> data, string fileName)
        {
            var filePath = GetFilePath(fileName);
            var content = JsonConvert.SerializeObject(data);
            File.WriteAllText(filePath, content);
        }

        private static string GetFilePath(string fileName)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, fileName);
        }
    }
}