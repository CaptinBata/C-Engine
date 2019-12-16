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
        Player _player1, _player2, _player3, _player4;

        public Game()
        {

        }

        public override List<SFMLObjectBase> SetUpGame(WindowBase renderWindow)
        {
            var objects = new List<SFMLObjectBase>();

            var direction = new Vector2f(Util.GetRandomFromRange(-1, 1), Util.GetRandomFromRange(-1, 1));
            _player1 = new Player(new Vector2f(renderWindow.GetWidth() / 2, renderWindow.GetHeight() / 2), new Vector2f(renderWindow.GetWidth(), renderWindow.GetHeight()), direction);
            _player2 = new Player(new Vector2f(renderWindow.GetWidth() / 2, renderWindow.GetHeight() / 2), new Vector2f(renderWindow.GetWidth(), renderWindow.GetHeight()), -direction);
            _player3 = new Player(new Vector2f(renderWindow.GetWidth() / 2, renderWindow.GetHeight() / 2), new Vector2f(renderWindow.GetWidth(), renderWindow.GetHeight()), new Vector2f(-direction.X, direction.Y));
            _player4 = new Player(new Vector2f(renderWindow.GetWidth() / 2, renderWindow.GetHeight() / 2), new Vector2f(renderWindow.GetWidth(), renderWindow.GetHeight()), new Vector2f(direction.X, -direction.Y));

            objects.Add(_player1);
            objects.Add(_player2);
            objects.Add(_player3);
            objects.Add(_player4);

            return objects;
        }
    }
}
