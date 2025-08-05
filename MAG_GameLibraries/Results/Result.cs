namespace MAG_GameLibraries.Results
{
    public class Result
    {
        public static Result Success = new Result ();

        public Error? Error { get; }
        public bool HasError => Error != null;

        public Result() { }
        public Result(Error error)
        {
            Error = error;
        }
    }
}