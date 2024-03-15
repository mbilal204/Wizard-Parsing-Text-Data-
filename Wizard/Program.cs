using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wizard
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string folderPath = @"D:\Bilal\Development\Projects\C# Console\Wizard\Files/";
            string[] files = Directory.GetFiles(folderPath);
            foreach (var filepath in files)
            {
                String fileName = Path.GetFileName(filepath);
                string Ext = Path.GetExtension(filepath);
                if (Ext.ToUpper() == ".XML")
                {
                    string destinationFilePath = Path.Combine(folderPath) + fileName;
                    String EJText = File.ReadAllText(destinationFilePath);
                    // String[] arrJournalLine1 = EJText.Split('\n');
                    string[] arrWizardLins = EJText.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                    WizardResevration wzRes = new WizardResevration();
                    wzRes = FillWizardNo(arrWizardLins, wzRes);
                    wzRes = FillResType(arrWizardLins, wzRes);
                    wzRes = FillOutLocation(arrWizardLins, wzRes);
                    wzRes = FillInLocation(arrWizardLins, wzRes);
                    wzRes = FillOutDate(arrWizardLins, wzRes);
                    wzRes = FillInDate(arrWizardLins, wzRes);
                    wzRes = FillOutTime(arrWizardLins, wzRes);
                    wzRes = FillInTime(arrWizardLins, wzRes);
                }
            }
        }
        private static WizardResevration FillWizardNo(string[] arrWizardLins, WizardResevration wzRes)
        {
            try
            {
                String WizardNo = "";
                foreach (String str in arrWizardLins)
                {
                    if (WizardNo == "")
                    {
                        foreach (String strKey in WZKeyword.WizardNo)
                        {
                            if (str.Contains(strKey))
                            {
                                WizardNo = str;
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                wzRes.WizardNo = WizardNo.Trim();
            }
            catch (Exception)
            {

                throw;
            }
            return wzRes;
        }
        private static WizardResevration FillResType(string[] arrWizardLins, WizardResevration wzRes)
        {
            try
            {
                String ResType = "";
                foreach (String str in arrWizardLins)
                {
                    if (ResType == "")
                    {
                        foreach (String strKey in WZKeyword.ReservationType)
                        {
                            if (str.Contains(strKey))
                            {
                                ResType = str;
                                break;
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                wzRes.ResType = ResType.Trim();
            }
            catch (Exception)
            {

                throw;
            }
            return wzRes;
        }
        private static WizardResevration FillOutLocation(string[] arrWizardLins, WizardResevration wzRes)
        {
            try
            {
                String OutLocation = "";
                foreach (String str in arrWizardLins)
                {
                    if (OutLocation == "")
                    {
                        foreach (String strKey in WZKeyword.Location)
                        {
                            if (str.Contains(strKey))
                            {
                                String[] arrkey = str.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                string outLoca = arrkey[0];
                                if (strKey.Trim().ToUpper() == outLoca.Trim().ToUpper())
                                {
                                    OutLocation = outLoca;
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                wzRes.OutLocation = OutLocation.Trim();
            }
            catch (Exception)
            {

                throw;
            }
            return wzRes;
        }
        private static WizardResevration FillInLocation(string[] arrWizardLins, WizardResevration wzRes)
        {
            try
            {
                String InLocation = "";
                foreach (String str in arrWizardLins)
                {
                    if (InLocation == "")
                    {
                        foreach (String strKey in WZKeyword.Location)
                        {
                            if (str.Contains(strKey))
                            {
                                String[] arrkey = str.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                string inLoca = arrkey[3];
                                if (strKey.Trim().ToUpper() == inLoca.Trim().ToUpper())
                                {
                                    InLocation = inLoca;
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                wzRes.InLocation = InLocation.Trim();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return wzRes;
        }
        private static WizardResevration FillOutDate(string[] arrWizardLins, WizardResevration wzRes)
        {
            try
            {
                String OutDate = "";
                foreach (String str in arrWizardLins)
                {
                    if (OutDate == "")
                    {
                        foreach (String strKey in WZKeyword.Location)
                        {
                            if (str.Contains(strKey))
                            {
                                String[] arrkey = str.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                string outString = arrkey[1];
                                String[] dateArr = outString.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                                string _outDate = dateArr[0];
                                OutDate = _outDate;
                                break;
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                wzRes.OutDate = OutDate.Trim();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return wzRes;
        }
        private static WizardResevration FillInDate(string[] arrWizardLins, WizardResevration wzRes)
        {
            try
            {
                String InDate = "";
                foreach (String str in arrWizardLins)
                {
                    if (InDate == "")
                    {
                        foreach (String strKey in WZKeyword.Location)
                        {
                            if (str.Contains(strKey))
                            {
                                String[] arrkey = str.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                string outString = arrkey[arrkey.Length - 1];
                                String[] dateArr = outString.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                                string _inDate = dateArr[0];
                                InDate = _inDate;
                                break;
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                wzRes.InDate = InDate.Trim();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return wzRes;
        }
        private static WizardResevration FillOutTime(string[] arrWizardLins, WizardResevration wzRes)
        {
            try
            {
                String OutTime = "";
                foreach (String str in arrWizardLins)
                {
                    if (OutTime == "")
                    {
                        foreach (String strKey in WZKeyword.Location)
                        {
                            if (str.Contains(strKey))
                            {
                                String[] arrkey = str.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                string outString = arrkey[1];
                                String[] dateArr = outString.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                                string _OutTime = dateArr[1];
                                OutTime = _OutTime;
                                break;
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                wzRes.OutTime = OutTime.Trim();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return wzRes;
        }
        private static WizardResevration FillInTime(string[] arrWizardLins, WizardResevration wzRes)
        {
            try
            {
                String InTime = "";
                foreach (String str in arrWizardLins)
                {
                    if (InTime == "")
                    {
                        foreach (String strKey in WZKeyword.Location)
                        {
                            if (str.Contains(strKey))
                            {
                                String[] arrkey = str.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                string outString = arrkey[arrkey.Length - 1];
                                String[] dateArr = outString.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                                string _inTime = dateArr[1];
                                InTime = _inTime;
                                break;
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                wzRes.InTime = InTime.Trim();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return wzRes;
        }
        public class WizardResevration
        {
            public string WizardNo { get; set; }
            public string ResType { get; set; }
            public string OutLocation { get; set; }
            public string InLocation { get; set; }
            public string OutDate { get; set; }
            public string InDate { get; set; }
            public string OutTime { get; set; }
            public string InTime { get; set; }
            public string Group { get; set; }

        }
    }
}
