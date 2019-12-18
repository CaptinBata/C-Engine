using System;
using System.Collections.Generic;
using System.Text;
using IEngine.Classes;

namespace IEngine.Interfaces
{
    public interface IGame
    {
        List<SFMLObjectBase> GetGameObjects();

        void SetUpGame(WindowBase renderWindow);

        void Update();
        void UpdateGameLogic();
        void UpdateObjectLogic();

        void Draw(WindowBase renderWindow);
    }
}
