using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Mvc
{
    public interface ITimer
    {
        int Delay { get; set; }
        void Start();
        void Stop();

        event EventHandler Tick;
    }
    public class Timer : IDisposable, ITimer
    {
        Thread _thread;
        public void Dispose() { this.Stop(); }
        public void Stop()
        {
            _thread.Abort();
        }
        public void Start()
        {
            _thread.Start();
        }

        public Timer(int interval)
        {
            this.Delay = interval;
            var ts = new ThreadStart(() =>
            {
                while (true)
                {
                    Thread.Sleep(interval);
                    Tick?.Invoke(this, null);
                }
            });

            _thread = new Thread(ts);
        }

        protected virtual void CallEvent(Action<int> e, int value)
        {
            e.Invoke(value);
        }

        public event EventHandler Tick;
        public int Delay { get; set; }
    }

    public class SystemClock : IDisposable
    {
        protected virtual ITimer CreateTimer()
        {
            return new Timer(100);
        }
        public event Action<int> Milliseconds;
        public event Action<int> Seconds;
        public event Action<int> Minutes;
        public event Action<int> Hours;
        public event Action<int> Days;

        public SystemClock()
        {
            int ticks = 0, secs = 0, mins = 0, hours = 0, days = 0;
            var timer = this.CreateTimer();
            var interval = timer.Delay;

            timer.Tick += delegate {
                ticks += interval;

                Milliseconds?.Invoke(ticks);
                if (ticks >= 1000)
                {
                    ++secs; ticks = 0;
                    Seconds?.Invoke(secs);

                    if (secs == 60)
                    {
                        ++mins; secs = 0;
                        Minutes?.Invoke(mins);

                        if (mins == 60)
                        {
                            ++hours; mins = 0;
                            Hours?.Invoke(hours);

                            if (hours == 24)
                            {
                                ++days; hours = 0;
                                Days?.Invoke(days);
                            }
                        }
                    }
                }
            };
            timer.Start();
        }
        public void Dispose()
        {

        }
    }
}
