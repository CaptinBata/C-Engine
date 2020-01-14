using IEngine.Classes;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.Classes
{
    public class ColourObject : SFMLObjectBase
    {
        private Shape shape = null;
        private Color Colour;
        private Vector2f Position;

        public ColourObject(Shape newShape)
        {
            shape = newShape;
        }

        public ColourObject(Shape newShape, Color newColour, Vector2f newPosition)
        {
            shape = newShape;
            Colour = newColour;
            Position = newPosition;

            shape.FillColor = Colour;
            shape.Position = Position;
        }

        public Vector2f GetPosition()
        {
            return Position;
        }

        public Color GetColour()
        {
            return Colour;
        }

        public void SetPosition(Vector2f newPosition)
        {
            Position = newPosition;
            if (shape != null)
                shape.Position = Position;
        }

        public void SetColour(Color newColour)
        {
            Colour = newColour;
            if (shape != null)
                shape.FillColor = newColour;
        }

        public override void Draw(RenderWindow window)
        {
            window.Draw(shape);
        }

        public override void Update()
        {

        }
    }
}
