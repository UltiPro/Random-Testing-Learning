using System;
using System.Threading;

Console.WriteLine("Hello, World!");
/*
Thread th1 = new Thread(() => {
    Thread.Sleep(5000);
    Console.WriteLine("Theard 1");
});

th1.Start();

new Thread(()=>{
    Thread.Sleep(2000);
    Console.WriteLine("Theard 2");
}).Start();

th1.Join(1000);

Console.WriteLine("end");
*/
Thread.Sleep(1000); // sleep method

new Thread(() =>
{ // new thread
    Console.WriteLine("Theard 1");
}).Start();

TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>(); //task complete obj

Thread thread = new Thread(() =>
{
    Console.WriteLine($"Thread number: {Thread.CurrentThread.ManagedThreadId} started");
    Thread.Sleep(10000);
    taskCompletionSource.TrySetResult(true);
    Console.WriteLine($"Thread number: {Thread.CurrentThread.ManagedThreadId} ended");
});

Console.WriteLine($"Thread number: {thread.ManagedThreadId}"); //id of thread
thread.Start();

var test = taskCompletionSource.Task.Result;

Console.WriteLine(test);

// next part polls and background theard

Enumerable.Range(0, 100).ToList().ForEach(e =>
{
    ThreadPool.QueueUserWorkItem((o) => // dopóki działa program
    {
        Console.WriteLine($"Thread number: {Thread.CurrentThread.ManagedThreadId} started");
        Thread.Sleep(1000);
        Console.WriteLine($"Thread number: {Thread.CurrentThread.ManagedThreadId} ended");
    });
    /*new Thread(() => {
        Console.WriteLine($"Thread number: {Thread.CurrentThread.ManagedThreadId} started"); 
        Thread.Sleep(1000);
        Console.WriteLine($"Thread number: {Thread.CurrentThread.ManagedThreadId} ended"); 
    }).Start();*/
});

new Thread(() =>
{
    Console.WriteLine($"Thread number: {Thread.CurrentThread.ManagedThreadId} background started");
}){ IsBackground = true }.Start();

Console.ReadLine();
