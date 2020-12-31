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
            Console.WriteLine("Processing....");

            string[] dirs = new string[] {
                @"D:\Desktop\OldComp\Work\Data_after 06_2016\DoubleHit\Stoyno\MDC1_29_12_2020\long_last_new\blur\avg\results_FirsFocus_22length_1.txt",
                @"D:\Desktop\OldComp\Work\Data_after 06_2016\DoubleHit\Stoyno\MDC1_29_12_2020\long_last_new\blur\max\results_FirsFocus_22length_1.txt",
                @"D:\Desktop\OldComp\Work\Data_after 06_2016\DoubleHit\Stoyno\MDC1_29_12_2020\long_last_new\raw\avg\results_FirsFocus_22length_1.txt",
                @"D:\Desktop\OldComp\Work\Data_after 06_2016\DoubleHit\Stoyno\MDC1_29_12_2020\long_last_new\raw\max\results_FirsFocus_22length_1.txt",
                @"D:\Desktop\OldComp\Work\Data_after 06_2016\DoubleHit\Stoyno\MDC1_29_12_2020\long_last_new\blur\avg\results_FirsFocus_28length_1.txt",
                @"D:\Desktop\OldComp\Work\Data_after 06_2016\DoubleHit\Stoyno\MDC1_29_12_2020\long_last_new\blur\max\results_FirsFocus_28length_1.txt",
                @"D:\Desktop\OldComp\Work\Data_after 06_2016\DoubleHit\Stoyno\MDC1_29_12_2020\long_last_new\raw\avg\results_FirsFocus_28length_1.txt",
                @"D:\Desktop\OldComp\Work\Data_after 06_2016\DoubleHit\Stoyno\MDC1_29_12_2020\long_last_new\raw\max\results_FirsFocus_28length_1.txt"
            };
            
            int start = 70;
            int step = 71; 

            foreach (string dir in dirs)
            {
                string dirOut = dir.Replace(".txt", "_output.txt");
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

                Console.WriteLine("Processed - " + Path.GetFileNameWithoutExtension(dirOut));
            }
            Console.ReadLine();
        }        
    }
}
