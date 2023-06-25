using System;
using System.Threading;

Console.WriteLine("Main thread started");

Thread thread1 = new Thread(Thread1Fun);
Thread thread2 = new Thread(Thread2Fun);

thread1.Start();
thread2.Start();

// czeka na zakończenie wątku
/*thread1.Join(); 
Console.WriteLine("th1 ended");
thread2.Join();
Console.WriteLine("th2 ended");*/

if (thread1.Join(1000)) // czeka w określonym czasie
{
    Console.WriteLine("Thread1Fun done");
}
else
{
    Console.WriteLine("Thread1Fun not done in 1 sec");
}
thread2.Join();
Console.WriteLine("Thread2Fun done");

if (thread1.IsAlive) // czy dalej pracuje wątek
{
    Console.WriteLine("Th1 is still doing stuff");
}
else
{
    Console.WriteLine("Th1 completed");
}

Console.WriteLine("Main thread ended");

static void Thread1Fun()
{
    Console.WriteLine("th1 started");
    Thread.Sleep(3000);
    Console.WriteLine("th1 ended");
}

static void Thread2Fun()
{
    Console.WriteLine("th2 started");
}

int x = 69;

async void Do(){
    await Task.Run(async () => {
        thread1.Join();
    });
    Console.WriteLine("Done");
}

Task.Run(()=>{ // async programing 
    Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
    Console.WriteLine(x);
});

Do();