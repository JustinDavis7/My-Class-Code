using System;
using System.Collections.Generic;
using System.Linq;

namespace Sorts
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var sizes = new int[] {128,256,512 };
            var compares = new long[] { 5, 6, 7 };

            for (var i = 0; i < sizes.Length; ++i)
            {
                var ratio = compares[i] / Math.Log(compares[i]);
            }


            //var insertionSort = new InsertionSort();

            //var data = new IComparable[] { 4, 5, 3, 6, 8, 4 };

            //var comparisons = insertionSort.Sort(data);

            //foreach (var i in data)
            //    Console.WriteLine($"{i} ");

            //Console.WriteLine($"The number of comparisons is: {comparisons}");

            //var quickSort = new QuickSort();

            //var data = new IComparable[] { 12,35,84,221,69,248,3,12,5,6,158};

            //foreach (var i in data)
            //    Console.Write($"{i} ");

            //var comparisons = quickSort.Sort(data);
            //Console.WriteLine();

            //foreach (var i in data)
            //    Console.Write($"{i} ");

            //Console.WriteLine();
            //Console.WriteLine($"The number of comparisons is: {comparisons}");
            var a = 100 / Math.Log(100);
            var b = 200 / Math.Log(100);
            var c = 300 / Math.Log(100);
            var d = 400 / Math.Log(100);
            var e = 500 / Math.Log(100);
            var f = 600 / Math.Log(100);
            //var g = 700 / Math.Log(70);
            //var h = 800 / Math.Log(80);
            var mean = (a + b + c + d + e + f )/6;

            var errora = Math.Abs(a - mean) / mean;
            var errorb = Math.Abs(b - mean) / mean;
            var errorc = Math.Abs(c - mean) / mean;
            var errord = Math.Abs(d - mean) / mean;
            var errore = Math.Abs(e - mean) / mean;
            var errorf = Math.Abs(f - mean) / mean;
            //var errorg = Math.Abs(g - mean) / mean;
            //var errorh = Math.Abs(h - mean) / mean;

            var errormean = (errora + errorb + errorc + errord + errore + errorf) / 6;

            //Console.Write($"{a}\n{b}\n{c}\n{d}\n{e}\n{f}\n Mean {mean}\n Errors \n{errora}\n{errorb}\n{errorc}\n{errord}\n{errore}\n{errorf}\nError mean {errormean}");
            Console.Write(7/Math.Log(128));
        }
    }
}
