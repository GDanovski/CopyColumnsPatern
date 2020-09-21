using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CopyColumnsPatern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("File dir:");
            string dir = Console.ReadLine();
            string dirOut = Path.GetDirectoryName(dir) + @"\output.txt";
            Console.WriteLine("Copy from column:");
            int start = int.Parse(Console.ReadLine());
            Console.WriteLine("Copy after every columns:");
            int step = int.Parse(Console.ReadLine());

            string[] input;
            List<List<string>> output = new List<List<string>>();

            StreamReader sr = new StreamReader(dir);
            StreamWriter sw = new StreamWriter(dirOut);
            string line = sr.ReadLine();

            while (line != null)
            {
                input = line.Split(new string[] { "\t" }, StringSplitOptions.None);
                var vals = new List<string>();

                for (int i = start; i < input.Length; i += step)
                    vals.Add(input[i]);
                output.Add(vals);
                
                line = sr.ReadLine();
            }
            sw.WriteLine(string.Join("\t", output[0]));

            for (int i = output.Count() - 1; i >= 1; i--)
            {
                sw.WriteLine(string.Join("\t", output[i]));
               // sw.WriteLine(string.Join("\t", output[i]));
            }

            for (int i = 1; i < output.Count(); i++)
            {
                sw.WriteLine(string.Join("\t", output[i]));
               // sw.WriteLine(string.Join("\t", output[i]));
            }

            sr.Close();
            sw.Close();
            sr = null;
            sw = null;
            input = null;
            output.Clear();
            output = null;
        }        
    }
}
