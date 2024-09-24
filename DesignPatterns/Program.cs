using System;
using System.Collections;
using System.Collections.Generic;

namespace RefactoringGuru.DesignPatterns.Strategy.Conceptual
{
    abstract class SortStrategy
    {
        public abstract void Sort(ArrayList list);
    }

    class QuickSort : SortStrategy
    {
        public override void Sort(ArrayList list)
        {
            // الگوریتم مربوطه
            Console.WriteLine("This is Quick Sort");
        }
    }

    class ShellSort : SortStrategy
    {
        public override void Sort(ArrayList list)
        {
            // الگوریتم مربوطه
            Console.WriteLine("This is Shell Sort");
        }
    }

    class MergeSort : SortStrategy
    {
        public override void Sort(ArrayList list)
        {
            // الگوریتم مربوطه
            Console.WriteLine("This is Merge Sort");
        }
    }

    class SortedListContext
    {
        private ArrayList list = new ArrayList();
        private SortStrategy sortstrategy;

        public void SetSortStrategy(SortStrategy sortstrategy)
        {
            this.sortstrategy = sortstrategy;
        }
        public void Add(string name)
        {
            list.Add(name);
        }
        public void Sort()
        {
            sortstrategy.Sort(list);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var context = new SortedListContext();

            context.SetSortStrategy(new QuickSort());
            context.Sort();

            context.SetSortStrategy(new MergeSort());
            context.Sort();
        }
    }
}