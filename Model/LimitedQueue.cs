using System.Collections.Generic;

namespace Vsite.Battleship.Model
{
    public class LimitedQueue<T> : Queue<T>
    {
        public LimitedQueue(int length)
        {
            this.length = length;
        }

        public new void Enqueue(T item)
        {
            if (Count >= length)
                Dequeue();
            base.Enqueue(item);
        }

        private readonly int length;
    }
}