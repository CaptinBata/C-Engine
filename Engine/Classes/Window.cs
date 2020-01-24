using System;
using System.Collections.Generic;
using System.Text;
using IEngine;
using IEngine.Classes;
using Engine;
using SFML.Window;
using SFML.Graphics;

namespace Engine.Classes
{
    public class Window : WindowBase
    {
        public Window(InputBase input, EngineBase engine)
        {
            _inputHandler = input;
            _engine = engine;
            _sfmlWindow = new RenderWindow(new VideoMode(1600, 800), "SFML window");
            _sfmlWindow.Closed += CloseWindow;
            _sfmlWindow.KeyPressed += KeyPressed;
        }

        private void KeyPressed(object sender, KeyEventArgs e)
        {
            _inputHandler.KeyPressed(e.Code);
        }

        public override uint GetWidth()
        {
            return _sfmlWindow.Size.X;
        }

        public override uint GetHeight()
        {
            return _sfmlWindow.Size.Y;
        }

        void DrawAllObjects()
        {
            _game.Draw(this);
        }

        void UpdateAllObjects()
        {
            _game.Update();
        }

        void WaitForTick(double tick)
        {
            DateTime start = DateTime.Now;
            DateTime target = start.AddSeconds(tick);
            while (DateTime.Now < target)
            { }
        }

        public override void RunWindow()
        {
            double tick = 1.0 / _engine.GetFrameRate();
            while (_sfmlWindow.IsOpen)
            {
                WaitForTick(tick);
                _sfmlWindow.DispatchEvents();

                _sfmlWindow.Clear();

                UpdateAllObjects();

                _engine.IterateCoroutine();

                DrawAllObjects();

                _sfmlWindow.Display();

                _inputHandler.ClearKeyBuffer();
            }
        }

        public override void CloseWindow(object sender, EventArgs e)
        {
            _sfmlWindow.Close();
        }
    }
}
