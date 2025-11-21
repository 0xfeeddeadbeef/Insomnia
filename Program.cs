using System;
using static Insomnia.NativeMethods;

namespace Insomnia;

internal static class Program
{
    private static int Main()
    {
        var prevState = SetThreadExecutionState(
            EXECUTION_STATE.ES_CONTINUOUS |
            EXECUTION_STATE.ES_SYSTEM_REQUIRED |
            EXECUTION_STATE.ES_AWAYMODE_REQUIRED |
            EXECUTION_STATE.ES_DISPLAY_REQUIRED);

        if (prevState == EXECUTION_STATE.NONE)
        {
            Console.Error.WriteLine("Error: Failed to set the thread execution state.");
            return 1;
        }

        Console.WriteLine("Press [Enter] to allow sleeping");
        _ = Console.ReadLine();

        prevState = SetThreadExecutionState(prevState);
        if (prevState == EXECUTION_STATE.NONE)
        {
            Console.Error.WriteLine("Error: Failed to reset the thread execution state.");
            return 1;
        }

        return 0;
    }
}
