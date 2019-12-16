using IEngine.Classes;
using Engine.Classes;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Engine
{
    public class EngineCore : EngineBase
    {

        static List<IEnumerator> _coroutines = new List<IEnumerator>();

        public EngineCore(GameBase game)
        {
            _inputHandler = new Input();
            _runningWindow = new Window(_inputHandler, this);
            _runningGame = game;
        }

        public override void RunEngine()
        {
            var objects = _runningGame.SetUpGame(_runningWindow);

            foreach (var item in objects)
            {
                _runningWindow.AddNewObjectToRender(item);
            }

            _runningWindow.RunWindow();
        }

        public override void StartCoroutine(IEnumerator coroutine)
        {
            _coroutines.Add(coroutine);
        }

        public override void IterateCoroutine()
        {
            foreach (var iter in _coroutines)
            {
                if (!iter.MoveNext())
                    _coroutines.Remove(iter);
            }
        }
    }
}
