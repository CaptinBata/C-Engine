using IEngine.Classes;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.Classes
{
    public class ColourObject : SFMLObjectBase
    {
        public CircleShape shape;

        public override void Draw(RenderWindow window)
        {
            window.Draw(shape);
        }

        public override void Update()
        {

        }
    }
}
