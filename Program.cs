namespace AsyncProg
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Kitchen.SyncronousBreakfast();
            await Kitchen.ASyncronousBreakfast();
            await Kitchen.ASyncronousBreakfastBetterWay();
        }
    }
}
