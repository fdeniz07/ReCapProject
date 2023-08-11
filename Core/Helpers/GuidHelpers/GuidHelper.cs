using System;

namespace Core.Helpers.GuidHelpers
{
    public class GuidHelper
    {
        public static string CreateGuid()
        {

            return Guid.NewGuid().ToString(); 

            #region Aciklama

            /* Ister : Her yüklenen resim GUID formatinda tutulacaktir
             *
             * Burada yüklediğimiz dosyamız için eşsiz bir isim oluşturduk.Yani dosya eklerken dosyanın adı kendi olmasın,
             * biz ona eşsiz bir isim oluşturalım ki aynı isimde başka bir dosya varsa çakışmasınlar.
             * Guid.NewGuid()=> bu metot bize eşsiz bir değer oluşturdu.
             * ToString()=> bununlada string hale getirdik.
             * Guid.NewGuid()=> bu ifade bana eşsiz bir değer oluşturdu ToString() bunu kullanarakta ben değerimi 16 lık sayı tabanına çevirdi
             * Tüm amaç eşsiz bir değer oluşturalım ki aynı isimden dosyalar olursa çakışmasın.
             *
             */

            #endregion
        }
    }
}
