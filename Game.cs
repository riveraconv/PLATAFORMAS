using System;
using System.Collections.Generic;

namespace PLATAFORMAS
{
    public class GamePlayScreen
    {
        public bool Exit { get; set; } = false;
        public Indicators indicators;
        public int currentLevelIndex;
        public Level currentLevel;
        public GamePlayScreen()
        {
            indicators = new Indicators();
            Level.InitializeLevels();
            currentLevelIndex = 0;
            currentLevel = Level.Levels[currentLevelIndex];
        }
        public void LaunchMenu(GamePlayScreen menu, ScreensOfTheGame screens)
        {
            screens.WelcomeScreen.ShowStartScreen(indicators);
            
            while (!Exit)
            {
                Console.CursorVisible = false;

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                Console.WriteLine();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                        RestartGame();
                        Console.Clear();
                        LaunchNewGame(menu, screens, indicators);
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        screens.GameScoresScreen.ShowScores(indicators.PlayerScores);
                        break;
                    case ConsoleKey.D3:
                        Console.Clear();
                        screens.GameInstructionsScreen.ShowInstructions(indicators);
                        break;
                    case ConsoleKey.D4:
                        Exit = true;
                        Console.Clear();
                        screens.EndGameScreen.ShowEndScreen(indicators);
                        break;

                    default:
                        Console.Clear();
                        screens.DefaultMenuAdvertisement.ShowDefaultMenuMessage(indicators);
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                        break;
                }
                if (!Exit)
                {
                    screens.WelcomeScreen.ShowStartScreen(indicators);
                }
            }
        }
        public void RestartGame()
        {
            indicators.ResetIndicators();
            currentLevelIndex = 0;
            currentLevel = Level.Levels[currentLevelIndex];
        }
        public void LaunchNewGame(GamePlayScreen menu, ScreensOfTheGame screens, Indicators indicators)
        {
            indicators.DisplayMessageWithPosition(41, 5, "Starting a NEW GAME! GET READY!", ConsoleColor.Cyan, true, 3000);

            Console.CursorVisible = false;
            bool gameRunning = true;

            currentLevel = Level.Levels[currentLevelIndex];
            
            //var initialPosition
            //Character player blabla
            

            int speed = 1;
            int gravity = 1;
            int initialJumpVelocity = 1;

            currentLevel.DrawLevel();
            indicators.PlayerScores.PrintScore();
            indicators.PlayerLifes.PrintLifes();
            indicators.PlayerStage.PrintStageNumber();

            var initialPosition = currentLevel.GetInitialPlayerPosition();
            
            Character player = new(initialPosition.Item1, initialPosition.Item2);
            player.DrawPlayer();

            indicators.CountDown();

            while (gameRunning && currentLevelIndex < Level.Levels.Count)
            {
                if (indicators.PlayerLifes.PlayerLifes <= 0)
                {
                    gameRunning = false;
                    break;
                }
                player.MoveRight(speed, currentLevel);
                player.ApplyGravity(gravity, currentLevel);

                if (!player.IsFalling && Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                    if (keyInfo.Key == ConsoleKey.Escape)
                    {
                        RestartGame();
                        gameRunning = false;
                    }
                    else if (keyInfo.Key == ConsoleKey.UpArrow && player.CanJump && player.IsOnGround(currentLevel))
                    {
                        player.Jump(initialJumpVelocity, currentLevel);
                    }
                }
                if (player.PositionX >= currentLevel.Layout[0].Length + 10) // comparamos la posicion con el tamaño de la plataforma y sumamos el margen
                {
                    indicators.PlayerScores.AddPoints(20);
                    indicators.DisplayMessageWithPosition(40, 7, "Well done! Entering to the next stage!", ConsoleColor.Cyan, true, 2000);
                    indicators.PlayerLifes.AddLife();
                    indicators.DisplayMessageWithPosition(45, 7, "A life was gained for pass!", ConsoleColor.Green, true, 1500);
                    indicators.PlayerStage.NextStage();
                    
                    currentLevelIndex++;

                    if (currentLevelIndex >= Level.Levels.Count)
                    {
                        Console.Clear();
                        screens.GameFinishedScreen.ShowFinalScreen(indicators);
                        System.Threading.Thread.Sleep(1500);
                        EndGameSequence(screens);
                        ClearInputBuffer();
                        gameRunning = false;
                        
                    }
                    else
                    {
                        currentLevel = Level.Levels[currentLevelIndex];
                        currentLevel.DrawLevel();
                        initialPosition = currentLevel.GetInitialPlayerPosition();
                        player.ResetPosition(initialPosition.Item1, initialPosition.Item2, currentLevel);
                        ClearInputBuffer();
                        System.Threading.Thread.Sleep(1000);
                        player.DrawPlayer();
                        indicators.CountDown();
                    }
                }
                if (player.PositionY >= 24)
                {
                    HandlePlayerFall(player, currentLevel, gameRunning);
                }
                indicators.PlayerScores.PrintScore();
                indicators.PlayerLifes.PrintLifes();
                indicators.PlayerStage.PrintStageNumber();
                System.Threading.Thread.Sleep(70);
            }
            EndGameSequence(screens);
        }
        private void HandlePlayerFall(Character player, Level currentLevel, bool gameRunning)
        {
            if(indicators.PlayerLifes.PlayerLifes > 0)
            {
                indicators.PlayerLifes.LoseLife();

                if (indicators.PlayerScores.PlayerScore > 0) // se restan puntos por caer si quedan puntos
                {
                    indicators.DisplayMessageWithPosition(45, 7, "You fell! A life was lost!", ConsoleColor.Red, true, 1500);
                    indicators.DisplayMessageWithPosition(48, 7,"10 points were lost!", ConsoleColor.Red, true, 1500);
                    indicators.PlayerScores.SustractPoints(10);
                    indicators.PlayerScores.PrintScore();
                    indicators.PlayerLifes.PrintLifes();
                    indicators.PlayerStage.PrintStageNumber();
                    System.Threading.Thread.Sleep(500);
                }
                else
                {
                    indicators.DisplayMessageWithPosition(45, 5,"You fell! A life was lost!", ConsoleColor.Red, true, 1500);
                    indicators.PlayerScores.PrintScore();
                    indicators.PlayerLifes.PrintLifes();
                    indicators.PlayerStage.PrintStageNumber();
                    System.Threading.Thread.Sleep(500);
                }

                if (indicators.PlayerLifes.PlayerLifes == 0)
                {
                    indicators.PlayerLifes.PlayerLifes = 0;
                    indicators.PlayerScores.WriteScoresAtTable();
                    ClearInputBuffer();
                    player.UndrawPlayer(currentLevel);
                    gameRunning = false;
                }
                else
                {   
                    var initialPosition = currentLevel.GetInitialPlayerPosition();
                    player.ResetPosition(initialPosition.Item1, initialPosition.Item2, currentLevel);
                    indicators.CountDown();
                    ClearInputBuffer();
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }
        private void EndGameSequence(ScreensOfTheGame screens)
        {
            Console.Clear();
            screens.EndGameScreen.ShowEndScreen(indicators);
            System.Threading.Thread.Sleep(3500);
            Console.Clear();
            indicators.PlayerScores.WriteScoresAtTable();
            screens.GameScoresScreen.ShowScores(indicators.PlayerScores);
            ClearInputBuffer();
            Console.Clear();
        }
        private static void ClearInputBuffer()
        {
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }
        }
    }
}