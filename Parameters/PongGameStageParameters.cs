using Stage;

namespace Parameters
{
    internal class PongGameStageParameters : IStageParameters
    {
        public int Width => 80;
        public int Height => 25;

        public int NumberOfPlayers => 2;
    }
}
