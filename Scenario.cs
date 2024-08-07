using PLATAFORMAS;
using System;
using System.Collections.Generic;

namespace PLATAFORMAS
{
    public class Level
    {
        public static List<Level> Levels { get; private set; } = new List<Level>();
        public List<string> Layout { get; private set; }
        public (int X, int Y) InitialPlayerPosition { get; private set; }
        public static int CurrentLevelIndex { get; private set; }

        public Level(List<string> layout, (int X, int Y) initialPlayerPosition)
        {
            Layout = layout;
            InitialPlayerPosition = initialPlayerPosition;
        }
        public void DrawLevel()
        {
            Console.Clear();

            int offsetX = 10;
            int offsetY = 17;


            for (int i = 0; i < Layout.Count; i++)
            {
                Console.SetCursorPosition(offsetX, i + offsetY);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine(Layout[i]);
                Console.ResetColor();
            }
        }
        

        public (int, int) GetInitialPlayerPosition()
        {
            return InitialPlayerPosition;
        }
        public static void InitializeLevels()
        {
            Levels = new List<Level>
            {
                new (new List<string>
                    {
                        "                                                                                         <|",
                        "                                                                                          |",
                        "______________  __________________  _________________  _________________  ________________|"  //L1 x90p 

                    }, (10, 19)),
                new (new List<string>
                    {
                        "                                                                                         <|",
                        "                                                                                          |",
                        "______________  __________________  __________________  ________________   _______________|" //2

                    }, (10, 19)),
                new (new List<string>
                    {
                        "                                                                                         <|",
                        "                                                                                          |",
                        "_________________________   _______________   _______________   __________________________|" //3
                    },(10, 19)),
                new (new List<string>
                    {
                        "                                                                                         <|",
                        "                                                                                          |",
                        "_________________________   _____________   __   _____________   _________________________|" //4   
                },(10, 19)),
                new (new List<string>
                    {
                        "                                                                                         <|",
                        "                _______________________   _____________________________                   |", //5
                        "______________                                                           _________________|"
                    },(10, 19)),
                new (new List<string>
                    {
                        "                                  ____   ___   ____                                      <|",
                        "                    _________  ____               ____  _______________                   |", //6
                        "__________________                                                       _________________|"
                },(10, 19)),
                new (new List<string>
                    {
                        "_____________                                 ____   ____  ___  __  __  _  _             <|",
                        "               _____   ____   ____   _____                                                |",   //7
                        "            ____   ____   _____   ____    ____   ____  _____  ________   __________   ____|"
                    },(10, 17)),
                new (new List<string>
                    {
                        "____                                          __                                           ",
                        "     ___                                ____      ____                                   <|",
                        "          ___                     ____                  ____                              |",    //8
                        "               _________   _____                              _____   ____   _____________|"
                    },(10, 17)),
                new (new List<string>
                    {
                        "______                                                ___                                <|",
                        "        _____                                   ____       __                             |",
                        "                ____                      ____                 __              __  __  ___|",    //9
                        "                       ____         ____                           __      __              ",
                        "                              ____                                     __                  "
                },(10, 17)),
                new (new List<string>
                    {
                        "__                                __                                        ______         ",
                        "                               __    __                                 ___                ",
                        "                            __          __                ___  ___  ___                  <|",    //10
                        "                       ____               ____       ____                                 |",
                        "     ____   ____   ___                          ____                                    __|"
                    }, (10, 17))
            };
            CurrentLevelIndex = 0;
        }
        public void DebugInitialPlayerPosition()        //método de testing
        {
            var (x, y) = GetInitialPlayerPosition();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(0, 1); 
            Console.WriteLine($"DEBUG: Initial Player Position for Level {CurrentLevelIndex}: X = {x}, Y = {y}");
            Console.ResetColor();
        }
        public void RestartLevels()
        {
            CurrentLevelIndex = 0;
        }
        public bool IsOnPlatform(int x, int y)
        {
            int offsetX = 11;   // hacemos coincidir el offset con el ajuste de plataforma hueco. Funciona con IsOnGround() en Character
            int offsetY = 17;
            int relativeX = x - offsetX;
            int relativeY = y - offsetY;

            if (relativeY >= 0 && relativeY < Layout.Count && relativeX >= 0 && relativeX < Layout[relativeY].Length)
            {
                return Layout[relativeY][relativeX] == '_';
            }
            return false;
        }
    }
}
        
        
    
