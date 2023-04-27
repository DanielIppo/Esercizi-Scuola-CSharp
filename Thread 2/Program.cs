namespace Thread_2;
class Program
{

    static void searchWord(string word, string path){
        string[] lines = File.ReadAllLines("./" + path);
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
        Console.WriteLine("La parola {0} è presente {1} volte nel file {2}", word, count, path);
    } 
    static void Main(string[] args)
    {
        Console.Write("Inserisci il nome del file da aprire, e le paole chiavi da cercare all'interno del file: ");
        string[] words = Console.ReadLine().Split(' ');
        string path = words[0];
        words = words.Skip(1).ToArray();
        
        foreach (string word in words)
        {
            Thread t = new Thread(() => searchWord(word, path));
            t.Start();
        }

        Thread.Sleep(1000);

        Console.WriteLine("Il programma è terminato");
    }
}