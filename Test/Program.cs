namespace Test;

class Program
{
    static void Main(string[] args)
    {
        Composite root = new Composite("root");
        root.Add(new Leaf("Leaf A"));
        root.Add(new Leaf("Leaf B"));

        Composite comp = new Composite("Composite X");
        comp.Add(new Leaf("Leaf XA"));
        comp.Add(new Leaf("Leaf XB"));
        
        root.Add(comp);
        root.Add(new Leaf("Leaf C"));
        Leaf leaf = new Leaf("Leaf D");
        root.Add(leaf);
        root.Remove(leaf);

        root.Display(1);
        Console.ReadKey();
    }
    
    public interface Icomponent
    {
        void Display(int depth);
    }
    
    public class Leaf:Icomponent
    {
        private String name = string.Empty;
        public Leaf(string name)
        {
            this.name = name;
        }

        public void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + ' ' + name);
        }
    }
    
    public class Composite:Icomponent
    {
        private List<Icomponent> _children = new List<Icomponent>();
        private String name = String.Empty;

        public Composite(String sname)
        {
            this.name = sname;
        }

        public void Add(Icomponent component)
        {
            _children.Add(component);
        }

        public void Remove(Icomponent component)
        {
            _children.Remove(component);
        }
        
        public void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + ' ' + name);
            foreach (Icomponent component in _children)
            {
                component.Display(depth + 2);
            }

        }
    }
}