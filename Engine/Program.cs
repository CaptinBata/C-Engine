using IEngine.Classes;
using Engine.Classes;
using System;
using Snake.Classes;

namespace Engine
{
    class Program
    {
        static GameBase _runningGame;
        static WindowBase _runningWindow;
        static InputBase _inputHandler;
        static void Main(string[] args)
        {
            _inputHandler = new Input();
            _runningWindow = new Window(_inputHandler);
            _runningGame = new Game();
            var objects = _runningGame.SetUpGame(_runningWindow);

            foreach (var item in objects)
            {
                _runningWindow.AddNewObjectToRender(item);
            }

            _runningWindow.RunWindow();

        }
    }
}
