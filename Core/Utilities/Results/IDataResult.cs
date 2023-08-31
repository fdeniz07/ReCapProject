namespace Core.Utilities.Results
{
    //Void olmayan, deger döndüren yapilar icinde DataResult yapisi kullaniyoruz
    public interface IDataResult<out T> : IResult
    {
        T Data { get; }
    }
}