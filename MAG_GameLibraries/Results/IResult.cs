namespace MAG_GameLibraries.Results
{
    public interface IResult
    {
        Error? Error { get; }
        bool HasError { get; }
    }
}