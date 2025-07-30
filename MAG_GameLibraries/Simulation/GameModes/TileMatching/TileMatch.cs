using MAG.Results;

namespace MAG.GameModes.TileMatching
{
    public class TileMatch : IGameMode
    {
        private ITileMatchingConfig _config;
        private ITileMatchingBoard? _board;

        public TileMatch(ITileMatchingConfig config)
        {
            _config = config;
        }

        public Result Initialize()
        {
            if (_board != null)
                return new Result(new Error("Board is already initialized"));


            return Result.Success;
        }
    }
}