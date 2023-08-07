using AsyncProg;
using AsyncProgramming;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
class Kitchen
{

    public static void SyncronousBreakfast()
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        Coffe cup = SyncBreakfast.PourCoffe();
        Console.WriteLine("Coffe is ready");

        Toast toast = SyncBreakfast.ToastBread(2);
        SyncBreakfast.ApplyButter(toast);
        SyncBreakfast.ApplyJam(toast);
        Console.WriteLine("Toast is ready..");

        Egg eggs = SyncBreakfast.FryEggs(2);
        Console.WriteLine("Eggs are ready..");

        Console.WriteLine("Breakfast is ready ..");

        Console.WriteLine($"Syncronous breakfast is ready in {stopwatch.Elapsed} ");
    }

    public static async Task ASyncronousBreakfast()
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        AsyncBreakfast.PourCoffe();
        Console.WriteLine("Coffe is ready.");

        Task<Toast> toastTask = AsyncBreakfast.ToastBreadAsync(2);
        Task<Egg> eggTask = AsyncBreakfast.FryEggsAsync(2);

        Toast toast = await toastTask;
        AsyncBreakfast.ApplyButter(toast);
        AsyncBreakfast.ApplyJam(toast);
        Console.WriteLine("Toast is ready..");

        Egg egg = await eggTask;
        Console.WriteLine("Eggs are ready");
        Console.WriteLine("Breakfast is ready");
        Console.WriteLine($"Async breakfast time is {stopwatch.Elapsed}");

     }

    public static async Task ASyncronousBreakfastBetterWay()
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        AsyncBreakfast.PourCoffe();
        Console.WriteLine("Coffe is ready.");

        Task<Toast> toastTask = AsyncBreakfast.ToastBreadAsync(2);
        Task<Egg> eggTask = AsyncBreakfast.FryEggsAsync(2);

        var breakfastTasks = new List<Task> { toastTask, eggTask };

        while (breakfastTasks.Count > 0)
        {
            Task finishTask= await Task.WhenAny(breakfastTasks);
            if(finishTask==eggTask)
            {
                Console.WriteLine("Eggs are ready");
            }
            else if(finishTask==toastTask)
            {
                AsyncBreakfast.ApplyButter(await toastTask);
                AsyncBreakfast.ApplyJam(await toastTask);
                Console.WriteLine("Toast is ready..");
            }

        breakfastTasks.Remove(finishTask);
        }
     Console.WriteLine($"Async better breakfast time is {stopwatch.Elapsed}");

    }
}