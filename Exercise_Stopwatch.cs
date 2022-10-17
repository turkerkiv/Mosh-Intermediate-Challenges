using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp1
{
    public class Stopwatch
    {
        private DateTime _startPoint;
        private DateTime _stopPoint;
        private TimeSpan _duration;
        private bool _isRunning;

        public TimeSpan Duration
        {
            get { return _duration; }
        }

        public void Start()
        {
            if (_isRunning == true)
            {
                throw new InvalidOperationException("First stop the Stopwatch");
            }
            else
            {
                _startPoint = DateTime.Now;
                _isRunning = true;
            }
        }

        public void Stop()
        {
            if (_isRunning != true)
            {
                throw new InvalidOperationException("First start the Stopwatch");
            }
            else
            {
                _stopPoint = DateTime.Now;
                _duration = _stopPoint - _startPoint;
                _isRunning = false;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
                Stopwatch stopwatch1 = new Stopwatch();

                Console.WriteLine("Press enter to start Stopwatch");
                Console.ReadLine();
                stopwatch1.Start();

                Console.WriteLine("Press enter to stop Stopwatch");
                Console.ReadLine();
                stopwatch1.Stop();

                TimeSpan duration = stopwatch1.Duration;
                Console.WriteLine(duration);
        }
    }
}

