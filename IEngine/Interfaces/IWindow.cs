using System;
using System.Collections.Generic;
using System.Text;
using IEngine.Classes;

namespace IEngine.Interfaces
{
    public interface IWindow
    {
        void CloseWindow(object sender, EventArgs e);
        void AddNewObjectToRender(SFMLObjectBase shape);
        uint GetWidth();
        uint GetHeight();
        void RunWindow();
    }
}
