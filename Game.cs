using System;
using System.Collections.Generic;

namespace PLATAFORMAS
{
    public class GamePlayScreen
    {
        public bool Exit { get; set; } = false;
        private Indicators indicators;
        private Level level;
        public GamePlayScreen()
        {
            indicators = new Indicators();
            level = new Level();      
        }
        public void LaunchMenu(GamePlayScreen menu, ScreensOfTheGame screens)
        {
            screens.WelcomeScreen.ShowStartScreen();

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
                         LaunchNewGame(menu, screens);
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        screens.GameScoresScreen.ShowScores(indicators.PlayerScores);
                        break;
                    case ConsoleKey.D3:
                        Console.Clear();
                        screens.GameInstructionsScreen.ShowInstructions();
                        break;
                    case ConsoleKey.D4:
                        Exit = true;
                        Console.Clear();
                        screens.EndGameScreen.ShowEndScreen();
                        break;

                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(40, 5);
                        Console.WriteLine("¡¡¡¡SELECT A VALID OPTION, PLEASE!!!!");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.SetCursorPosition(42, 10);
                        Console.WriteLine("-- Press 1 to start a NEW GAME --");
                        Console.SetCursorPosition(42, 12);
                        Console.WriteLine("-- Press 2 to show GAME SCORES --");
                        Console.SetCursorPosition(42, 14);
                        Console.WriteLine("-- Press 3 to show INSTRUCTIONS--");
                        Console.SetCursorPosition(42, 16);
                        Console.WriteLine("-- Press 4 TO EXIT of the game --");
                        Console.ResetColor();

                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                        break;
                }
                if (!Exit)
                {
                    screens.WelcomeScreen.ShowStartScreen();
                }
            }
        }
        public void RestartGame()
        {
            level.RestartLevels();
            indicators.ResetIndicators();
        }
        public void LaunchNewGame(GamePlayScreen menu, ScreensOfTheGame screens)
        {
            Console.Clear();
            Console.SetCursorPosition(41, 5);
            Console.ForegroundColor= ConsoleColor.Cyan;
            Console.WriteLine("Starting a NEW GAME! Get Ready!");
            Console.ResetColor();
            System.Threading.Thread.Sleep(3000);

            Console.CursorVisible = false;

            bool gameRunning = true;

            Character player = new(28, 17);

            int speed = 1;
            int gravity = 1;
            int initialJumpVelocity = 2;


            while (gameRunning && level.CurrentLevelIndex < level.Levels.Count)
            {
                Level currentLevel = level.Levels[level.CurrentLevelIndex];   
                currentLevel.DrawLevel();
                indicators.PlayerScores.PrintScore();
                indicators.PlayerLifes.PrintLifes();
                indicators.PlayerStage.PrintStageNumber();
                player.DrawPlayer();
                player.MoveRight(speed);

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
                        player.Jump(initialJumpVelocity);
                    }
                }

                player.ApplyGravity(gravity, currentLevel);

                // Verificar si la partida termina

                int platformLength = currentLevel.Layout[0].Length;

                if (player.PositionX >= platformLength + 28) // comparamos la posicion con el tamaño de la plataforma
                {
                   
                    indicators.PlayerScores.AddPoints(10); // Añadir puntuación por completar el nivel
                    indicators.PlayerStage.StageClearMessage();
                    indicators.PlayerStage.NextStage(); // Avanzar al siguiente nivel
                    System.Threading.Thread.Sleep(2000);
                    level.CurrentLevelIndex++;

                    if (level.CurrentLevelIndex >= level.Levels.Count)
                    {
                        screens.GameFinishedScreen.ShowFinalScreen();
                        indicators.PlayerScores.WriteScoresAtTable();
                        screens.GameScoresScreen.ShowScores(indicators.PlayerScores);
                        ClearInputBuffer();
                        gameRunning = false;
                    }
                    else
                    {
                        player.ResetPosition(28, 17);
                        ClearInputBuffer();
                        System.Threading.Thread.Sleep(1000);
                    }
                }
                if (player.PositionY >= 24)
                {   
                    indicators.PlayerLifes.LoseLife();

                    if (indicators.PlayerScores.PlayerScore > 0) // se restan puntos por caer al perder una vida y si quedan puntos
                    {
                        indicators.PlayerLifes.LosingALifeMessageAndPoints();
                        indicators.PlayerScores.SustractPoints(10);
                        System.Threading.Thread.Sleep(2000);
                    }
                    else
                    {
                        indicators.PlayerLifes.LosingALifeMessage();
                        System.Threading.Thread.Sleep(2000);
                    }
                    
                    if (indicators.PlayerLifes.PlayerLifes == 0)
                    {
                        indicators.PlayerScores.WriteScoresAtTable();
                        
                        ClearInputBuffer();
                        gameRunning = false;
                    }  
                    else
                    {
                        player.ResetPosition(28, 17);
                        ClearInputBuffer();
                        System.Threading.Thread.Sleep(2000);
                    }
                }

                
                System.Threading.Thread.Sleep(50); // Ajusta el tiempo entre cada frame
            }
        
            
            Console.Clear();
            screens.EndGameScreen.ShowEndScreen();
            System.Threading.Thread.Sleep(3500);
            Console.Clear();
            indicators.PlayerScores.WriteScoresAtTable();
            screens.GameScoresScreen.ShowScores(indicators.PlayerScores);
            ClearInputBuffer();
            Console.Clear();
        }

        private void ClearInputBuffer()
        {
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }
        }
    }
}







    

