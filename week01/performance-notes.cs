public class Notes
{
    // using a stopwatch to compare performance
    public void Run()
    {
        var executionTime = Time(() => LotsOfLoops(100), 10);
        Console.WriteLine($"Execution Time: {executionTime} ms");
    }

    private void LotsOfLoops(int n)
    {
        int total = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                for (int k = 0; k < n; k++)
                {
                    total += (i * j * k);
                }
            }
        }

        Console.WriteLine(total);
    }

    private double Time(Action executeAlgorithm, int times)
    {
        var sw = Stopwatch.StartNew();
        for (var i = 0; i < times; ++i)
        {
            executeAlgorithm(); // Calls the action passed in to this method
        }

        sw.Stop();
        return sw.Elapsed.TotalMilliseconds / times;
    }

    //     We encapsulate all of the Stopwatch calls into the Time() function. The following may help you understand this code better:

    //     () => LotsOfLoops(100) in the Run function creates a function that will always call LotsOfLoops with the parameter of 100 each time it's called. This is called a C# Action and is received into the executeAlgorithm parameter in the Time function.
    //     Time(() => LotsOfLoops(100), 10); tells the Time function to execute the Action 10 times.
    //     var sw = Stopwatch.StartNew(); creates a new Stopwatch object and starts timing right away.
    //     sw.Stop(); ends the timer and allows the program to get the Elapsed time.







    // measure performance by counting
    public void Run()
    {
    var stopwatch = Stopwatch.StartNew();
    var work = LotsOfLoops(1000);

    stopwatch.Stop();

    // This will display 1000000
    Console.WriteLine("Innermost count is: {0}", work);
    
    // The time displayed will vary based on your computer
    Console.WriteLine("Execution Time in milliseconds: {0}", stopwatch.Elapsed.TotalMilliseconds);
    }

    private int LotsOfLoops(int n)
    {
    int total = 0;
    int count = 0; // Variable for instrumentation 

    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
        for (int k = 0; k < n; k++)
        {
            total += (i*j*k);
            count++;  // Count the number of times in the inner-most loop
        }
        }
    }

    Console.WriteLine(total);

    return count;
    }
}