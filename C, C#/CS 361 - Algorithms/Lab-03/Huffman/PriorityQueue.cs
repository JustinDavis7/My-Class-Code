using System;
using System.Collections.Generic;
using System.Linq;

namespace Huffman
{
    public class PriorityQueue<TItem, TWeight> : IPriorityQueue<TItem, TWeight> where TWeight : IComparable<TWeight>
    {
        //readonly prevents us from later doing something like _queue = new List.... We can still update the date inside of it though.
        private readonly IList<Tuple<TItem, TWeight>> _queue = new List<Tuple<TItem, TWeight>>();
        public void Enqueue(TItem item, TWeight weight)
        {
            var tuple = new Tuple<TItem, TWeight>(item, weight);
            _queue.Add(tuple);
            int i = _queue.Count - 1;
            while (i > 0 && _queue.Count > 1)
            {
                if ((dynamic)_queue[i].Item2 > (dynamic)_queue[i - 1].Item2)
                    break;
                else
                {
                    var temp1 = _queue[i];
                    _queue[i] = _queue[i - 1];
                    _queue[i - 1] = temp1;
                    --i;
                }
            }
        }

        public TItem Dequeue()
        {
            if (Count <= 0)
                throw new Exception("Queue is empty!");

            // TODO: Remove Min and Heapify and return min
            var min = _queue[0].Item1;

            _queue.RemoveAt(0); // or var min = _queue[0] _queue.Remove(min) return min.Item1;
            //int i = _queue.Count - 1;
            //while (i > 0 && _queue.Count > 1)
            //{
            //    if ((dynamic)_queue[i].Item2 > (dynamic)_queue[i - 1].Item2)
            //        break;
            //    else
            //    {
            //        var temp1 = _queue[i];
            //        var temp2 = _queue[i - 1];
            //        _queue[i] = temp2;
            //        _queue[i - 1] = temp1;
            //        --i;
            //    }
            //}
            return min;
        }
        
        public int Count => _queue.Count; 
    }
}