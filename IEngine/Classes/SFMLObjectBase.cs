using System;
using System.Collections.Generic;
using System.Text;
using IEngine.Interfaces;
using SFML.Graphics;
using SFML.System;

namespace IEngine.Classes
{
    public class SFMLObjectBase : ISFMLObject
    {
        protected Vector2f _windowSize;

        public virtual void Draw(RenderWindow window)
        {
            throw new NotImplementedException();
        }

        public virtual void Update()
        {
            throw new NotImplementedException();
        }
    }
}
