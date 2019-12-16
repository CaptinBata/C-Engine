using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IEngine.Classes
{
    public class EngineBase
    {
        protected GameBase _runningGame;
        protected WindowBase _runningWindow;
        protected InputBase _inputHandler;
        public virtual void RunEngine()
        {
            throw new NotImplementedException();
        }

        public virtual void StartCoroutine(IEnumerator coroutine)
        {
            throw new NotImplementedException();
        }

        public virtual void IterateCoroutine()
        {
            throw new NotImplementedException();
        }
    }
}
