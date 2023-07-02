namespace Core.Utilities.Results
{
    //Temel void degerler icin baslangic
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}