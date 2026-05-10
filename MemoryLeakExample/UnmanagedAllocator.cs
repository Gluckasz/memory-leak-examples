using System.Runtime.InteropServices;

namespace MemoryLeakExample
{
    public class UnmanagedAllocator : IDisposable
    {
        private IntPtr _buffer;

        public void Dispose()
        {
            FreeMemory();
            GC.SuppressFinalize(this);
        }

        public void Allocate1MB()
        {
            FreeMemory();
            _buffer = Marshal.AllocHGlobal(1024 * 1024);
        }

        private void FreeMemory()
        {
            if (_buffer != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(_buffer);
                _buffer = IntPtr.Zero;
            }
        }
    }
}
