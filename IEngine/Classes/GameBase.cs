using System;
using System.Collections.Generic;
using System.Text;
using IEngine.Interfaces;

namespace IEngine.Classes
{
    public class GameBase : IGame
    {
        protected InputBase _inputHandler;
        protected EngineBase _engine;
        protected List<SFMLObjectBase> _gameObjects = new List<SFMLObjectBase>();

        public virtual void AddEngineReference(EngineBase engine)
        {
            throw new NotImplementedException();
        }

        public virtual List<SFMLObjectBase> GetGameObjects()
        {
            throw new NotImplementedException();
        }

        public virtual void Update()
        {
            throw new NotImplementedException();
        }

        public virtual void Draw(WindowBase renderWindow)
        {
            throw new NotImplementedException();
        }

        public virtual void UpdateGameLogic()
        {
            throw new NotImplementedException();
        }

        public virtual void UpdateObjectLogic()
        {
            foreach (var gameObject in _gameObjects)
                gameObject.Update();
        }

        public virtual void SetUpGame(WindowBase renderWindow)
        {
            throw new NotImplementedException();
        }
    }
}
