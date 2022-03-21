using System.Collections.Generic;

namespace Vsite.Battleship.Model
{
    public class LimitedQueue<T> : Queue<T>
    {
        public LimitedQueue(int length)
        {
            Length = length;
        }

        public new void Enqueue(T item)
        {
            if (Count >= Length)
            {
                Dequeue();
            }
            base.Enqueue(item);
        }

        private readonly int Length;
    }
}
