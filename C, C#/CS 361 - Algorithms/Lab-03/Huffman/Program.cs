using System;
using System.Collections.Generic;
using System.IO;

namespace Huffman
{
    class Program
    {
        static void Main(string[] args)
        {
            var filename = "TestFile.txt";

            var uncompressedFileReader = new UncompressedFileReader(filename);

            var frequencies = uncompressedFileReader.Frequencies;

            var huffTree = new HuffTree<char, int>(frequencies);

            var look_up_table = huffTree.Encoding(frequencies);

            var lines = File.ReadAllLines(filename);

            string encoded_string = Encoder(lines, look_up_table);

            var decoded_string = Decoder(encoded_string, look_up_table);

            File.WriteAllText(@"C:\Users\strik\source\repos\Huffman\Huffman\Encoded_String.txt", encoded_string);
            File.WriteAllText(@"C:\Users\strik\source\repos\Huffman\Huffman\Decoded_String.txt", decoded_string);

        }

        private static string Encoder(string[] lines, Dictionary<char,string>look_up_table)
        {
            string encoded_string = "";

            foreach (var line in lines)
            {
                var characters = line.ToCharArray();
                foreach (var character in characters)
                {
                    foreach(var (table_character, code) in look_up_table)
                    {
                        if (table_character == character)
                        {
                            encoded_string += code;
                        }
                    }
                }
            }

            return encoded_string;
        }

        private static string Decoder(string encoded_string, Dictionary<char, string> look_up_table)
        {
            var decoded_string = "";
            for(int i = 1; i < encoded_string.Length + 1; ++i)
            {
                foreach (var (table_character, code) in look_up_table)
                {
                    var sub_string = encoded_string.Substring(0, i);
                    if ( sub_string == code)
                    {
                        decoded_string += table_character;
                        encoded_string = encoded_string.Substring(i);
                        i = 0;
                    }
                }
            }

            return decoded_string;
        }
    }
}
