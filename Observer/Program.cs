namespace Observer;

class Program
{
    static void Main(string[] args)
    {
        IWatcher police = new PoliceStation();
        IWatcher fire = new FireStation();
        IWatcher hosp = new HospitalStation();

        Alarm alarm = new Alarm();
        alarm.AddTo(police);
        alarm.AddTo(fire);
        alarm.AddTo(hosp);
        
        alarm.Notify();
    }

    public class Alarm
    {
        private readonly List<IWatcher> _watcher = new List<IWatcher>();

        public void AddTo(IWatcher watcher)
        {
            _watcher.Add(watcher);
        }

        public void Notify()
        {
            foreach (var w in _watcher)
            {
                w.Alert();
            }
        }
    }

    public interface IWatcher
    {
        void Alert();
    }
    
    public class PoliceStation : IWatcher
    {
        public void Alert()
        {
            Console.WriteLine($"{typeof(PoliceStation)} has alerted");
        }
    }

    public class FireStation : IWatcher
    {
        public void Alert()
        {
            Console.WriteLine($"{typeof(FireStation)} has alerted");
        }
    }

    public class HospitalStation : IWatcher
    {
        public void Alert()
        {
            Console.WriteLine($"{typeof(HospitalStation)} has alerted");
        }
    }
}