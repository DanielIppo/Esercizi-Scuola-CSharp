using System;
using System.Threading;

class Esercizio1{
    static void printX(){
        Console.WriteLine("X");
    }
    static void printY(){
        Console.WriteLine("Y");
    }

    static void Main(string[] args){
        Thread t1 = new Thread(new ThreadStart(printX));
        Thread t2 = new Thread(new ThreadStart(printY));
        t1.Start();
        t2.Start();

        t1.Join();
        t2.Join();

        Console.WriteLine("Fine");
    }
}