using System;
using Engine;
using IEngine.Classes;
using Colour_Lines;
using Snake;

namespace Application
{
    class Program
    {
        static EngineCore _engine;
        static GameBase _game;
        static void Main(string[] args)
        {
            _game = new Snake.Classes.Game();
            _engine = new EngineCore(_game);
            _game.AddEngineReference(_engine);
            _engine.RunEngine();
        }
    }
}
