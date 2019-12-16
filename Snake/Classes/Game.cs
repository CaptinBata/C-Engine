using System;
using System.Collections.Generic;
using IEngine.Classes;
using SFML.Graphics;
using SFML.System;

namespace Snake.Classes
{
    public class Game : GameBase
    {
        Snake _player;

        Color[,] _colors = new Color[100, 100];

        public override void AddEngineReference(EngineBase engine)
        {
            _engine = engine;
        }

        void GenerateColours(WindowBase renderWindow)
        {
            _colors = new Color[renderWindow.GetWidth(), renderWindow.GetHeight()];
            var colourScale = Math.Pow(256, 3) / (renderWindow.GetWidth() * renderWindow.GetHeight());
            byte R = 0, G = 0, B = 0, GL = G, RL = R;

            for (int x = 0; x < renderWindow.GetWidth(); x++)
            {
                for (int y = 0; y < renderWindow.GetHeight(); y++)
                {
                    B += Convert.ToByte(colourScale);
                    if (B >= 255 - Convert.ToByte(colourScale))
                    {
                        GL = G;
                        G++;
                    }

                    if (G == 0 && GL == 255)
                    {
                        R++;
                        GL = G;
                    }
                    _colors[x, y] = new Color(R, G, B);
                }
            }
        }

        public override List<SFMLObjectBase> SetUpGame(WindowBase renderWindow)
        {
            _engine.StartCoroutine(CountNumbers());

            var objects = new List<SFMLObjectBase>();
            GenerateColours(renderWindow);

            for (int x = 0; x < renderWindow.GetWidth(); x++)
            {
                for (int y = 0; y < renderWindow.GetHeight(); y++)
                {
                    var shape = new ColourObject();
                    shape.shape = new CircleShape(1, 30);
                    shape.shape.Position = new Vector2f(x, y);
                    shape.shape.FillColor = _colors[x, y];
                    objects.Add(shape);
                }
            }
            return objects;
        }

        IEnumerator<CoroutineEnumerator> CountNumbers()
        {
            var counter = 0;
            while (true)
            {
                counter++;
                Console.WriteLine(counter);
                yield return null;
            }
        }
    }
}
