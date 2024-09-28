namespace Observer;

class Program
{
    static void Main(string[] args)
    {
        Alarm alarm = new Alarm();
        alarm.Subscribe(new PoliceStation());
        alarm.Subscribe(new FireStation());
        alarm.Subscribe(new HospitalStation());

        alarm.Notify();
    }

    public class Alarm : IObservable<int>, IDisposable
    {
        private readonly List<IObserver<int>> _watchers = new List<IObserver<int>>();

        public IDisposable Subscribe(IObserver<int> observer)
        {
            _watchers.Add(observer);
            return this;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
        private int i = 0;

        public void Notify()
        {
            if (i > 3)
            {
                foreach (var w in _watchers)
                {
                    w.OnCompleted();
                }
            }

            foreach (var w in _watchers)
            {
                w.OnNext(i++);
            }
        }
    }

    public class PoliceStation : IObserver<int>
    {
        public void Alert()
        {
            Console.WriteLine($"{typeof(PoliceStation)} has alerted");
        }

        public void OnCompleted()
        {
            Console.WriteLine($"{typeof(PoliceStation)} completed");
        }

        public void OnError(Exception error)
        {
            Console.WriteLine($"{typeof(PoliceStation)} error");
        }

        public void OnNext(int value)
        {
            Console.WriteLine($"{typeof(PoliceStation)} has next {value}");
        }
    }

    public class FireStation : IObserver<int>
    {
        public void Alert()
        {
            Console.WriteLine($"{typeof(FireStation)} has alerted");
        }

        public void OnCompleted()
        {
            Console.WriteLine($"{typeof(FireStation)} completed");
        }

        public void OnError(Exception error)
        {
            Console.WriteLine($"{typeof(FireStation)} error");
        }

        public void OnNext(int value)
        {
            Console.WriteLine($"{typeof(FireStation)} next {value}");
        }
    }

    public class HospitalStation : IObserver<int>
    {
        public void Alert()
        {
            Console.WriteLine($"{typeof(HospitalStation)} has alerted");
        }

        public void OnCompleted()
        {
            Console.WriteLine($"{typeof(HospitalStation)} completed");
        }

        public void OnError(Exception error)
        {
            Console.WriteLine($"{typeof(HospitalStation)} error");
        }

        public void OnNext(int value)
        {
            Console.WriteLine($"{typeof(HospitalStation)} next {value}");
        }
    }
}