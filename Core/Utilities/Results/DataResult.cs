namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data, bool success, string message) : base(success, message) //Success ve Data'nin yaninda mesaj da geriye döndürmek istersek
        {
            Data = data;
        }

        public DataResult(T data, bool success) : base(success) //Burada success yaninda Data'yi da geri döndürüyoruz.
        {
            Data = data;
        }

        public T Data { get; }
    }
}