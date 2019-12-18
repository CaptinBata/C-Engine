using System;
using System.Collections.Generic;
using System.Text;
using IEngine;
using IEngine.Classes;
using SFML.Graphics;
using SFML.System;
using Utils;

namespace Colour_Lines.Classes
{
    public class Game : GameBase
    {
        public Game()
        {

        }

        public override void SetUpGame(WindowBase renderWindow)
        {
            var direction = new Vector2f(Util.GetRandomFromRange(-1, 1), Util.GetRandomFromRange(-1, 1));

            _gameObjects.Add(new Player(new Vector2f(renderWindow.GetWidth() / 2, renderWindow.GetHeight() / 2), new Vector2f(renderWindow.GetWidth(), renderWindow.GetHeight()), direction));
            _gameObjects.Add(new Player(new Vector2f(renderWindow.GetWidth() / 2, renderWindow.GetHeight() / 2), new Vector2f(renderWindow.GetWidth(), renderWindow.GetHeight()), -direction));
            _gameObjects.Add(new Player(new Vector2f(renderWindow.GetWidth() / 2, renderWindow.GetHeight() / 2), new Vector2f(renderWindow.GetWidth(), renderWindow.GetHeight()), new Vector2f(-direction.X, direction.Y)));
            _gameObjects.Add(new Player(new Vector2f(renderWindow.GetWidth() / 2, renderWindow.GetHeight() / 2), new Vector2f(renderWindow.GetWidth(), renderWindow.GetHeight()), new Vector2f(direction.X, -direction.Y)));
        }

        public override List<SFMLObjectBase> GetGameObjects()
        {
            return _gameObjects;
        }

        public override void UpdateGameLogic()
        {

        }

        public override void Update()
        {
            UpdateGameLogic();
            UpdateObjectLogic();
        }

        public override void Draw(WindowBase window)
        {
            var renderWindow = window.GetRenderWindow();
            foreach (var gameObject in _gameObjects)
            {
                gameObject.Draw(renderWindow);
            }
        }
    }
}
