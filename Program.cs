using System;

namespace PLATAFORMAS
{
    public class Program
    {
        static void Main()
        {
            
            ScreensOfTheGame screens = new();
            GamePlayScreen menu = new();
            

            menu.LaunchMenu(menu, screens);    //se llama al menú del juego

        }
    }
}