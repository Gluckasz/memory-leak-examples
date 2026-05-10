using MemoryLeakExample;

Console.WriteLine("Press any key for memory leak to happen.");
Console.ReadLine();

MemoryDemonstrator.LeakUnmanagedMemory();
MemoryDemonstrator.LeakManagedMemory();

Console.WriteLine("Press any key and see the memory managed correctly.");
Console.ReadLine();

MemoryDemonstrator.HandleUnmanagedMemory();

static void AllocateManagedMemory()
{
    var memoryDemonstrator = new MemoryDemonstrator();
    memoryDemonstrator.HandleManagedMemory();
}

AllocateManagedMemory();
GC.Collect();
GC.WaitForPendingFinalizers();
GC.Collect();

Console.WriteLine("Allocated and deallocated managed memory.");

Console.WriteLine("Press any key to exit the app.");
Console.ReadLine();
