enum WaitAnimationType
{
    None,           // Waits without animation
    Dots,           // Prints points with a given interval while waiting
    DashSlashPipe   // Shows a given number of spinning dashes while waiting
}

static class Wait
{
    /// <summary>
    /// Makes the user wait
    /// </summary>
    /// <param name="delayMS">Number of milliseconds to wait</param>
    /// <param name="intervalMS">Interval for the animation (does nothing for WaitAnimationType.None). 0 sets animationType to WaitAnimationType.None</param>
    /// <param name="animationType">See enum WaitAnimationType above</param>
    /// <param name="endWithNewLine">Adds a newline to the console after waiting</param>
    /// <param name="animationCharCount">Number of characters for the animation (only for WaitAnimationType.DashSlashPipe)</param>
    public static void Waiting(int delayMS, int intervalMS = 0, WaitAnimationType animationType = WaitAnimationType.None, bool endWithNewLine = false, int animationCharCount = 1)
    {
        if (intervalMS == 0)
            animationType = WaitAnimationType.None;

        switch (animationType)
        {
            case WaitAnimationType.None:
                Thread.Sleep(delayMS);
                break;

            case WaitAnimationType.Dots:
                for (int i = 0; i < delayMS / intervalMS; i++)
                {
                    Console.Write(".");
                    Thread.Sleep(intervalMS);
                }
                break;

            case WaitAnimationType.DashSlashPipe:
                string letters = "-\\|/";
                ValueTuple<int, int> cursorPosition = Console.GetCursorPosition();
                cursorPosition.Item1++;

                for (int i = 0; i < delayMS / intervalMS; i++)
                {
                    Console.SetCursorPosition(cursorPosition.Item1, cursorPosition.Item2);
                    Console.Write(new string(letters[i % letters.Length], animationCharCount));
                    Thread.Sleep(intervalMS);
                }
                Console.SetCursorPosition(cursorPosition.Item1, cursorPosition.Item2);
                Console.Write(new string(' ', animationCharCount));
                break;
        }

        if (endWithNewLine)
            Console.WriteLine();
    }
}