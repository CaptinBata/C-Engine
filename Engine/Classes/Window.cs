using System;
using System.Collections.Generic;
using System.Text;
using IEngine;
using IEngine.Classes;
using SFML.Window;
using SFML.Graphics;

namespace Engine.Classes
{
    public class Window : WindowBase
    {
        public Window(InputBase input)
        {
            _inputHandler = input;
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
            foreach (var shape in _gameObjects)
                shape.Draw(_sfmlWindow);
        }

        void UpdateAllObjects()
        {
            foreach (var sfmlObject in _gameObjects)
                sfmlObject.Update();
        }

        public override void RunWindow()
        {
            while (_sfmlWindow.IsOpen)
            {
                _sfmlWindow.DispatchEvents();

                _sfmlWindow.Clear();

                UpdateAllObjects();

                DrawAllObjects();

                _sfmlWindow.Display();

                _inputHandler.ClearKeyBuffer();
            }
        }

        public override void CloseWindow(object sender, EventArgs e)
        {
            _sfmlWindow.Close();
        }

        public override void AddNewObjectToRender(SFMLObjectBase gameObject)
        {
            _gameObjects.Add(gameObject);
        }
    }
}
