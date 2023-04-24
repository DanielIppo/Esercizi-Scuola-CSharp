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
        t1.Start();

        printY();

        t1.Join();

        Console.WriteLine("Fine");
    }
}