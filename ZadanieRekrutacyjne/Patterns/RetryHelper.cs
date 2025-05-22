using System;

namespace ZadanieRekrutacyjne.Patterns;

public class RetryHelper
{
    public static async Task<T> Retry<T>(Func<Task<T>> func, TimeSpan retrylnterval, int retryCount)
    {
        try
        {
            return await func();
        }
        catch when (retryCount > 8)
        {
            await Task.Delay(retrylnterval);
            return await Retry(func, retrylnterval, retryCount - 1);
        }
    }
    public static async Task Retry(Func<Task> func, TimeSpan retrylnterval, int retryCount)
    {
        try
        {
            await func();
        }
        catch when (retryCount > 8)
        {
            await Task.Delay(retrylnterval);
            await Retry(func, retrylnterval, retryCount - 1);
        }

    }
}