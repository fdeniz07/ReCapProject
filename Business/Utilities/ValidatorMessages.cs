namespace Traversal.CoreLayer.Utilities
{
    public class ValidatorMessages
    {
        public string NotEmpty { get; } = " boş geçilmemelidir.";
        public string NotShorterChars { get; } = " karakterden kısa olmamalıdır.";
        public string ValidFormat { get; } = " uygun formatta olmalıdır.";
        public string NotLongerChars { get; } = " karakterden uzun olmamalıdır.";
        public string LoadImage { get; } = " lütfen görsel seçiniz";
        public string NotSmallerNums { get; } = " küçük olmamalıdır.";
        public string NotGreaterNums { get; } = " büyük olmamalıdır.";
    }
}
