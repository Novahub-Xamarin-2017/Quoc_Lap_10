using System;
using System.Collections.Generic;
using System.IO;
using Android.App;
using Android.Graphics;
using Android.Util;
using Newtonsoft.Json;

namespace Exercise1.Models
{
    class Ultilites
    {
        public static Bitmap Base64ToBitmap(String base64String)
        {
            var imageAsBytes = Base64.Decode(base64String, Base64Flags.Default);
            return BitmapFactory.DecodeByteArray(imageAsBytes, 0, imageAsBytes.Length);
        }

        public static List<T> ReadJson<T>(string fileName)
        {
            using (var stream = Application.Context.Assets.Open(fileName))
            {
                var streamReader = new StreamReader(stream);
                var content = streamReader.ReadToEnd();
                return JsonConvert.DeserializeObject<List<T>>(content);
            }
        }
    }
}