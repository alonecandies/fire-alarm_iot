using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;

namespace DeviceDemo
{
    class Engine : System.Mvc.Engine
    {
        static Queue<Thread> _watings;
        static Stack<Thread> _running;
        public static void CreateThread(Action exec)
        {
            while (_running.Count > 0 && _running.Peek().IsAlive == false)
            {
                _running.Pop();
            }

            var ts = new ThreadStart(() => exec.Invoke());
            _watings.Enqueue(new Thread(ts));

            LoadThread();
        }

        
        static void LoadThread()
        {
            while (_watings.Count > 0)
            {
                Thread.Sleep(100);

                var t = _watings.Dequeue();
                _running.Push(t);

                t.Start();
            }
        }
        public static void Start()
        {
            var e = new Engine();
            Register(e, null);

            _watings = new Queue<Thread>();
            _running = new Stack<Thread>();

            CreateThread(LoadThread);
        }
        public static void End()
        {
            while (_running.Count > 0)
            {
                _running.Pop().Abort();
            }
        }

        public static void ExitCurrentThread()
        {
        }
    }
}
