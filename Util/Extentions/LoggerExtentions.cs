using System.Diagnostics;
using Microsoft.Extensions.Logging; // ← ADICIONAR

namespace IntegracaoCepsaBrasil.Util.Extentions;

public static class LoggerExtentions
{
    public static async Task<T> ProfileAsync<T>(this ILogger logger, string message, Func<Task<T>> func)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        var result = await func();

        stopwatch.Stop();

        logger.LogInformation($"{message} - Elapsed time: {stopwatch.ElapsedMilliseconds}ms");

        return result;
    }
}
