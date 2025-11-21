using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Insomnia;

internal static partial class NativeMethods
{
    [LibraryImport("kernel32.dll", SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    internal static partial EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);
}

internal enum EXECUTION_STATE : uint
{
    NONE = 0x00000000u,
    ES_SYSTEM_REQUIRED = 0x00000001u,
    ES_DISPLAY_REQUIRED = 0x00000002u,
    ES_USER_PRESENT = 0x00000004u,
    ES_AWAYMODE_REQUIRED = 0x00000040u,
    ES_CONTINUOUS = 0x80000000u,
}
