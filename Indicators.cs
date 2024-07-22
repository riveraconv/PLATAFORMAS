using System;
using System.Collections.Generic;

namespace PLATAFORMAS
{
    public class Indicators
    {
        //propiedades de cada uno de los indicadores
        public Scores PlayerScores { get; set; }
        public Lifes PlayerLifes { get; set; }
        public StageNumber PlayerStage { get; set; }


        //constructor que inicializa los indicadores
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
                Console.SetCursorPosition(5, 5);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"Score: {PlayerScore}");
                Console.ResetColor();
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
            public void LoseLife()
            {
                PlayerLifes --;
            }
            public void PrintLifes()
            {
                Console.SetCursorPosition(5, 6);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"Lifes: {PlayerLifes}");
                Console.ResetColor();
            }
            public void LosingALifeMessage()
            {
                Console.SetCursorPosition(46, 5);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("You fell!! A life was lost!");
                Console.ResetColor();
            }
            public void LosingALifeMessageAndPoints()
            {
                Console.SetCursorPosition(46, 5);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("You fell!! A life was lost!");
                Console.SetCursorPosition(49, 8);
                Console.WriteLine("10 points were lost!");
                Console.ResetColor();
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
            }
            public void StageClearMessage()
            {
                Console.SetCursorPosition(35, 5);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Stage Clear! Well done! Entering to the next stage..");
                Console.SetCursorPosition(55, 8);
                Console.Write("GET READY!");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.ResetColor();
            }
            public void ResetStage()
            {
                PlayerStage = 1;
            }
        }
        
        
    }
}









