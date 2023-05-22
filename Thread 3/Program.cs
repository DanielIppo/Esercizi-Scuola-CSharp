using System;
using System.IO;
using System.Threading;

class Thread_3
{
    static CountdownEvent countdown;

    static void searchWord(){
        
    } 

    public static void Main(string[] args)
    {
        try
        {
            // Only get files that begin with the letter "c".
            string[] dirs = Directory.GetFiles(args[0], "*.txt");
            string[] words = args.Skip(1).ToArray();
            countdown = new CountdownEvent(words.Length);

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