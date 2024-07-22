using System;

namespace PLATAFORMAS
{
    //clase que maneja las diferentes pantallas del juego
    public class ScreensOfTheGame
    {
        //propiedades de cada una de las pantallas
        public StartScreen WelcomeScreen { get; set; }
        public EndScreen EndGameScreen { get; set; }
        public ScoreScreen GameScoresScreen { get; set; }
        public FinalScreen GameFinishedScreen { get; set; } 
        public InstructionsScreen GameInstructionsScreen { get; set; }


        //constructor que inicializa las pantallas
        public ScreensOfTheGame()
        {
            WelcomeScreen = new StartScreen();
            EndGameScreen = new EndScreen();
            GameScoresScreen = new ScoreScreen();
            GameFinishedScreen = new FinalScreen();
            GameInstructionsScreen = new InstructionsScreen();
        }

        //clase que representa la pantalla de bienvenida, da las 3 opciones, empezar, ver puntuaciones, salir.
        public class StartScreen
        {
            public void ShowStartScreen()
            {
                Console.SetCursorPosition(40, 5);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("¡¡¡¡WELCOME TO THE PLATFORMS GAME!!!!");
                Console.ResetColor();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.SetCursorPosition(42, 10);
                Console.WriteLine("-- Press 1 to start a NEW GAME --");
                Console.SetCursorPosition(42, 12);
                Console.WriteLine("-- Press 2 to show GAME SCORES --");
                Console.SetCursorPosition(42, 14);
                Console.WriteLine("-- Press 3 to show INSTRUCTIONS --");
                Console.SetCursorPosition(42, 16);
                Console.WriteLine("-- Press 4 TO EXIT of the game --");
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

        //clase que representa la pantalla de fin del juego

        public class EndScreen
        {
            public void ShowEndScreen()
            {
                Console.SetCursorPosition(46, 5);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("----GAME OVER----");
                Console.SetCursorPosition(36, 15);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Thank you for playing my PLATFORM GAME...");
                Console.ResetColor();
            }
            
        }
        public class FinalScreen
        {
            public void ShowFinalScreen()
            {
                Console.SetCursorPosition(46, 5);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("----WELL DONE! YOU HAVE COMPLETE ALL THE LEVELS----");
                Console.SetCursorPosition(50, 8);
                Console.WriteLine("CONGRATULAIONS!!");
                Console.ResetColor();
                Console.SetCursorPosition(36, 15);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Thank you for playing my PLATFORM GAME...");
                Console.ResetColor();
            }
        }
        public class InstructionsScreen
        {
            public void ShowInstructions()
            {
                Console.Clear();
                Console.SetCursorPosition(40, 5);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("----INSTRUCTIONS OF THE GAME----");
                Console.SetCursorPosition(43, 8);
                Console.WriteLine("Welcome to the platforms game.");
                Console.SetCursorPosition(21, 11);
                Console.Write("Controls: - Use UP ARROW for jump. Press ESCAPE to exit of the game at any moment.");
                Console.SetCursorPosition(21, 14);
                Console.WriteLine("Tips:     - Don't press the up key too quickly, this is a console simulated game.");
                Console.SetCursorPosition(30, 15);
                Console.WriteLine("   If you do that, the console gets saturated.");
                Console.SetCursorPosition(28, 17);
                Console.WriteLine("   - The max jump distance is 4 ASCII characters.");
                Console.SetCursorPosition(28, 19);
                Console.WriteLine("   - You have a few tenths of a second of reaction time from the jump-point.");

                Console.SetCursorPosition(36, 24);
                Console.ForegroundColor= ConsoleColor.Blue;
                Console.WriteLine("[Press any key to return to the Main Menu]");
                Console.ResetColor();
                Console.ReadKey();
                Console.Clear();

            }
        }
    }     
}



