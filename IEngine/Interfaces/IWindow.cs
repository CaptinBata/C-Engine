using System;
using System.Collections.Generic;
using System.Text;
using IEngine.Classes;

namespace IEngine.Interfaces
{
    public interface IWindow
    {
        void CloseWindow(object sender, EventArgs e);
        uint GetWidth();
        uint GetHeight();
        void RunWindow();

        void AssignGame(GameBase game);
    }
}
