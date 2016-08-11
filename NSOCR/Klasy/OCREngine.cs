using NSOCR_NameSpace;
using NSOCRLib;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;

namespace NSOCR.Klasy
{
    internal class OCREngine
    {
        private int CfgObj, OcrObj;
        public int ImgObj;
        private string text;
        private string Number;
        private string val;
        public NSOCRClass OCR;

        public OCREngine()
        {
            OCR = new NSOCRClass();
            val = "1";
        }

        //Odzczy obrazu
        public string ReadImage(string Path)
        {
            OCR.Engine_InitializeAdvanced(out CfgObj, out OcrObj, out ImgObj);
            Config();
            OCR.Engine_SetLicenseKey("");
            OCR.Cfg_Create(out CfgObj);
            OCR.Cfg_LoadOptions(CfgObj, "Config.dat");
            if (Path.Contains("pdf") || Path.Contains("PDF"))
                PDFToImage(Path);
            else
                OCR.Img_LoadFile(ImgObj, Path);
            OCR.Img_OCR(ImgObj, TNSOCR.OCRSTEP_BINARIZE + 1, TNSOCR.OCRSTEP_ZONING, TNSOCR.OCRFLAG_NONE);
            OCR.Img_OCR(ImgObj, TNSOCR.OCRSTEP_FIRST, TNSOCR.OCRSTEP_LAST, 0);
            OCR.Img_OCR(ImgObj, TNSOCR.OCRSTEP_ZONING + 1, TNSOCR.OCRSTEP_LAST, TNSOCR.OCRFLAG_NONE);
            OCR.Img_GetImgText(ImgObj, out text, TNSOCR.FMT_EXACTCOPY);
            text = Regex.Replace(text, @"([^A-Za-zżźćńółęąśŻŹĆĄŚĘŁÓŃ0-9^]|^\s)", string.Empty, RegexOptions.Compiled);
            text.ToLower();
            OCR.Engine_Uninitialize();
            OCR.Img_Destroy(ImgObj);
            return text;
        }

        //Odczyt kodu kreskowego
        public string Barcode(string Path)
        {
            OCR.Engine_InitializeAdvanced(out CfgObj, out OcrObj, out ImgObj);
            Config();
            OCR.Cfg_LoadOptions(CfgObj, "Config.dat");
            if (Path.Contains("pdf") || Path.Contains("PDF"))
                PDFToImage(Path);
            else
                OCR.Img_LoadFile(ImgObj, Path);
            OCR.Img_OCR(ImgObj, TNSOCR.OCRSTEP_FIRST, TNSOCR.OCRSTEP_LAST, TNSOCR.IMG_FORMAT_FLAG_BINARIZED);
            OCR.Blk_GetBarcodeText(ImgObj, 0, out Number);
            OCR.Engine_Uninitialize();
            OCR.Img_Destroy(ImgObj);
            if (Number == null)
                Number = "0";
            return Number;
        }

        //Konfiguracja Silnika
        public void Config()
        {
            OCR.Cfg_LoadOptions(CfgObj, "Config.dat");
            OCR.Cfg_SetOption(CfgObj, TNSOCR.BT_DEFAULT, "Main/FastMode", val);
            OCR.Cfg_SetOption(CfgObj, TNSOCR.BT_DEFAULT, "PixLines/RemoveLines", val);
            OCR.Cfg_SetOption(CfgObj, TNSOCR.BT_DEFAULT, "Main/GrayMode", val);
            OCR.Cfg_SetOption(CfgObj, TNSOCR.BT_DEFAULT, "WordAlizer/CorrectMixed", val);
            OCR.Cfg_SetOption(CfgObj, TNSOCR.BT_DEFAULT, "ImgAlizer/NoiseFilter", val);
            OCR.Cfg_SaveOptions(CfgObj, "Config.dat");
        }

        public void PDFToImage(string file)
        {
            Ghostscript.NET.Rasterizer.GhostscriptRasterizer rasterizer = null;

            using (rasterizer = new Ghostscript.NET.Rasterizer.GhostscriptRasterizer())
            {
                rasterizer.Open(file);

                for (int i = 1; i <= rasterizer.PageCount; i++)
                {
                    Image img = rasterizer.GetPage(300, 300, i);
                    Bitmap bmp = new Bitmap(img);
                    BitmapData bmpDate = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                    IntPtr ptr = bmpDate.Scan0;
                    int bytes = Math.Abs(bmpDate.Stride) * bmp.Height;
                    byte[] rgbVal = new byte[bytes];
                    System.Runtime.InteropServices.Marshal.Copy(ptr, rgbVal, 0, bytes);
                    bmp.UnlockBits(bmpDate);
                    Array byteArray = rgbVal;
                    OCR.Img_LoadBmpData(ImgObj, ref byteArray, bmp.Width, bmp.Height, TNSOCR.BMP_24BIT, 0);
                }

                rasterizer.Close();
            }
        }
    }
}