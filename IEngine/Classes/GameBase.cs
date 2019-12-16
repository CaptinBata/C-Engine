using System;
using System.Collections.Generic;
using System.Text;
using IEngine.Interfaces;

namespace IEngine.Classes
{
    public class GameBase : IGame
    {
        protected IInput _inputHandler;
        public virtual List<SFMLObjectBase> SetUpGame(WindowBase renderWindow)
        {
            throw new NotImplementedException();
        }
    }
}
