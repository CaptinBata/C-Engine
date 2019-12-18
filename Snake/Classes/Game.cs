using System;
using System.Collections.Generic;
using IEngine.Classes;
using SFML.Graphics;
using SFML.System;

namespace Snake.Classes
{
    public class Game : GameBase
    {
        Snake _player;

        Color[,] _colors = new Color[100, 100];

        public Game()
        {

        }

        public override void SetUpGame(WindowBase renderWindow)
        {
            GenerateColours(renderWindow);

            for (int x = 0; x < renderWindow.GetWidth(); x++)
            {
                for (int y = 0; y < renderWindow.GetHeight(); y++)
                {
                    var shape = new ColourObject();
                    shape.shape = new CircleShape(1, 30);
                    shape.shape.Position = new Vector2f(x, y);
                    shape.shape.FillColor = _colors[x, y];
                    _gameObjects.Add(shape);
                }
            }
        }

        public override void AddEngineReference(EngineBase engine)
        {
            _engine = engine;
            _inputHandler = engine.GetInputHandler();
        }

        void GenerateColours(WindowBase renderWindow)
        {
            _colors = new Color[renderWindow.GetWidth(), renderWindow.GetHeight()];
            var colourScale = Math.Pow(256, 3) / (renderWindow.GetWidth() * renderWindow.GetHeight());
            byte R = 0, G = 0, B = 0, GL = G, RL = R;

            for (int x = 0; x < renderWindow.GetWidth(); x++)
            {
                for (int y = 0; y < renderWindow.GetHeight(); y++)
                {
                    B += Convert.ToByte(colourScale);
                    if (B >= 255 - Convert.ToByte(colourScale))
                    {
                        GL = G;
                        G++;
                    }

                    if (G == 0 && GL == 255)
                    {
                        R++;
                        GL = G;
                    }
                    _colors[x, y] = new Color(R, G, B);
                }
            }
        }

        public override void Draw(WindowBase window)
        {
            var renderWindow = window.GetRenderWindow();
            foreach (var gameObject in _gameObjects)
            {
                gameObject.Draw(renderWindow);
            }
        }

        public override void UpdateGameLogic()
        {

        }
        public override void Update()
        {
            UpdateGameLogic();
            UpdateObjectLogic();
        }
    }
}
