using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace HW2
{
    public class Program
    {
        private static void printUsage()
        {
            Console.WriteLine("Usage is:\n" + 
			    "\tjava Main C inputfile outputfile\n\n" +
			    "Where:" + 
			    "  C is the column number to fit to\n" +
			    "  inputfile is the input text file \n" +
			    "  outputfile is the new output file base name containing the wrapped text.\n" +
			    "e.g. java Main 72 myfile.txt myfile_wrapped.txt");   
        }
        public static void Main(string [] args)
        {
            int c = 400;
            string inputFilename;
            string outputFilename = "output.txt";
            StreamReader scanner = null;
            

            if (args.Length != 3)
            {
                printUsage();
                Environment.Exit(0);
            }
            try
            {
                c = int.Parse(args[0]);
                inputFilename = args[1];
                outputFilename = args[2];
                scanner = new StreamReader(inputFilename);
            }
            catch(FileNotFoundException e)
            {
                Console.WriteLine("Could not find the input file.");
                Environment.Exit(0);
            }
            catch(Exception e)
            {
                Console.WriteLine("Something is wrong with the input.");
                printUsage();
                Environment.Exit(0);
            }

            QueueInterface<string> words = new LinkedQueue<string>();
            string line ="";
            while ((line = scanner.ReadLine()) != null)
            {
                if(line != "\n" && line != "\t")
                {
                    string word = line;
                    string[] temp = word.Split();
                    foreach(var item in temp)
                        words.Push(item);
                }
            }
            scanner.Close();

            int spacesRemaining = wrapSimply(words, c, outputFilename);
            Console.WriteLine("Total spaces remaining (Greedy): " + spacesRemaining);
        }

        private static int wrapSimply(QueueInterface<string> words, int columnLength, string outputFilename)
        {
            StreamWriter o = null;
            try
            {
                o = new StreamWriter(outputFilename);
            }
            catch(FileNotFoundException e)
            {
                Console.WriteLine("Cannot creat or open" + outputFilename + " for writing. Using standard output instead.");
                o = new StreamWriter(Console.OpenStandardOutput());
            }

            int col = 1;
            int spacesRemaining = 0;
            while(!words.IsEmpty())
            {
                string str = words.Peek();
                int len = str.Length;

                if(col == 1)
                {
                    o.Write(str);
                    col += len;
                    words.Pop();
                }
                else if ((col + len) >= columnLength)
                {
                    o.WriteLine();
                    spacesRemaining += (columnLength - col) + 1;
                    col = 1;
                }
                else
                {
                    o.Write(" ");
                    o.Write(str);
                    col += (len+1);
                    words.Pop();
                }
            }
            o.WriteLine();
            o.Flush();
            o.Close();
            return spacesRemaining;
        }
    }
}