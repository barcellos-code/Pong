namespace GameStage
{
    internal class PongGameStage : IGameStage
    {
        public Bounds Bounds { get; private set; }

        public void Create(IGameStageParameters parameters)
        {
            var width = parameters.Width;
            var height = parameters.Height;
            Bounds = new(width, height);
        }
    }
}
