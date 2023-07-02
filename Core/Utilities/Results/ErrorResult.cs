namespace Core.Utilities.Results
{
    public class ErrorResult:Result
    {
        public ErrorResult(bool success, string message) : base(false, message)
        {
        }

        public ErrorResult(bool success) : base(false)
        {
        }
    }
}
