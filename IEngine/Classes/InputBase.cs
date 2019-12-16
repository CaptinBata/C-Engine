using System;
using System.Collections.Generic;
using System.Text;
using IEngine.Interfaces;
using SFML.Window;

namespace IEngine.Classes
{
    public class InputBase : IInput
    {
        protected List<Keyboard.Key> keys = new List<Keyboard.Key>();

        public virtual void ClearKeyBuffer()
        {
            throw new NotImplementedException();
        }

        public virtual bool GetKey(Keyboard.Key key)
        {
            throw new NotImplementedException();
        }

        public virtual void KeyPressed(Keyboard.Key key)
        {
            throw new NotImplementedException();
        }
    }
}
