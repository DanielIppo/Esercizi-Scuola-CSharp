/*Creare un programma in c# con 2 thread il primo riempie un 
vettore con 100 numeri a caso il secondo riempie la seconda 
parte del vettore con altri numeri a caso. alla fine effettuare la somma  
*/

using System;
using System.Threading;

class Esercizio2{

    public int[] array = new int[100];

    static void fillArray1(){
        for(int i = 0; i < esercizio2.array.Length/2; i++){
            esercizio2.array[i] = new Random().Next(0, 100);
        }
    }

    static void fillArray2(){
        for(int i = esercizio2.array.Length/2; i < esercizio2.array.Length; i++){
            esercizio2.array[i] = new Random().Next(0, 100);
        }
    }

    static void Main(string [] args){

        int sum = 0;

        Thread t1 = new Thread(new ThreadStart(fillArray1()));
        
        t1.Start();

        fillArray2();

        t1.Join();

        for(int i = 0; i < esercizio2.array.Length; i++){
            sum += esercizio2.array[i];
        }

        Console.WriteLine("La somma è: " + sum);
    }
}