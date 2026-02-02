namespace Ball
{
    internal class BallService : IBallService
    {
        private Ball? _ball;

        public void CreateBall(int stageWidth, int stageHeight)
        {
            var posX = stageWidth / 2;
            var posY = stageHeight / 2;
            _ball = new(posX, posY);
        }

        public void Dispose()
            => _ball = null;

        public IBall GetBall()
        {
            if (_ball == null)
                throw new InvalidOperationException("Ball has not been created.");

            return _ball;
        }
    }
}
