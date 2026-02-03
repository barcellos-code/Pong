using Microsoft.Extensions.DependencyInjection;
using Paddles;

namespace Ball
{
    internal class Ball(int posX, int posY, int dirX, int dirY, int stageWidth,
        int stageHeight) : IBall
    {
        public int PositionX { get; private set; } = posX;

        public int PositionY { get; private set; } = posY;

        public int DirectionX { get; private set; } = dirX;

        public int DirectionY { get; private set; } = dirY;

        private readonly int _initialPosX = posX;
        private readonly int _initialPosY = posY;
        private readonly int _stageWidth = stageWidth;
        private readonly int _stageHeight = stageHeight;

        public void Move()
        {
            BounceOffStageBounds();
            BounceOffPaddles();

            PositionX += DirectionX;
            PositionY += DirectionY;

            ResetBackToStageCenter();
        }

        private void BounceOffStageBounds()
        {
            if (PositionY >= _stageHeight - 1
                || PositionY <= 0)
                DirectionY *= -1;
        }

        private void BounceOffPaddles()
        {
            var paddlesService = PaddlesContainer.ServiceProvider
                .GetService<IPaddlesService>();
            
            for (var i = 0; i < paddlesService?.NumberOfPaddles; i++)
            {
                var paddle = paddlesService?.GetPaddle(i);

                var isBallTouchingPaddleFromTheRight
                    = DirectionX < 0 && PositionX == paddle?.PositionX + 1;
                
                var isBallTouchingPaddleFromTheLeft
                    = DirectionX > 0 && PositionX == paddle?.PositionX - 1;
                
                var isBallVerticallyAlignedWithPaddle
                    = PositionY >= paddle?.PositionY
                        && PositionY <= paddle?.PositionY + paddle?.Size;
                
                if (isBallVerticallyAlignedWithPaddle
                    && (isBallTouchingPaddleFromTheRight
                        || isBallTouchingPaddleFromTheLeft))
                {
                    DirectionX *= -1;
                    return;
                }
            }
        }

        private void ResetBackToStageCenter()
        {
            if (PositionX >= _stageWidth)
            {
                ResetPosition();
                return;
            }

            if (PositionX < 0)
            {
                ResetPosition();
                return;
            }

            void ResetPosition()
            {
                PositionX = _initialPosX;
                PositionY = _initialPosY;
            }
        }
    }
}
