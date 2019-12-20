using System;
using System.Collections.Generic;
using IEngine.Classes;
using SFML.Graphics;
using SFML.System;
using System.Linq;

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
        }

        public override void AddEngineReference(EngineBase engine)
        {
            _engine = engine;
            _inputHandler = engine.GetInputHandler();
        }

        byte ColourLerp(byte current, byte target)
        {
            var rate = 0.5;
            return (byte)((target - current) * rate + current);
        }

        void GenerateColours(WindowBase renderWindow)
        {
            var colorArray = new List<Color>();
            var colours = new Color[7] { new Color(255, 0, 0), new Color(255, 127, 0), new Color(255, 255, 0), new Color(0, 255, 0), new Color(0, 0, 255), new Color(46, 43, 95), new Color(139, 0, 255) };
            var posScale = (int)(renderWindow.GetWidth() / colours.Length);

            for (int iCount = 0; iCount < colours.Length; iCount++)
            {
                var shape = new ColourObject
                {
                    shape = new CircleShape(5, 30)
                };
                shape.shape.Position = new Vector2f(iCount * posScale, renderWindow.GetHeight() / 2);
                shape.shape.FillColor = colours[iCount];
                _gameObjects.Add(shape);
            }

            for (int iCount = 0; iCount < _gameObjects.Count; iCount++)
            {
                var shapeBefore = (ColourObject)(_gameObjects.ElementAt(iCount));
                var shapeAfter = iCount != 6 ? (ColourObject)(_gameObjects.ElementAt(iCount + 1)) : (ColourObject)(_gameObjects.ElementAt(0));
                var colour = new Color(ColourLerp(shapeBefore.shape.FillColor.R, shapeAfter.shape.FillColor.R),
                                                    ColourLerp(shapeBefore.shape.FillColor.G, shapeAfter.shape.FillColor.G),
                                                    ColourLerp(shapeBefore.shape.FillColor.B, shapeAfter.shape.FillColor.B));
                colorArray.Add(colour);
            }

            for (int iCount = 0; iCount < colorArray.Count; iCount++)
            {
                var shape = new ColourObject();
                shape.shape = new CircleShape(10, 30);
                shape.shape.Position = new Vector2f((iCount * posScale) - (posScale / 2), renderWindow.GetHeight() / 2);
                shape.shape.FillColor = colorArray.ElementAt(iCount);
                _gameObjects.Add(shape);
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
