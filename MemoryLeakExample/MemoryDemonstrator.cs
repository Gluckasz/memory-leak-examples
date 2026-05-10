namespace MemoryLeakExample
{
    internal class MemoryDemonstrator
    {
        public static void LeakUnmanagedMemory()
        {
            for (int i = 0; i < 10; i++)
            {
                var leaker = new UnmanagedAllocator();
                leaker.Allocate1MB();
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            Console.WriteLine("Allocated and leaked unmanaged memory.");
        }

        private static readonly List<byte[]> _leakedObjects = [];

        public static void LeakManagedMemory()
        {
            for (int i = 0; i < 10; i++)
            {
                var block = new byte[1024 * 1024];
                _leakedObjects.Add(block);
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            Console.WriteLine("Allocated and leaked managed memory.");
        }

        public static void HandleUnmanagedMemory()
        {
            for (int i = 0; i < 10; i++)
            {
                using var leaker = new UnmanagedAllocator();
                leaker.Allocate1MB();
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            Console.WriteLine("Allocated and deallocated unmanaged memory.");
        }

        private readonly List<byte[]> _notLeakedObjects = [];

        public void HandleManagedMemory()
        {
            for (int i = 0; i < 10; i++)
            {
                var block = new byte[1024 * 1024];
                _notLeakedObjects.Add(block);
            }
        }
    }
}
