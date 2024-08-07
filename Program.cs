using System;

namespace PLATAFORMAS
{
    public class Program
    {
        static void Main()
        {
            ScreensOfTheGame screens = new();
            GamePlayScreen menu = new();

            menu.LaunchMenu(menu, screens);
        }
    }
}