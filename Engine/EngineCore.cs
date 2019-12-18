using IEngine.Classes;
using Engine.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace Engine
{
    public class EngineCore : EngineBase
    {

        static ConcurrentDictionary<int, IEnumerator> _coroutines = new ConcurrentDictionary<int, IEnumerator>();
        int coroutineCounter = 0;

        public EngineCore()
        {
            _inputHandler = new Input();
            _runningWindow = new Window(_inputHandler, this);
        }

        public override void RunEngine()
        {
            _runningWindow.RunWindow();
        }

        public override void StartCoroutine(IEnumerator coroutine)
        {
            _coroutines.TryAdd(coroutineCounter, coroutine);
            coroutineCounter++;
        }

        public override WindowBase GetWindow()
        {
            return _runningWindow;
        }

        public override void IterateCoroutine()
        {
            foreach (var iter in _coroutines)
            {
                if (!iter.Value.MoveNext())
                {
                    _coroutines.TryRemove(iter.Key, out var value);
                    coroutineCounter--;
                }
            }
        }
    }
}
