namespace Thread_2;
using System;
using System.Threading;
class Program
{

    static CountdownEvent countdown;
    static void searchWord(string word, string[] lines, string fileName){
        int count = 0;
        foreach (string line in lines)
        {
            string[] splittedLine = line.Split(' ');
            foreach(string w in splittedLine)
            {
                if (w == word)
                {
                    count++;
                }
            }
        }
        Console.WriteLine("La parola {0} è presente {1} volte nel file {2}", word, count, fileName);
        countdown.Signal();
    } 
    static void Main(string[] args)
    {
        Console.Write("Inserisci il nome del file da aprire, e le paole chiavi da cercare all'interno del file: ");
        string[] words = Console.ReadLine().Split(' ');
        string path = words[0];
        string[] lines = File.ReadAllLines("./" + path);
        words = words.Skip(1).ToArray();
        int wordsLen = words.Length;
        countdown = new CountdownEvent(wordsLen);

        
        foreach (string word in words)
        {
            Thread t = new Thread(() => searchWord(word, lines, path));
            t.Start();
        }

        countdown.Wait();

        Console.WriteLine("Il programma è terminato");
    }
}