using System;
using System.Collections.Generic;
using System.Text;
using SFML.Window;

namespace IEngine.Interfaces
{
    public interface IInput
    {
        bool GetKey(Keyboard.Key key);
        void KeyPressed(Keyboard.Key key);
        void ClearKeyBuffer();
    }
}
