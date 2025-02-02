using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clive.Logic
{
    public static class IconService
    {
        public static string GetFileIconAsBase64(string filePath)
        {
            using Icon icon = Icon.ExtractAssociatedIcon(filePath);
            using Bitmap bitmap = icon.ToBitmap();
            using MemoryStream ms = new MemoryStream();

            // Save the icon as a PNG image
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

            // Convert to Base64 string
            return $"data:image/png;base64,{Convert.ToBase64String(ms.ToArray())}";
        }
    }
}
