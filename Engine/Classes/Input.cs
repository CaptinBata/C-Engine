using System;
using System.Collections.Generic;
using System.Text;
using IEngine.Classes;
using SFML.Window;

namespace Engine.Classes
{
    public class Input : InputBase
    {
        public override void ClearKeyBuffer()
        {
            keys.Clear();
        }

        public override bool GetKey(Keyboard.Key key)
        {
            return keys.Contains(key) ? true : false;
        }

        public override void KeyPressed(Keyboard.Key key)
        {
            keys.Add(key);
        }
    }
}
