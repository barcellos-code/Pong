namespace ExampleCode
{
    // Represents the main game class
    internal class PongExample
    {
        // Game dimensions
        private static readonly int ScreenWidth = 80;
        private static readonly int ScreenHeight = 25;

        // Paddle properties
        private static readonly int PaddleSize = 4;
        private static int _paddleOneY;
        private static int _paddleTwoY;

        // Ball properties
        private static int _ballX, _ballY;
        private static int _ballDirectionX = 1;
        private static int _ballDirectionY = 1;

        // Scores
        private static int _playerOneScore = 0;
        private static int _playerTwoScore = 0;

        // Game state
        private static bool _isGameOver = false;

        private static void ExampleEntryPoint()
        {
            Console.Title = "Console Pong";
            Console.CursorVisible = false;
#pragma warning disable CA1416 // Validate platform compatibility
            Console.SetWindowSize(ScreenWidth, ScreenHeight);
            Console.SetBufferSize(ScreenWidth, ScreenHeight);
#pragma warning restore CA1416 // Validate platform compatibility

            InitializeGame();

            while (!_isGameOver)
            {
                DrawGame();
                HandleInput();
                UpdateGame();
                Thread.Sleep(50); // Controls game speed
            }

            DrawGameOver();
        }

        // Initializes the game state
        private static void InitializeGame()
        {
            _paddleOneY = (ScreenHeight - PaddleSize) / 2;
            _paddleTwoY = (ScreenHeight - PaddleSize) / 2;
            _ballX = ScreenWidth / 2;
            _ballY = ScreenHeight / 2;
        }

        // Draws all game elements
        private static void DrawGame()
        {
            Console.Clear();
            DrawPaddle(1, _paddleOneY);
            DrawPaddle(ScreenWidth - 2, _paddleTwoY);
            DrawBall(_ballX, _ballY);
            DrawScores();
        }

        // Draws a paddle at a given X and Y position
        private static void DrawPaddle(int x, int y)
        {
            for (int i = 0; i < PaddleSize; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.Write("|");
            }
        }

        // Draws the ball at a given X and Y position
        private static void DrawBall(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("O");
        }

        // Draws the current scores
        private static void DrawScores()
        {
            Console.SetCursorPosition(ScreenWidth / 2 - 5, 0);
            Console.Write($"{_playerOneScore} - {_playerTwoScore}");
        }

        // Handles user input
        private static void HandleInput()
        {
            if (!Console.KeyAvailable)
                return;

            var keyInfo = Console.ReadKey(intercept: true);

            if (keyInfo.Key == ConsoleKey.W && _paddleOneY > 0)
                _paddleOneY--;

            if (keyInfo.Key == ConsoleKey.S && _paddleOneY < ScreenHeight - PaddleSize)
                _paddleOneY++;

            if (keyInfo.Key == ConsoleKey.UpArrow && _paddleTwoY > 0)
                _paddleTwoY--;

            if (keyInfo.Key == ConsoleKey.DownArrow && _paddleTwoY < ScreenHeight - PaddleSize)
                _paddleTwoY++;
        }

        // Updates the game state
        private static void UpdateGame()
        {
            _ballX += _ballDirectionX;
            _ballY += _ballDirectionY;

            // Ball collision with top and bottom walls
            if (_ballY <= 0 || _ballY >= ScreenHeight - 1)
                _ballDirectionY = -_ballDirectionY;

            // Ball collision with paddles
            if ((_ballX == 2 && _ballY >= _paddleOneY && _ballY < _paddleOneY + PaddleSize) ||
                (_ballX == ScreenWidth - 3 && _ballY >= _paddleTwoY && _ballY < _paddleTwoY + PaddleSize))
                _ballDirectionX = -_ballDirectionX;

            // Ball goes out of bounds
            if (_ballX < 0)
            {
                _playerTwoScore++;
                ResetBall();
            }
            else if (_ballX >= ScreenWidth)
            {
                _playerOneScore++;
                ResetBall();
            }

            // Check for a winner
            if (_playerOneScore >= 5 || _playerTwoScore >= 5)
                _isGameOver = true;
        }

        // Resets the ball to the center
        private static void ResetBall()
        {
            _ballX = ScreenWidth / 2;
            _ballY = ScreenHeight / 2;
            _ballDirectionX = -_ballDirectionX;
        }

        // Displays the game over message
        private static void DrawGameOver()
        {
            Console.Clear();
            Console.SetCursorPosition(ScreenWidth / 2 - 10, ScreenHeight / 2);
            string winner = _playerOneScore >= 5 ? "Player 1" : "Player 2";
            Console.WriteLine($"{winner} wins!");
            Console.SetCursorPosition(ScreenWidth / 2 - 12, ScreenHeight / 2 + 1);
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}