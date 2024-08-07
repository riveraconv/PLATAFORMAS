using System;

namespace PLATAFORMAS
{
    public class ScreensOfTheGame
    {
        public StartScreen WelcomeScreen { get; set; }
        public EndScreen EndGameScreen { get; set; }
        public ScoreScreen GameScoresScreen { get; set; }
        public FinalScreen GameFinishedScreen { get; set; } 
        public InstructionsScreen GameInstructionsScreen { get; set; }
        public DefaultMenuOptionScreen DefaultMenuAdvertisement {  get; set; }
        public Indicators Indicators { get; set; }
        public ScreensOfTheGame()
        {
            WelcomeScreen = new StartScreen();
            EndGameScreen = new EndScreen();
            GameScoresScreen = new ScoreScreen();
            GameFinishedScreen = new FinalScreen();
            GameInstructionsScreen = new InstructionsScreen();
            DefaultMenuAdvertisement = new DefaultMenuOptionScreen();
            
        }
        public class StartScreen
        {
            public void ShowStartScreen(Indicators indicators)
            {
                indicators.DisplayMessageWithPosition(40, 5, "¡¡¡¡Welcome to the platforms game!!!!", ConsoleColor.Yellow, false);
                indicators.DisplayMessageWithPosition(42, 10, "-- Press 1 to start a New Game --", ConsoleColor.DarkGreen, false);
                indicators.DisplayMessageWithPosition(42, 12, "-- Press 2 to show Game Scores --", ConsoleColor.DarkGreen, false);
                indicators.DisplayMessageWithPosition(42, 14, "-- Press 3 to show Instructions --", ConsoleColor.DarkGreen, false);
                indicators.DisplayMessageWithPosition(42, 16, "-- Press 4 to Exit of the game --", ConsoleColor.DarkGreen, false);
                Console.ResetColor();
            }
        }
        public class ScoreScreen
        {
            public void ShowScores(Indicators.Scores scores)
            {
                scores.PrintScoresTable();
                Console.ReadKey();
                Console.Clear();
            }
        }
        public class EndScreen
        {
            public void ShowEndScreen(Indicators indicators)
            {
                indicators.DisplayMessageWithPosition(46, 5, "----GAME OVER----", ConsoleColor.Red, false);
                indicators.DisplayMessageWithPosition(36, 15, "Thank you for playing my Platform Game!", ConsoleColor.Cyan, false);
                Console.ResetColor();
            }
        }
        public class FinalScreen
        {
            public void ShowFinalScreen(Indicators indicators)
            {
                indicators.DisplayMessageWithPosition(32, 5, "----WELL DONE!! YOU HAVE COMPLETE ALL THE LEVELS!!----",  ConsoleColor.Yellow, false, 2000);
                indicators.DisplayMessageWithPosition(50, 8, "CONGRATULATIONS!!", ConsoleColor.Yellow, false, 2000);
                indicators.DisplayMessageWithPosition(39, 15, "Thank you for playing my Platform Game!", ConsoleColor.Cyan, false, 2000);
                indicators.DisplayMessageWithPosition(37, 24, "[Press any key to return to the Main Menu]", ConsoleColor.Blue, false);
                Console.ResetColor();
                Console.ReadKey();
                Console.Clear();
            }
        }
        public class InstructionsScreen
        {
            public void ShowInstructions(Indicators indicators)
            {
                indicators.DisplayMessageWithPosition(40, 5, "*----INSTRUCTIONS OF THE GAME----*", ConsoleColor.Yellow, false);
                indicators.DisplayMessageWithPosition(19, 8, "Controls: - Use UP ARROW for jump. Press ESCAPE to exit of the game at any moment.", ConsoleColor.Yellow, false);
                indicators.DisplayMessageWithPosition(19, 11, "Rules:   - You have a few tenths of a second of reaction time from the jump-point.", ConsoleColor.Yellow, false);
                indicators.DisplayMessageWithPosition(19, 13, "         - Each stage you complete, will give you 20 points and a life.", ConsoleColor.Yellow, false);
                indicators.DisplayMessageWithPosition(19, 15, "         - If you fall, you will lose 10 points and one of the remaining lives.", ConsoleColor.Yellow, false);
                indicators.DisplayMessageWithPosition(19, 17, "Tips:    - If you have difficulties passing a level, try different jump point distances.", ConsoleColor.Yellow, false);
                indicators.DisplayMessageWithPosition(36, 24, "[Press any key to return to the Main Menu]", ConsoleColor.Blue, false);
                Console.ResetColor();
                Console.ReadKey();
                Console.Clear();
            }
        }
        public class DefaultMenuOptionScreen
        {
            public void ShowDefaultMenuMessage(Indicators indicators)
            {
                indicators.DisplayMessageWithPosition(40, 5, "¡¡¡¡SELECT A VALID OPTION, PLEASE!!!!", ConsoleColor.Red, false);
                indicators.DisplayMessageWithPosition(42, 10, "-- Press 1 to start a New Game --", ConsoleColor.DarkGreen, false);
                indicators.DisplayMessageWithPosition(42, 12, "-- Press 2 to show Game Scores --", ConsoleColor.DarkGreen, false);
                indicators.DisplayMessageWithPosition(42, 14, "-- Press 3 to show Instructions --", ConsoleColor.DarkGreen, false);
                indicators.DisplayMessageWithPosition(42, 16, "-- Press 4 to Exit of the game --", ConsoleColor.DarkGreen, false);
                Console.ResetColor();
            }
        }
    }     
}



