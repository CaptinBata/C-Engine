using System;
using System.Collections.Generic;
using System.Text;
using IEngine.Classes;
using SFML.Graphics;
using SFML.System;

namespace Snake.Classes
{
    enum Directions
    {
        Left,
        Right,
        Up,
        Down
    }

    class Snake : SFMLObjectBase
    {
        int _size = 5, _xPos = 80, _yPos = 40;
        float _headSize = 5f;
        float _bodySize = 3.5f;
        Directions _currentDirection = Directions.Right;

        List<SFMLObjectBase> _snake = new List<SFMLObjectBase>();

        public override void Draw(RenderWindow window)
        {
            foreach (var colourObject in _snake)
                colourObject.Draw(window);
        }

        public float GetHeadSize()
        {
            return _headSize;
        }

        public float GetBodySize()
        {
            return _bodySize;
        }

        public void IncrementSize()
        {
            _size++;
        }

        public int GetSize()
        {
            return _size;
        }

        public void AddToSnake(ref GridNode node)
        {
            if (node.SizeCounter > 0)
            {
                node.SizeCounter--;
                _snake.Add(new ColourObject(new CircleShape(_bodySize, 30), node.Colour, node.Position));
            }
            if (node.XPos == _xPos && node.YPos == _yPos)
            {
                node.SizeCounter = _size;
                _snake.Add(new ColourObject(new CircleShape(_headSize, 30), node.Colour, node.Position));
            }
        }

        public List<SFMLObjectBase> GetSnake()
        {
            return _snake;
        }

        public void ClearSnake()
        {
            _snake.Clear();
        }

        public void ChangeDirection(Directions newDirection)
        {
            _currentDirection = newDirection;
        }

        public override void Update()
        {
            switch (_currentDirection)
            {
                case Directions.Right:
                    _xPos += 1;
                    if (_xPos > 159)
                        _xPos = 0;
                    break;
                case Directions.Left:
                    _xPos -= 1;
                    if (_xPos < 0)
                        _xPos = 159;
                    break;
                case Directions.Up:
                    _yPos -= 1;
                    if (_yPos < 0)
                        _yPos = 79;
                    break;
                case Directions.Down:
                    _yPos += 1;
                    if (_yPos > 79)
                        _yPos = 0;
                    break;
            }
        }
    }
}
