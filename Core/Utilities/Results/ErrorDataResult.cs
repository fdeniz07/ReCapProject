namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, false, message) //geriye data,error ve mesaj döndürmek istersek
        {
        }

        public ErrorDataResult(T data) : base(data, false) //geriye data ve error döndürmek istersek
        {
        }

        public ErrorDataResult(string message) : base(default, false, message) //geriye dönüs tipi,error yaninda mesaj döndürmek istersek
        {
        }

        public ErrorDataResult() : base(default, false) // geriye sadece dönüs tipi ve error döndürmek istersek
        {
        }
    }
}
