namespace ObserverPattern
{
    internal class Program
    {
        public interface IObserver
        {
            void Update(string message);
        }

        public interface ISubject
        {
            void Attach(IObserver observer);
            void Detach(IObserver observer);
            void Notify(string message);
        }

        public class Subject : ISubject
        {
            private List<IObserver> _observers = new List<IObserver>();

            public void Notify(string message)
            {
                foreach (var observer in _observers)
                {
                    observer.Update(message);
                }
            }

            public void Attach(IObserver observer)
            {
                _observers.Add(observer);
            }

            public void Detach(IObserver observer)
            {
                _observers.Remove(observer);
            }

            public void ChangeState(string message)
            {
                Console.WriteLine($"Subject change state : {message}");
                Notify(message);
            }
        }

        public class ConcreteObserver : IObserver
        {
            private string _name;
            public ConcreteObserver(string name)
            {
                _name = name;
            }

            public void Update(string message)
            {
                Console.WriteLine($"{_name} recieved update: {message}");
            }
        }

        static void Main(string[] args)
        {
            Subject subject = new Subject();

            ConcreteObserver observer1 = new ConcreteObserver("Observer1");
            ConcreteObserver observer2 = new ConcreteObserver("Observer2");

            subject.Attach(observer1);
            subject.Attach(observer2);

            subject.ChangeState("State 1");

            subject.Detach(observer1);

            subject.ChangeState("State 2");
        }
    }
}