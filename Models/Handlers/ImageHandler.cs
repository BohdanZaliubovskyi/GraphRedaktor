using GraphRedaktor.Models.Handlers;
using GraphRedaktor.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace GraphRedaktor.Models.MyEventArgs
{
    public interface IImageHandler : IInfoMessageInterface
    {
        /// <summary>
        /// инвертирование картинки
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        Bitmap InvertBitmap(Bitmap bitmap);
    }
    /// <summary>
    /// обработчик картинок
    /// </summary>
    public class ImageHandler : BaseHandler, IImageHandler
    {
        public event EventHandler OnErrorMessageSend;
        public event EventHandler OnDataForLongOperationSend;

        public Bitmap InvertBitmap(Bitmap bitmap)
        {
            if(bitmap == null || bitmap.Width <= 0 && bitmap.Height <= 0)
            {
                if (OnErrorMessageSend != null)
                    OnErrorMessageSend.Invoke(this, new StringEventArgs("Отсутствует изображение для нвертирования"));

                return null;
            }

            int x;
            int y;
            int allPoints = bitmap.Width * bitmap.Height;
            double curPoints = 0.0;
            for (x = 0; x < bitmap.Width; x++)
            {
                for (y = 0; y < bitmap.Height; y++)
                {
                    Color oldColor = bitmap.GetPixel(x, y);
                    Color newColor;
                    newColor = Color.FromArgb(oldColor.A, 255 - oldColor.R, 255 - oldColor.G, 255 - oldColor.B);
                    bitmap.SetPixel(x, y, newColor);
                    curPoints++;
                    if (OnDataForLongOperationSend != null)
                        OnDataForLongOperationSend.Invoke(this, new LongOperationEventArgs("Инверсия изображения", Convert.ToInt32((curPoints/allPoints)*100)));
                }
            }
            return bitmap;
        }
    }
}
