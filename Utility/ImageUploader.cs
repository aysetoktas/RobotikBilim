using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Utility
{
    public class ImageUploader
    {
        //Hata Kodları:
        //0-> Dosya bulunamadı hatası
        //1-> Dosya zaten var hatası
        //2-> Uzantı hatası
        public static string UploadSingleImage(string serverPath, HttpPostedFileBase file)
        {
            if (file != null)
            {
                Guid uniqueName = Guid.NewGuid();
                serverPath = serverPath.Replace("~", string.Empty);
                string[] fileArr = file.FileName.Split('.');

                string extension = fileArr[fileArr.Length - 1];

                string fileName = uniqueName + "." + extension;

                if (extension=="jpg" || extension=="png" || extension=="gif")
                {
                    if (File.Exists(HttpContext.Current.Server.MapPath(serverPath+extension)))
                    {
                        return "1";
                    }
                    else
                    {
                        var filePath = HttpContext.Current.Server.MapPath(serverPath + fileName);
                        file.SaveAs(filePath);
                        return serverPath + fileName;
                    }
                }
                else
                {
                    return "2";
                }
            }
            else
            {
                return "0";
            }
        }
    }
}