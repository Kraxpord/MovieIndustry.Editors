using Common.ConsoleIO;
using System;

namespace Common.ConsoleUI
{
    public class SimpleCommandController
    {
        protected MenuItem[] _menuItems;
        protected Action _prepareScreen;
        protected Action _prepareRunning;

        public SimpleCommandController(MenuItem[] menuItems, Action prepareScreen, Action prepareRunning = null)
        {
            _menuItems = menuItems;
            _prepareScreen = prepareScreen;
            _prepareRunning = prepareRunning;
        }

        public void Run()
        {
            _prepareRunning?.Invoke();

            while (true)
            {
                _prepareScreen();
                MenuItem menuItem = SelectMenuItem();
                if (menuItem.Operation == null)
                {
                    return;
                }
                try
                {
                    menuItem.Operation();
                    if (menuItem.Stopping)
                    {
                        StopToView();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    StopToView();
                }
            }
        }

        private MenuItem SelectMenuItem()
        {
            Console.WriteLine("\n Список команд меню:");
            for (int i = 0; i < _menuItems.Length; i++)
            {
                Console.WriteLine("\t{0,2} - {1}", i, _menuItems[i].CommandName);
            }
            int number = Inputting.InputInt32("\n Введіть номер команди меню", 0, _menuItems.Length - 1);
            return _menuItems[number];
        }

        public static void StopToView()
        {
            Console.Write("\n\tДля продовження натисніть довільну клавішу...");
            Console.ReadKey(true);
        }
    }
}