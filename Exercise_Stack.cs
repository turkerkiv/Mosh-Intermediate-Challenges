using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ConsoleApp3
{
    public class Stack
    {
        private readonly List<object> _list = new List<object>();

        //private int i;

        public void Push(object obj)
        {
            if (obj is null)
                throw new InvalidOperationException("Object cannot be null");

            _list.Add(obj);

            //i = _list.Count;
        }

        public object Pop()
        {
            if (_list.Count == 0)
                throw new InvalidOperationException("Stack is empty");

            int index = _list.Count - 1;
            object lastObj = _list[index];
            _list.RemoveAt(index);
            return lastObj;

            /*
            this section for if there is weird need for more pop method than push method. 
            if (i == 0)
                i = _list.Count;

            object lastObj = _list[i - 1];
            i--;
            return lastObj;
            */
        }
        public void Clear()
        {
            _list.Clear();

            //i = 0;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var stackExample = new Stack();

            stackExample.Push("First clicked link");
            stackExample.Push(2); //boxing will happen
            stackExample.Push("3.");
            stackExample.Push(4); //boxing will happen
            stackExample.Push("Last clicked link");

            Console.WriteLine(stackExample.Pop());
            Console.WriteLine(stackExample.Pop());
            Console.WriteLine(stackExample.Pop());
            Console.WriteLine(stackExample.Pop());
            Console.WriteLine(stackExample.Pop());
        }
    }
}
