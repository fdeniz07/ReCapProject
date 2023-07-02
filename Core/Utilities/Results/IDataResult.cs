namespace Core.Utilities.Results
{
    //Void olmayan, deger döndüren yapilar icinde DataResult yapisi kullaniyoruz
    public interface IDataResult<T> : IResult
    {
        T Data { get; }
    }
}