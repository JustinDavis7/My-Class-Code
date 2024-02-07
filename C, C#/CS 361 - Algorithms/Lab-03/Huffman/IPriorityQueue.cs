using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Huffman
{
    public interface IPriorityQueue<TItem, in TWeight> where TWeight : IComparable<TWeight>
    {
        void Enqueue(TItem item, TWeight weight);
        TItem Dequeue();
        int Count { get; }
    }
}
