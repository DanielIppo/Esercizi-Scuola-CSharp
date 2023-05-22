using System;
using System.IO;
using System.Threading;

class Thread_3
{
    public static void Main(string[] args)
    {
        try
        {
            // Only get files that begin with the letter "c".
            string[] dirs = Directory.GetFiles(args[0], "*.txt");
            Console.WriteLine("The number of files starting with c is {0}.", dirs.Length);
            foreach (string dir in dirs)
            {
                
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("The process failed: {0}", e.ToString());
        }
    }
}