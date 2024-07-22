using System;
using System.Collections.Generic;

namespace PLATAFORMAS {
    public class Level
    {
        public List<string> Layout { get; set; }
        public List<Level> Levels { get; set; }
        public int CurrentLevelIndex { get; set; }
        public Level(List<string> layout)
        {
            Layout = layout;
        }
        public void DrawLevel()
        {
            Console.Clear();

            for (int i = 0; i < Layout.Count; i++)
            {
                Console.SetCursorPosition(28, i + 17);
                Console.WriteLine(Layout[i]);
            }
        }
        public Level()
        {
            Levels = new List<Level>
            {
                
                new Level(new List<string>
                {
                    "__________  ________________  _____________________  ________", //1
                }),
                new Level(new List<string>
                {
                    "__________   _________   _________   _________   ____________", //2
                }),
                new Level (new List<string>
                {
                    "__________  ____  ____   _________  ____   ____  _______   __", //3
                }),
                new Level(new List<string>
                {
                    "                 ________________________                    ",
                    "_______ ______                             ____   _____      ", //4
                    "                   ________   ____  ______  _______   ____ __",
                }),
                new Level(new List<string>
                {
                    "                _____                     _____              ",
                    "          ____          ____        ____                     ", //5
                    "________                      ____               ____  ______",
                }),
                new Level (new List<string>
                {
                    "                                _______   ____   ____   _____",
                    "_____                      ____                              ",  //6
                    "       _____         ____       ____                         ",
                    "              _____                    ____   ____   ____   _",
                }),
                new Level(new List<string>
                {
                    "_____   ____                                 ____   ____  ___",
                    "               _____   ____   ____   _____                   ",   //7
                    "            ____   ____   _____   ____    ____   ____  _____ ",
                }),
                new Level(new List<string>
                {
                    "               ____              ____                       _",
                    "        ____              ____          ____         ____    ",    //8
                    "_____              ____                        ____          ",
                }),
                new Level(new List<string>
                {
                    "_____                                                     ___",
                    "        _____                                      ____      ",
                    "                ____                        ____             ",    //9
                    "                       ____          ____                    ",
                    "                              ____                           ",
                }),
                new Level(new List<string>
                {
                    "                                                         ____",
                    "                                                             ",    //10
                    "_____   ____   ____   ____   ____   ____   ____   _____      ",
                }),
            };
            CurrentLevelIndex = 0;
        }
        public void RestartLevels()
        {
            CurrentLevelIndex = 0;
        }
        public bool IsOnPlatform(int x, int y)
        {
            int relativeX = x - 28;
            int relativeY = y - 17;

            if (relativeY >= 0 && relativeY < Layout.Count && relativeX >= 0 && relativeX < Layout[relativeY].Length)
            {
                return Layout[relativeY][relativeX] == '_';
            }
            return false;
        }
        
    }
}
        
    

    
    
