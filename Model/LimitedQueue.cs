using System.Collections.Generic;

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
            if (this.Count >= this.length)
            {
                this.Dequeue();
            }

            base.Enqueue(item);
        }
    }
}
