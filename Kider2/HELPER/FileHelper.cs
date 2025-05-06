//using Microsoft.AspNetCore.Mvc;
//using Microsoft.CodeAnalysis.Elfie.Model.Strings;
//using NuGet.Packaging;

//namespace Kider2.HELPER
//{
//    public static class FileHelper
//    {
//        public static async Task<string> SaveFileAsync(this IFormFile file,string webrootpath,string folder)
//        {
//            string filepath = Path.Combine(webrootpath, folder,file.FileName).ToLower();
//            if (!Directory.Exists(filepath))
//            {
//                Directory.CreateDirectory(filepath);
//            }
//            var path = $"/{folder}?" + Guid.NewGuid() + file.FileName;
//            using (FileStream fileStream = new FileStream(filepath, FileMode.Create))
//            {
//                file.CopyTo(fileStream);
//            };

           
//            return file.Name;
//        }
//    }
//}
