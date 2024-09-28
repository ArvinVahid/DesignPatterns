namespace Test;

class Program
{
    static void Main(string[] args)
    {
        ModelDuck modelDuck = new ModelDuck(new FlyNoWay(), new MuteQuack());
        modelDuck.PerformFly();
        modelDuck.PerformQuack();
        modelDuck.SetFlyBehavior(new FlyWithWings());
        modelDuck.PerformFly();
    }
    
    #region Duck

    public abstract class Duck
    {
        protected IFlyBehavior _fly;
        protected IQuackBehavior _quack;
        protected Duck(IFlyBehavior fly, IQuackBehavior quack)
        {
            _fly = fly;
            _quack = quack;
        }
        public abstract void Display();
        public void Swim()
        {
            Console.WriteLine("All ducks swim even decoy!");
        }

        public void SetFlyBehavior(IFlyBehavior flyBehavior)
        {
            _fly = flyBehavior;
        }
        public void PerformFly()
        {
            _fly.Fly();
        }

        public void SetQuackBehavior(IQuackBehavior quackBehavior)
        {
            _quack = quackBehavior;
        }
        public void PerformQuack()
        {
            _quack.Quack();
        }
    }

    
    public class ModelDuck : Duck
    {
        /*public ModelDuck()
        {
            _fly = new FlyNoWay();
            _quack = new NormalQuack();
        }*/
        
        public override void Display()
        {
            Console.WriteLine("i'm model duck");
        }

        public ModelDuck(IFlyBehavior fly, IQuackBehavior quack) : base(fly, quack)
        {
        }
    }

    /*public class MallardDuck : Duck
    {
        public MallardDuck()
        {
            _quack = new NormalQuack();
            _fly = new FlyWithWings();
        }
        public override void Display()
        {
            Console.WriteLine("I'm the real mallard duck!");
        }
    }
    public class RedHeadDuck : Duck
    {
        public override void Display()
        {
            throw new NotImplementedException();
        }
    }

    public class RubberDuck : Duck
    {
        public override void Display()
        {
            throw new NotImplementedException();
        }
    }

    public class DecoyDuck : Duck
    {
        public override void Display()
        {
            throw new NotImplementedException();
        }
    }*/

    #endregion

    #region Fly Behavior

    public interface IFlyBehavior
    {
        void Fly();
    }
    
    public class FlyWithWings : IFlyBehavior
    {
        public void Fly()
        {
            Console.WriteLine("Flying with wings");
        }
    }
    
    public class FlyNoWay : IFlyBehavior
    {
        public void Fly()
        {
            Console.WriteLine("Do nothing - can't fly");
        }
    }

    #endregion

    #region Quack Behavior

    public interface IQuackBehavior
    {
        void Quack();
    }
    
    public class NormalQuack : IQuackBehavior
    {
        public void Quack()
        {
            Console.WriteLine("Normal quack");
        }
    }
    
    public class Squack : IQuackBehavior
    {
        public void Quack()
        {
            Console.WriteLine("SQuack");
        }
    }
    
    public class MuteQuack : IQuackBehavior
    {
        public void Quack()
        {
            Console.WriteLine("No Sound");
        }
    }

    #endregion

    
}