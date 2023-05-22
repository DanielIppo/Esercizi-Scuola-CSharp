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
                    //Compara le stringe mettendole in minuscolo, così da non avere problemi con doppioni o parole non contate
                    if (w.ToLower() == words[i].ToLower())
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
                int max = 0;
                int maxIndex = 0;
                for (int j = 0; j < words.Length; j++)
                {
                    if (count[j] > max)
                    {
                        max = count[j];
                        maxIndex = j;
                    }
                }
                Console.WriteLine("La parola {0} è presente {1} volte", words[maxIndex], count[maxIndex]);
                count[maxIndex] = 0;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Il processo è fallito: {0}", e.ToString());
        }
    }
}