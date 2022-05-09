using System.Collections.Generic;

namespace Model
{
    internal class LoopIndex
    {
        private readonly int outerBound;
        private readonly int innerBound;

        public LoopIndex(int outerBound, int innerBound)
        {
            this.outerBound = outerBound;
            this.innerBound = innerBound;
        }

        public IEnumerable<int> Outer()
        {
            for (int i = 0; i < this.outerBound; i++)
            {
                yield return i;
            }
        }

        public IEnumerable<int> Inner()
        {
            for (int i = 0; i < this.innerBound; i++)
            {
                yield return i;
            }
        }

    }
}