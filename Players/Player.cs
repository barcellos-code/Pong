using Ball;
using Microsoft.Extensions.DependencyInjection;

namespace Players
{
    internal class Player : IPlayer
    {
        public int Score {get; private set;} = 0;

        private int _goalIndex = -1;

        public void BindGoalEvent(int goalIndex)
        {
            _goalIndex = goalIndex;
            var ballService = BallContainer.ServiceProvider.GetService<IBallService>();
            var ball = ballService?.GetBall();
            ball?.OnHitGoal += IncrementScoreIfCorrectGoal;
        }

        private void IncrementScoreIfCorrectGoal(int goalIndex)
        {
            if (goalIndex != _goalIndex)
                return;

            IncrementScore();
        }

        private void IncrementScore()
            => Score++;
    }
}
