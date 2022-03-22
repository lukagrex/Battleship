using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class LimitedQueue<T> : Queue<T>
    {
        private readonly int length;

        public LimitedQueue(int length)
        {
            this.length = length;
        }

        public void Enqueue(T item)
        {
            if (Count >= length)
            {
                Dequeue();
            }
            base.Enqueue(item);
        }
    }
}
