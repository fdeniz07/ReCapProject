namespace Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data, string message) : base(data, true, message) //geriye data ve success yaninda mesaj da döndürmek istersek
        {
        }

        public SuccessDataResult(T data) : base(data, true) //geriye data'yi ve success'i döndürmek istersek
        {
        }

        public SuccessDataResult(string message) : base(default, true, message) //geriye deger tipi,success yaninda mesaj da döndürmek istersek
        {
        }

        public SuccessDataResult() : base(default, true) //sadece geriye deger tipi ve success döndürmek istersek
        {
        }
    }
}