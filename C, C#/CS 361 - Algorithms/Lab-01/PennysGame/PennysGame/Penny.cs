using System;
using System.Collections.Generic;
using System.Text;

namespace PennysGame
{
    public class Penny
    {
        public Face Face { get; set; }

        public override string ToString()
        {
            return $"Penny with face {Face}";
        }
    }
}
