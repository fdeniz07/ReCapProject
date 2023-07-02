namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public bool Success { get; }
        public string Message { get; }

        public Result(bool success, string message) : this(success) //Kod tekrari yapmamak icin ikinci constructor'u this keywordu ile cagiriyoruz.
        //Ya sadece 2. const. calisacak ya da 1.ve 2.const. ayni anda calisacaktir. Bu bize az kod ile cok is yapabilmemizi saglayacaktir.
        {
            Message = message;
        }

        public Result(bool success) //sadece success döndürmek istersek
        {
            Success = success;
        }
    }
}