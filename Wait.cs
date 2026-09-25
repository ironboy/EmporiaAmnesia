enum WaitAnimationType
{
    None,
    Dots,
    DashSlashPipe
}

static class Wait
{
    public static void Waiting(int delayMS, int intervalMS, WaitAnimationType animationType, bool endWithNewLine)
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
                    Console.Write(letters[i % letters.Length]);
                    Thread.Sleep(intervalMS);
                }
                break;
        }

        if (endWithNewLine)
            Console.WriteLine();
    }
}