namespace MAG_GameLibraries.Results
{
    public readonly struct Result : IResult
    {
        public static Result Success = new Result ();

        public Error? Error { get; }
        public bool HasError => Error != null;

        public Result(Error error)
        {
            Error = error;
        }
    }
}