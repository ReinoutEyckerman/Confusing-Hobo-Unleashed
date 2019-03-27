using System.Collections.Generic;

namespace Confusing_Hobo_Unleashed.Tools
{
    public class CircularList<T>:List<T>
    {
        private int index =0;

        public int getIndex()
        {
            return index;
        }
        
        public void increment()
        {
            index = 1 + index % this.Count;
        }

        public void decrement()
        {
            index = 1 - index % this.Count;
        }
        
        public void increment(int amount)
        {
            amount = amount % this.Count;
            index = amount + index % this.Count;
        }

        public void decrement(int amount)
        {
            amount = amount % this.Count;
            index = amount - index % this.Count;
        }

        public T currentItem()
        {
            return this[index];
        }

        public T nextItem()
        {
            increment();
            return currentItem();
        }
        
        public T previousItem()
        {
            decrement();
            return currentItem();
        }
    }
}