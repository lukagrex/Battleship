using System.Collections.Generic;

namespace Vsite.BattleShip.Model
{
    public class LimitedQueue<T> : Queue<T>
    {
        private readonly int length;

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
    }
}
