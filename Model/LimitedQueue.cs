using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Battleship.Model
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
            if (this.Count < this.length)
            {
                base.Enqueue(item);
            }
            else
            {
                this.Dequeue();
                base.Enqueue(item);
            }
        }
    }
}
