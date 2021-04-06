using GraphRedaktor.Models.Handlers;
using GraphRedaktor.Models.Interfaces;
using GraphRedaktor.Models.MyEventArgs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace GraphRedaktor.Models
{
    /// <summary>
    /// обработчик файлов
    /// </summary>
    public interface IFileHandler : IInfoMessageInterface
    {        
        /// <summary>
        /// сохранение рисунка
        /// </summary>
        /// <param name="bitmapImage">рисунок</param>
        public void SaveFile(Bitmap bitmapImage, string path);
        /// <summary>
        /// получить имя и путь к файлу для сохранения
        /// </summary>
        /// <returns>путь к конечному файлу</returns>
        public string GetFiePathForSaving();
        /// <summary>
        /// получить имя и путь к файлу для загрузки
        /// </summary>
        /// <returns>путь к конечному файлу</returns>
        public string GetFiePathForLoading();
        /// <summary>
        /// получить рисунок из файла
        /// </summary>
        /// <param name="filePath">путь к файлу</param>
        /// <returns></returns>
        public Bitmap GetBitmapFromFile(string filePath);
    }
    public class FileHandler : BaseHandler, IFileHandler
    {
        public FileHandler()
        {
        }

        public event EventHandler OnErrorMessageSend;
        public event EventHandler OnDataForLongOperationSend;

        /// <summary>
        /// отправка сообщенеия во внешние классы
        /// </summary>
        /// <param name="message">текст сообщения</param>
        private void SendErrorMessageOut(string message)
        {
            if (OnErrorMessageSend != null)
                OnErrorMessageSend.Invoke(this, new StringEventArgs(message));
        }
        public void SaveFile(Bitmap bitmapImage, string path)
        {
            if (path == "")
                return;

            if(bitmapImage == null)
            {
                SendErrorMessageOut("Ошибка открытия рисунка");
                return;
            }

            FileStream fs = null;
            try
            {                
                fs = new FileStream(path, FileMode.Open, FileAccess.Write, FileShare.Write);
                
                    if (fs != null)
                    {
                    
                            if(OnDataForLongOperationSend != null)
                            {
                                OnDataForLongOperationSend.Invoke(this, new LongOperationEventArgs("Сохранение файла", 0));
                                for (int i=0; i<80; i+=20)
                                {
                                    Thread.Sleep(1000); //эмуляция долгой операции
                                    OnDataForLongOperationSend.Invoke(this, new LongOperationEventArgs("Сохранение файла", i));
                                }
                            }
                            bitmapImage.Save(fs, ImageFormat.Bmp);
                            bitmapImage.Dispose();
                            if (OnDataForLongOperationSend != null)
                            {
                                OnDataForLongOperationSend.Invoke(this, new LongOperationEventArgs("Сохранение файла", 100));
                            }                            
                    }
                    else
                        SendErrorMessageOut("Ошибка открытия потока файла");
                
            }
            catch (Exception ex)
            {
                SendErrorMessageOut(string.Format("Ошибка сохранения файла {0}", ex.Message));
            }
            finally
            {
                if(fs != null)
                    fs.Close();
            }
        }
        private string GetFiePath(FileDialog fileDialog, string caption)
        {
            fileDialog.Filter = "Bitmap Image|*.bmp";
            fileDialog.Title = caption;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                if (fileDialog.FileName != "")
                {
                    return fileDialog.FileName;
                }
                else
                    SendErrorMessageOut("Нужно указать корректное имя файла");
            }

            return "";
        }
        public string GetFiePathForSaving()
        {
            return GetFiePath(new SaveFileDialog(), "Сохранить рисунок");            
        }
        public string GetFiePathForLoading()
        {
            return GetFiePath(new OpenFileDialog(), "Загрузить рисунок");
        }

        #region один из способов решения ошибки файл занят другим процессом
        //[DllImport("Kernel32.dll", EntryPoint = "CopyMemory")]
        //private extern static void CopyMemory(IntPtr dest, IntPtr src, uint length);

        //public static Image CreateIndexedImage(string path)
        //{
        //    using (var sourceImage = (Bitmap)Image.FromFile(path))
        //    {
        //        var targetImage = new Bitmap(sourceImage.Width, sourceImage.Height,
        //          sourceImage.PixelFormat);
        //        var sourceData = sourceImage.LockBits(
        //          new Rectangle(0, 0, sourceImage.Width, sourceImage.Height),
        //          ImageLockMode.ReadOnly, sourceImage.PixelFormat);
        //        var targetData = targetImage.LockBits(
        //          new Rectangle(0, 0, sourceImage.Width, sourceImage.Height),
        //          ImageLockMode.WriteOnly, targetImage.PixelFormat);
        //        CopyMemory(targetData.Scan0, sourceData.Scan0,
        //          (uint)sourceData.Stride * (uint)sourceData.Height);
        //        sourceImage.UnlockBits(sourceData);
        //        targetImage.UnlockBits(targetData);
        //        targetImage.Palette = sourceImage.Palette;
        //        return targetImage;
        //    }
        //}
        #endregion
        /// <summary>
        /// создание копии изображения для освобождения ресурсов файла
        /// </summary>
        /// <param name="path">путь к файлу</param>
        /// <returns>картинка</returns>
        private Image CreateNonIndexedImage(string path)
        {
            using (var sourceImage = Image.FromFile(path))
            {
                var targetImage = new Bitmap(sourceImage.Width, sourceImage.Height,
                  PixelFormat.Format32bppArgb);
                using (var canvas = Graphics.FromImage(targetImage))
                {
                    canvas.DrawImageUnscaled(sourceImage, 0, 0);
                }
                return targetImage;
            }
        }

        public Bitmap GetBitmapFromFile(string filePath)
        {
            Bitmap tmpBitmap = null;
            try
            {
                #region OldCode
                //using (FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                //{
                //    tmpBitmap = (Bitmap)Bitmap.FromStream(stream);
                //}

                //tmpBitmap = (Bitmap)Bitmap.FromFile(filePath);

                //tmpBitmap = new Bitmap(filePath);

                //using (FileStream stream = File.OpenRead(filePath))
                //{
                //    tmpBitmap = (Bitmap)Image.FromStream(stream);
                //}
                #endregion

                tmpBitmap = (Bitmap)CreateNonIndexedImage(filePath);
            }
            catch (Exception ex) { return null; }

            return tmpBitmap;
        }
    }
}
