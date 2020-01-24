using System;
using System.Collections.Generic;
using IEngine.Classes;
using SFML.Graphics;
using SFML.System;
using System.Linq;

namespace Snake.Classes
{
    struct GridNode
    {
        public Vector2f Position;
        public Color Colour;
        public int SizeCounter;
        public int XPos;
        public int YPos;

        public GridNode(Vector2f newPosition, Color newColour, int newXPos, int newYPos)
        {
            Colour = newColour;
            Position = newPosition;
            SizeCounter = 0;
            XPos = newXPos;
            YPos = newYPos;
        }
    }

    public class Game : GameBase
    {
        Snake _player = new Snake();

        Random rand = new Random();
        int _counterMax, _counter;
        List<List<GridNode>> _map = new List<List<GridNode>>();

        public Game()
        {

        }

        public override void SetUpGame(WindowBase renderWindow)
        {
            GenerateMap(renderWindow);
        }

        public override void AddEngineReference(EngineBase engine)
        {
            _engine = engine;
            _inputHandler = engine.GetInputHandler();
        }

        Color MakeNewColour()
        {
            var R = rand.Next(0, 255);
            var G = rand.Next(0, 255);
            var B = rand.Next(0, 255);
            return new Color(Convert.ToByte(R), Convert.ToByte(G), Convert.ToByte(B));
        }

        void GenerateMap(WindowBase window)
        {
            var xScale = 10;
            var yScale = 10;

            for (int xCount = 0; xCount < window.GetRenderWindow().Size.X / xScale; xCount++)
            {
                var temp = new List<GridNode>();
                for (int yCount = 0; yCount < window.GetRenderWindow().Size.Y / yScale; yCount++)
                {
                    var newPos = new Vector2f((xCount * xScale), (yCount * yScale));
                    var newColour = MakeNewColour();
                    var node = new GridNode(newPos, newColour, xCount, yCount);
                    temp.Add(node);
                }
                _map.Add(temp);
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

        void ProcessInput()
        {
            if (_inputHandler.GetKey(SFML.Window.Keyboard.Key.W))
                _player.ChangeDirection(Directions.Up);
            if (_inputHandler.GetKey(SFML.Window.Keyboard.Key.A))
                _player.ChangeDirection(Directions.Left);
            if (_inputHandler.GetKey(SFML.Window.Keyboard.Key.S))
                _player.ChangeDirection(Directions.Down);
            if (_inputHandler.GetKey(SFML.Window.Keyboard.Key.D))
                _player.ChangeDirection(Directions.Right);
        }

        public override void UpdateGameLogic()
        {
            _gameObjects.Clear();
            _player.ClearSnake();
            ProcessInput();

            for (int xCount = 0; xCount < _map.Count; xCount++)
            {
                for (int yCount = 0; yCount < _map.ElementAt(xCount).Count; yCount++)
                {
                    GridNode Node = _map.ElementAt(xCount).ElementAt(yCount);
                    _player.AddToSnake(ref Node);
                    _map[xCount][yCount] = Node;
                }
            }
            _gameObjects.AddRange(_player.GetSnake());
            _player.Update();
        }
        public override void Update()
        {
            UpdateGameLogic();
            UpdateObjectLogic();
        }
    }
}
