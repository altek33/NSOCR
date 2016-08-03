using NSOCR_NameSpace;
using NSOCRLib;
using System.Text.RegularExpressions;

namespace NSOCR
{
    internal class OCREngine
    {
        private int CfgObj, OcrObj, ImgObj;
        private string text;
        string val;
        private NSOCRClass OCR;

        public OCREngine()
        {
            OCR = new NSOCRClass();

            val = "0";
        }

        public string ReadImage(string Path)
        {
            OCR.Engine_InitializeAdvanced(out CfgObj, out OcrObj, out ImgObj);
            OCR.Engine_SetLicenseKey("");
            OCR.Cfg_Create(out CfgObj);
            OCR.Cfg_LoadOptions(CfgObj, "Config.dat"); 
            OCR.Cfg_SetOption(CfgObj,TNSOCR.BT_DEFAULT, "Main/FastMode", val);
            OCR.Cfg_SetOption(CfgObj, TNSOCR.BT_DEFAULT, "PixLines/RemoveLines", val);
            OCR.Cfg_SetOption(CfgObj, TNSOCR.BT_DEFAULT, "Main/GrayMode", val);
            OCR.Cfg_SetOption(CfgObj, TNSOCR.BT_DEFAULT, "WordAlizer/CorrectMixed", val);
            OCR.Cfg_SaveOptions(CfgObj, "Config.dat");
            OCR.Img_LoadFile(ImgObj, Path);
            OCR.Img_OCR(ImgObj, TNSOCR.OCRSTEP_BINARIZE + 1, TNSOCR.OCRSTEP_ZONING, TNSOCR.OCRFLAG_NONE);
            OCR.Img_OCR(ImgObj, TNSOCR.OCRSTEP_FIRST, TNSOCR.OCRSTEP_LAST, 0);
            OCR.Img_OCR(ImgObj, TNSOCR.OCRSTEP_ZONING + 1, TNSOCR.OCRSTEP_LAST, TNSOCR.OCRFLAG_NONE);
            OCR.Img_GetImgText(ImgObj, out text, TNSOCR.FMT_EXACTCOPY);
            text = Regex.Replace(text, @"([^A-Za-zżźćńółęąśŻŹĆĄŚĘŁÓŃ0-9]|^\s)", string.Empty, RegexOptions.Compiled);
            text.ToLower();
            OCR.Engine_Uninitialize();
            OCR.Img_Destroy(ImgObj);
            return text;
        }

        public string Barcode(string Path)
        {
            string Number;
            OCR.Engine_InitializeAdvanced(out CfgObj, out OcrObj, out ImgObj);
            OCR.Img_LoadFile(ImgObj, Path);
            OCR.Img_OCR(ImgObj, TNSOCR.OCRSTEP_FIRST, TNSOCR.OCRSTEP_LAST, TNSOCR.IMG_FORMAT_FLAG_BINARIZED);
            OCR.Blk_GetBarcodeCnt(ImgObj);
            OCR.Blk_GetBarcodeText(ImgObj, 0, out Number);
            OCR.Engine_Uninitialize();
            OCR.Img_Destroy(ImgObj);
            return Number;
        }
    }
}