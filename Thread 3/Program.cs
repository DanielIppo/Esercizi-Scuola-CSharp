using System;
using System.IO;
using System.Threading;

class Thread_3
{
    static CountdownEvent countdown;
    static int[] count;

    static void searchWord(string[] words, string path)
    {
        string[] lines = File.ReadAllLines("./" + path);
        foreach (string line in lines)
        {
            string[] splittedLine = line.Split(' ');
            foreach(string w in splittedLine)
            {
                for (int i = 0; i < words.Length; i++)
                {
                    if (w == words[i])
                    {
                        count[i]++;
                    }
                }
            }
        }
        countdown.Signal();
    } 

    public static void Main(string[] args)
    {
        try
        {
            // Only get files that begin with the letter "c".
            string[] paths = Directory.GetFiles(args[0], "*.txt");
            string[] words = args.Skip(1).ToArray();
            countdown = new CountdownEvent(paths.Length);
            count = new int[words.Length];

            foreach (string path in paths)
            {
                Thread t = new Thread(() => searchWord(words, path));
                t.Start();
            }

            countdown.Wait();

            for (int i = 0; i < words.Length; i++)
            {
                Console.WriteLine("La parola {0} è presente {1} volte", words[i], count[i]);
            }
            Console.WriteLine("############### Il programma è terminato ###############");
        }
        catch (Exception e)
        {
            Console.WriteLine("The process failed: {0}", e.ToString());
        }
    }
}