using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmusementPark.New
{
    public class FoodCart
    {

        public static void Main(string[] args)
        {
            if(args.Length != 4)
            {
                Console.WriteLine("CMD Line Args error");
                return;
            }

            //                              Workers,                time between customers,     average service time,   length of program run time
            var foodCart = new FoodieCart(Convert.ToInt32(args[0]), Convert.ToInt32(args[1]), Convert.ToInt32(args[2]), Convert.ToInt32(args[3]));

            Console.WriteLine($"Workers: {Convert.ToInt32(args[0])}\nTime between customer arrival: {Convert.ToInt32(args[1])}\nAverage service time: {Convert.ToInt32(args[2])}\nLength of runtime: {Convert.ToInt32(args[3])}\n\n");

            foodCart.Run();
            
        }
    }
}
