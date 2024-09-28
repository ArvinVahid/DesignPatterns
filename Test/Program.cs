namespace Test;

class Program
{
    static void Main(string[] args)
    {
        SortStrategy s = new SortStrategy(new MergeSort());
    }

    public class SortStrategy
    {
        private readonly ISort _sort;
        public SortStrategy(ISort sort)
        {
            _sort = sort;
        }

        public void Sort()
        {
            _sort.Sort();
        }
    }
    
    #region Sort Encapsulate

    public interface ISort
    {
        void Sort();
    }
    
    public class QuickSort : ISort
    {
        public void Sort()
        {
            Console.WriteLine("Quick");
        }
    }
    
    public class MergeSort : ISort
    {
        public void Sort()
        {
            Console.WriteLine("Merge");
        }
    }

    #endregion
}