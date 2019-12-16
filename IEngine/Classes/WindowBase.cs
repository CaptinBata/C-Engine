using System;
using System.Collections.Generic;
using System.Text;
using IEngine.Interfaces;
using SFML.Graphics;

namespace IEngine.Classes
{
    public class WindowBase : IWindow
    {
        protected RenderWindow _sfmlWindow;
        protected InputBase _inputHandler;
        protected List<SFMLObjectBase> _gameObjects = new List<SFMLObjectBase>();

        public virtual void AddNewObjectToRender(SFMLObjectBase shape)
        {
            throw new NotImplementedException();
        }

        public virtual void CloseWindow(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public virtual uint GetHeight()
        {
            throw new NotImplementedException();
        }

        public virtual uint GetWidth()
        {
            throw new NotImplementedException();
        }

        public virtual void RunWindow()
        {
            throw new NotImplementedException();
        }
    }
}
