using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait.Task1.CancellationTokens;

internal static class Calculator
{
    // todo: change this method to support cancellation token
    public static async Task<long> Calculate(int n, CancellationToken token)
    {
        long sum = 0;
        try
        {
            await Task.Run(() =>
            {

                for (var i = 0; i < n; i++)
                {
                    token.ThrowIfCancellationRequested();
                    // i + 1 is to allow 2147483647 (Max(Int32)) 
                    Console.WriteLine(i);
                    Thread.Sleep(1000);
                    sum = sum + (i + 1);

                }

            }, token);
        }
        catch (OperationCanceledException ex)
        {
            Console.WriteLine("Current task is cancelled with the number"+ n);
        }

            
        
        return sum;
    }
}
