using System;
using System.Collections.Generic;

namespace PLATAFORMAS
{
    public class Indicators
    {
        public Scores PlayerScores { get; set; }
        public Lifes PlayerLifes { get; set; }
        public StageNumber PlayerStage { get; set; }
        public Indicators()
        {
            PlayerScores = new Scores();
            PlayerLifes = new Lifes();
            PlayerStage = new StageNumber();
        }
        public void ResetIndicators()
        {
            PlayerScores.ResetScore();
            PlayerLifes.ResetLifes();
            PlayerStage.ResetStage();
        }
        public class Scores
        {
            public int PlayerScore {  get; set; }
            public int LastScore { get; set; }
            public List<int> ScoreTable { get; set; }
            public Scores()
            {
                PlayerScore = 0;
                LastScore = 0;
                ScoreTable = new List<int> { 0, 0, 0 };
            }
            public void AddPoints(int points)
            {
                PlayerScore += points;
                LastScore = PlayerScore;
            }
            public void SustractPoints(int points)
            {
                PlayerScore -= points;
                LastScore = PlayerScore;
            }
            public void PrintScore()
            {
                ClearScoreLine();
                Console.SetCursorPosition(5, 5);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"Score: {PlayerScore}");
                Console.ResetColor();
            }
            public void ClearScoreLine()       //nos asegura que se reescriben bien los puntos en las coordenadas.
            {
                Console.SetCursorPosition(5, 5);
                Console.Write(new string(' ', Console.WindowWidth));
            }
            public void WriteScoresAtTable()
            {
                if (LastScore > 0 && !ScoreTable.Contains(LastScore))
                {
                    ScoreTable.Add(PlayerScore);
                }
                
                ScoreTable.Sort((a, b) => b.CompareTo(a));

                if (ScoreTable.Count > 3)
                {
                    ScoreTable.RemoveAt(3);
                }
            }
            public void PrintScoresTable()
            {
                Console.SetCursorPosition(44, 5);
                Console.WriteLine("----LATEST SCORES----");

                bool lastScorePrinted = false;

                for (int i = 0; i < ScoreTable.Count; i++)
                {
                    Console.SetCursorPosition(47, 10 + i * 2); // Ajusta la posición vertical para cada línea
                    if (ScoreTable[i] == LastScore && LastScore > 0 && !lastScorePrinted)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"Score {i + 1}: {ScoreTable[i]} (LAST)");
                        lastScorePrinted = true;
                    }
                    else
                    {
                        Console.ResetColor();
                        Console.WriteLine($"Score {i + 1}: {ScoreTable[i]}");
                    }
                    
                }
                Console.SetCursorPosition(34, 20);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("[Press any key to return to the Main Menu]");
                Console.ResetColor();
            }
            public void ResetScore()
            {
                PlayerScore = 0;
            }
        }
        public class Lifes
        {
            public int PlayerLifes { get; set; }
            public Lifes()
            {
                PlayerLifes = 3;
            }
            public void AddLife()
            {
                PlayerLifes++;
            }
            public void LoseLife()
            {
                PlayerLifes --;
            }
            public void PrintLifes()
            {
                ClearLifesLine();
                Console.SetCursorPosition(5, 6);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"Lifes: {PlayerLifes}");
                Console.ResetColor();
            }
            public void ClearLifesLine()
            {
                Console.SetCursorPosition(5, 6);
                Console.Write(new string(' ', Console.WindowWidth));
            }
            public void ResetLifes()
            {
                PlayerLifes = 3;
            }
        }
        public class StageNumber
        {
            public int PlayerStage { get; set; }
            public StageNumber()
            {
                PlayerStage = 1;
            }
            public void NextStage()
            {
                PlayerStage++;
            }
            public void PrintStageNumber()
            {
                Console.SetCursorPosition(5, 7);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"Stage: {PlayerStage}");
                Console.ResetColor();
            }
            public void ClearStageLine()
            {
                Console.SetCursorPosition(5, 7);
                Console.Write(new string(' ', Console.WindowWidth));
            }
            public void ResetStage()
            {
                PlayerStage = 1;
            }
        }
        // mostrará el mensaje que sea necesario y lo borrará cuando prosiga el juego
        public void DisplayMessageWithPosition(int x, int y, string message, ConsoleColor color, bool clearAfterDelay = false, int delaMillisecods = 1000)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(new string(' ', Console.WindowWidth - x));
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ResetColor();

            if (clearAfterDelay)
            {
                System.Threading.Thread.Sleep(delaMillisecods);
                ClearLineAtPosition (x, y);
            }
        }
        public static void ClearLineAtPosition(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(new string(' ', Console.WindowWidth - x));
        }
        public void CountDown()
        {
            int x = 8;
            int y = 13;

            string[] countdownNumbers = { "3", "2", "1", "GO!" };

            foreach (var number in countdownNumbers)
            {
                for (int dots = 1; dots <= 5; dots++)  // Aumentar los puntos suspensivos hasta 5
                {
                    string message = number + new string('.', dots);

                    DisplayMessageWithPosition(x, y, message, ConsoleColor.DarkYellow, true, 100);  // Cambiar el delay a 300ms para una visualización más fluida
                }
            }
        } 
    }
}









