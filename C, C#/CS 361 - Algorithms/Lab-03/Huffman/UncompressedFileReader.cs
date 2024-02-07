using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Huffman
{
    public class UncompressedFileReader
    {
        private readonly Dictionary<char, int> _frequencies = new Dictionary<char, int>();
        public UncompressedFileReader(string filename)
        {
            var lines = File.ReadAllLines(filename);

            foreach(var line in lines)
            {
                var characters = line.ToCharArray();
                
                foreach(var character in characters)
                {
                    if (_frequencies.ContainsKey(character))
                    {
                        ++_frequencies[character]; 
                    }
                    else
                    {
                        _frequencies[character] = 1;
                    }
                }
            }
        }

        //=> is the getter syntax. This allows you to get the _frequencies outside of this class.
        public Dictionary<char, int> Frequencies => _frequencies;
    }
}
