using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;

namespace IEngine.Interfaces
{
    public interface ISFMLObject
    {
        void Update();

        void Draw(RenderWindow window);
    }
}
