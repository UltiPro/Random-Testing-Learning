using System;
using System.Threading;

Console.WriteLine("Hello, World!");

Thread.Sleep(1000); // sleep method

new Thread(() => {
    Console.WriteLine("Theard 1");
}).Start();

