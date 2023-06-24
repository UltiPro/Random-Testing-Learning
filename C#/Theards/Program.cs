using System;
using System.Threading;

Console.WriteLine("Hello, World!");

Thread.Sleep(1000); // sleep method

new Thread(() => { // new thread
    Console.WriteLine("Theard 1");
}).Start();

TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>(); //task complete obj

Thread thread = new Thread(() => {
    Console.WriteLine($"Thread number: {Thread.CurrentThread.ManagedThreadId} started"); 
    Thread.Sleep(1000);
    taskCompletionSource.TrySetResult(true);
    Console.WriteLine($"Thread number: {Thread.CurrentThread.ManagedThreadId} ended"); 
});

Console.WriteLine($"Thread number: {thread.ManagedThreadId}"); //id of thread
thread.Start();

var test = taskCompletionSource.Task.Result;

Console.WriteLine(test);

