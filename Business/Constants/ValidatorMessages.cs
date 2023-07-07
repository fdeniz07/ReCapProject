namespace Business.Constants
{
    public static class ValidatorMessages
    {
        public static string NotEmpty { get; } = " boş geçilmemelidir.";
        public static string NotShorterChar { get; } = " {0} karakterden kısa olmamalıdır.";
        public static string InvalidFormat { get; } = " uygun formatta olmalıdır.";
        public static string NotLongerChar { get; } = " {0} karakterden uzun olmamalıdır.";
        public static string LoadImage { get; } = " lütfen görsel seçiniz";
        public static string NotSmallerNum { get; } = " {0}'den/dan küçük olmamalıdır.";
        public static string NotGreaterNum { get; } = " {0}'den/dan büyük olmamalıdır.";
    }
}
