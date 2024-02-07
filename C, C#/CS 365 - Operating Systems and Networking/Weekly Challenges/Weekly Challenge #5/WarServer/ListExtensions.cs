using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarServer
{
    public static class ListExtensions
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            var n = list.Count;
            var random = new Random();
                        
            while (n > 1)
            {
                var index = random.Next(0, n);
                (list[n - 1], list[index]) = (list[index], list[n - 1]);
                --n;
            }
        }
    }
}
