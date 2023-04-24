/*Creare un Programma in c# che con due thread esegue un 
countDown da 100 a 0 e un countUp da 0 a 100*/

using System;
using System.Threading;

class Esercizio3{
    
        static void countDown(){
            for(int i = 100; i >= 0; i--){
                Console.WriteLine(i);
            }
        }
    
        static void countUp(){
            for(int i = 0; i <= 100; i++){
                Console.WriteLine(i);
            }
        }
    
        static void Main(string [] args){
    
            Thread t1 = new Thread(new ThreadStart(countDown));
    
            t1.Start();
    
            countUp();

            t1.Join();
    
            Console.WriteLine("Fine");
        }
}