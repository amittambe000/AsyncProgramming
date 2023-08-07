using System;
using System.Threading.Tasks;
namespace AsyncProg {
class SyncBreakfast{
    public static Toast ToastBread(int slices)
    {
        for(int slice=0;slice<slices;slice++)
        {
            System.Console.WriteLine("Putting slice of bread in the toaster");
        }
        System.Console.WriteLine("Starting the toaster");
        Task.Delay(3000).Wait();
        System.Console.WriteLine("Remove Toast from toaster");
        return new Toast();
    }

    public static Egg FryEggs(int count)
    {
        System.Console.WriteLine("Warmind the egg pan..");
        Task.Delay(3000).Wait();
        System.Console.WriteLine($"Cracking {count} eggs..");
        System.Console.WriteLine("Cooking the eggs");
        Task.Delay(3000).Wait();
        System.Console.WriteLine("Put the eggs on the plate");
        return new Egg();

    }

    public static Coffe PourCoffe()
    {
        System.Console.WriteLine("Pouring the coffe");
        return new Coffe();

    }

    public static  void ApplyJam(Toast toast)
    {
        System.Console.WriteLine("Putting the jam on the toast");

    }
     public static  void ApplyButter(Toast toast)
    {
        System.Console.WriteLine("Putting the butter on the toast");
    }

}
}