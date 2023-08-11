using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using Core.Helpers.GuidHelpers;

namespace Core.Helpers.FileHelper
{
    public class FileManager : IFileHelper
    {

        /// <summary> Dosya Silme Islemleri: 
        ///
        /// Burada ki string filePath, 'CarImageManager'dan gelen dosyamın kaydedildiği adres ve adı
        /// if kontrolü ile parametrede gelen adreste öyle bir dosya var mı diye kontrol ediliyor.
        /// Eğer dosya var ise dosya bulunduğu yerden siliniyor.
        /// </summary>
        /// <param name="filePath"></param>

        public void Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }


        /// <summary> Dosya Güncelleme Islemleri :
        ///
        /// Dosya güncellemek için ise gelen parametreye baktığımızda Güncellenecek yeni dosya, Eski dosyamızın kayıt dizini, ve yeni bir kayıt dizini
        /// Tekrar if kontrolü ile parametrede gelen adreste öyle bir dosya var mı diye kontrol ediliyor.
        /// Eğer dosya var ise dosya bulunduğu yerden siliniyor.
        /// Eski dosya silindikten sonra yerine geçecek yeni dosyaiçin alttaki *Upload* metoduna yeni dosya ve kayıt edileceği adres parametre olarak        döndürülüyor.
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <param name="filePath"></param>
        /// <param name="root"></param>
        /// <returns></returns>
        public string Update(IFormFile file, string filePath, string root)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            return Upload(file, root);
        }

        /// <summary> Dosya Yükleme Islemleri :
        ///
        /// file.Length=>Dosya uzunluğunu bayt olarak alır. burada Dosya gönderilmis mi gönderilmemiş diye test işlemi yapıldı.
        /// Directory=>System.IO'nın bir class'ı. burada ki işlem tam olarak şu. Bu Upload metodumun parametresi olan string root CarManager'dan gelmekte
        /// CarImageManager içerisine girdiğinizde buraya parametre olarak *PathConstants.ImagesPath* böyle bir şey gönderilidğini görürsünüz. PathConstants classı içerisine girdiğinizde string bir ifadeyle bir dizin adresi var
        /// O adres bizim Yükleyeceğimiz dosyaların kayıt edileceği adres burada *Check if a directory Exists* ifadesi şunu belirtiyor dosyanın kaydedileceği adres dizini var mı? varsa if yapısının kod bloğundan ayrılır eğer yoksa içinde ki kodda dosyaların kayıt edilecek dizini oluşturur
        ///
        /// Path.GetExtension(file.FileName)=>> Seçmiş olduğumuz dosyanın uzantısını elde ediyoruz.
        /// Core.Utilities.Helpers.GuidHelper klasürünün içinde ki GuidManager klasörüne giderseniz burada satırda ne yaptığımızı anlayacaksınız
        ///
        /// Dosyanın oluşturduğum adını ve uzantısını yan yana getiriyorum. Mesela metin dosyası ise .txt gibi bu projemizde resim yükyeceğimiz için .jpg olacak uzantılar 
        /// Burada en başta FileStrem class'ının bir örneği oluşturulu., sonrasında File.Create(root + newPath)=>Belirtilen yolda bir dosya oluşturur
        /// veya üzerine yazar. (root + newPath)=>Oluşturulacak dosyanın yolu ve adı.
        ///
        /// Kopyalanacak dosyanın kopyalanacağı akışı belirtti. yani yukarıda gelen IFromFile türündeki file dosyasınınnereye kopyalacağını söyledik.
        /// flush ile arabellekten siler.
        /// burada dosyamızın tam adını geri gönderiyoruz sebebide sql servere dosya eklenirken adı ile eklenmesi için.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="root"></param>
        /// <returns></returns>
        public string Upload(IFormFile file, string root)
        {
            if (file.Length > 0)
            {
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }
                string extension = Path.GetExtension(file.FileName);
                string guid = GuidHelper.CreateGuid();
                string filePath = guid + extension;

                using (FileStream fileStream = File.Create(root + filePath))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                    return filePath;
                }
            }
            return null;
        }
    }
}
