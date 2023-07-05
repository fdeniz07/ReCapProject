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
        public static string CARS_NOT_FOUND= "Uyarı: Araçlar bulunamadı";

        //USER MESSAGES
        public static string USERS_LISTED = "Bilgi: Kullanicilar listelendi";
        public static string USER_LISTED = "Bilgi: {0} id'li kullanici gösteriliyor";
        public static string USER_ADDEED = "Bilgi: Kullanici eklendi";
        public static string USER_UPDATED = "Bilgi: Kullanici güncelllendi";
        public static string USERS_DELETED = "Bilgi: Kullanici silindi";
        public static string USER_NOT_FOUND = "Uyarı: {0} id'li kullanici bulunamadı";

        //CUSTOMER MESSAGES
        public static string CUSTOMERS_LISTED = "Bilgi: Müsteriler listelendi";
        public static string CUSTOMER_LISTED = "Bilgi: {0} id'li müsteri gösteriliyor";
        public static string CUSTOMER_ADDEED = "Bilgi: Müsteri eklendi";
        public static string CUSTOMER_UPDATED = "Bilgi: Müsteri güncelllendi";
        public static string CUSTOMERS_DELETED = "Bilgi: Müsteri silindi";
        public static string CUSTOMER_NOT_FOUND = "Uyarı: {0} id'li müsteri bulunamadı";

        //RENTAL MESSAGES
        public static string RENTALS_LISTED = "Bilgi: Kiralar listelendi";
        public static string RENTAL_LISTED = "Bilgi: {0} id'li kira gösteriliyor";
        public static string RENTAL_ADDEED = "Bilgi: Kira eklendi";
        public static string RENTAL_UPDATED = "Bilgi: Kira güncellendi";
        public static string RENTAL_DELETED = "Bilgi: Kira silindi";
        public static string RENTAL_NOT_FOUND = "Uyarı: {0} id'li kira bulunamadı";
        public static string RENTAL_UNDELIVERED_CAR = "Uyarı: {0} id'li arac henüz teslim edilmedi";
        public static string RENTAL_NOT_AVAILABLE = "Uyarı: Belirtilen araliklarda kira mevcut degil";
        public static string RENTAL_AVAILABLE = "Bilgi: Istenilen arac kiralanabilir";

        //SYSTEM MESSAGES
        public static string MAINTAINCE_TIME = "Uyarı: Sistem bakımda";
    }
}