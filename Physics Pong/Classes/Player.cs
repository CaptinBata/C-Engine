using System.Collections.Generic;
using IEngine.Classes;
using SFML.Graphics;
using SFML.System;
using Utils;
using System.Linq;


namespace Colour_Lines.Classes
{
    struct Colours
    {
        public byte R;
        public byte G;
        public byte B;
        public bool RU;
        public bool GU;
        public bool BU;

        public Colours(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
            RU = true;
            GU = false;
            BU = true;
        }
    }

    class Player : SFMLObjectBase
    {
        List<Shape> _shapes = new List<Shape>();
        Vector2f _position;
        Vector2f _direction;
        Colours _colour = new Colours(0, 0, 0);
        float speed = 7.5f;
        int _killAmount = 10000;

        public Player(Vector2f position, Vector2f windowSize, Vector2f direction)
        {
            _shapes.Add(new CircleShape(1, 30));
            _shapes.Last().Position = position;
            _position = position;
            _windowSize = windowSize;
            _direction = direction;
            _direction *= speed;
        }

        public override void Draw(RenderWindow window)
        {
            foreach (var shape in _shapes)
            {
                window.Draw(shape);
            }
        }

        void CheckComponent(ref byte value, ref bool check)
        {
            if (check)
            {
                value += (byte)Util.Rand.Next(1, 10);
                if (value == 255)
                    check = !check;
            }
            else
            {
                value -= (byte)Util.Rand.Next(1, 10);
                if (value == 0)
                    check = !check;
            }
        }

        Color GetNextColour()
        {
            CheckComponent(ref _colour.B, ref _colour.BU);
            CheckComponent(ref _colour.G, ref _colour.GU);
            CheckComponent(ref _colour.R, ref _colour.RU);

            return new Color(_colour.R, _colour.G, _colour.B);
        }

        public override void Update()
        {
            _position += _direction;

            _shapes.Add(new CircleShape(1, 30));
            _shapes.Last().Position = _position;
            _shapes.Last().FillColor = GetNextColour();

            if (_position.X < 0 || _position.X > _windowSize.X)
                _direction = new Vector2f(-_direction.X, _direction.Y);
            if (_position.Y < 0 || _position.Y > _windowSize.Y)
                _direction = new Vector2f(_direction.X, -_direction.Y);

            if (_shapes.Count > _killAmount)
                _shapes.RemoveAt(0);
        }
    }
}
