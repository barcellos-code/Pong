using GameStage;

namespace Parameters
{
    internal class PongGameStageParameters : IGameStageParameters
    {
        public int Width => 80;
        public int Height => 25;

        public int NumberOfPlayers => 2;
    }
}
