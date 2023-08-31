using static System.Collections.Specialized.BitVector32;

namespace Business.Constants
{
    //Constant = sabit
    public static class Messages
    {
        //Magic Strings

        //CAR MESSAGES
        public static string CAR_ADDED = "Bilgi: Araç eklendi";
        public static string CAR_UPDATED = "Bilgi: Araç güncellendi";
        public static string CAR_DELETED = "Bilgi: Araç silindi";
        public static string CAR_INVISIBLED = "Bilgi: Aracın görüntülenmesi kaldırıldı";
        public static string CARNAME_IS_INVALID = "Hata: Araç ismi gecersiz";
        public static string CARS_LISTED = "Bilgi: Araçlar listelendi";
        public static string CAR_LISTED_WITH_ID = "Bilgi: {0} id'li araç gösteriliyor";
        public static string CAR_LISTED = "Bilgi: Araç gösteriliyor";
        public static string CAR_NOT_FOUND = "Uyarı: {0} id'li araç bulunamadı";
        public static string CARS_NOT_FOUND = "Uyarı: Araçlar bulunamadı";

        //USER MESSAGES
        public static string USERS_LISTED = "Bilgi: Kullanıcılar listelendi";
        public static string USER_LISTED = "Bilgi: {0} id'li kullanıcı gösteriliyor";
        public static string USER_ADDED = "Bilgi: Kullanıcı eklendi";
        public static string USER_UPDATED = "Bilgi: Kullanıcı güncelllendi";
        public static string USERS_DELETED = "Bilgi: Kullanıcı silindi";
        public static string USER_NOT_FOUND = "Uyarı: {0} email adresi sistemde bulunamadı";
        public static string USER_ALREADY_EXIST = "Uyarı: Kullanıcı mevcut";

        //CUSTOMER MESSAGES
        public static string CUSTOMERS_LISTED = "Bilgi: Müşteriler listelendi";
        public static string CUSTOMER_LISTED = "Bilgi: {0} id'li müşteri gösteriliyor";
        public static string CUSTOMER_ADDEED = "Bilgi: Müşteri eklendi";
        public static string CUSTOMER_UPDATED = "Bilgi: Müşteri güncelllendi";
        public static string CUSTOMERS_DELETED = "Bilgi: Müşteri silindi";
        public static string CUSTOMER_NOT_FOUND = "Uyarı: {0} id'li müşteri bulunamadı";

        //RENTAL MESSAGES
        public static string RENTALS_LISTED = "Bilgi: Kiralar listelendi";
        public static string RENTAL_LISTED = "Bilgi: {0} id'li kira gösteriliyor";
        public static string RENTAL_ADDEED = "Bilgi: Kira eklendi";
        public static string RENTAL_UPDATED = "Bilgi: Kira güncellendi";
        public static string RENTAL_DELETED = "Bilgi: Kira silindi";
        public static string RENTAL_NOT_FOUND = "Uyarı: {0} id'li kira bulunamadı";
        public static string RENTAL_UNDELIVERED_CAR = "Uyarı: {0} id'li arac henüz teslim edilmedi";
        public static string RENTAL_NOT_AVAILABLE = "Uyarı: Belirtilen araliklarda kira mevcut değil";
        public static string RENTAL_AVAILABLE = "Bilgi: Istenilen arac kiralanabilir";

        //UPLOAD MESSAGES
        public static string IMAGE_UPLOADED_SUCCESSFULY = "Bilgi: Resim başarılı şekilde yüklendi.";

        //SYSTEM MESSAGES
        public static string MAINTAINCE_TIME = "Uyarı: Sistem bakımda";

        //AUTHENTICATION/JWT MESSAGES
        public static string AUTHORIZATION_DENIED = "Uyarı: Yetkiniz yok.";
        public static string EMAIL_ALREADY_EXIST = "Uyarı: Bu emaile ait bir kullanıcı daha önce kayıt edilmiştir!";
        public static string USER_REGISTRATION_SUCCESS = "Bilgi: Kullanıcı kaydı basarı ile gerçekleştirilmiştir";
        public static string PASSWORD_IS_WRONG = "Uyarı: Parola Hatası";
        public static string LOGIN_IS_SUCCESSFULLY = "Bilgi: Giriş Başarılı";
        public static string TOKEN_CREATED_SUCCESSFULLY = "Bilgi: Token başarılı şekilde oluşturuldu";
    }
}