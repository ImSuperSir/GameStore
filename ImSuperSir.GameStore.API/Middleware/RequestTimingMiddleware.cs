using System.Diagnostics.Metrics;
using System.Diagnostics;

namespace ImSuperSir.GameStore.API.Middleware;

public class RequestTimingMiddleware
{
    private readonly RequestDelegate next;
    private readonly ILogger<RequestTimingMiddleware> logger;

    public RequestTimingMiddleware(RequestDelegate next, ILogger<RequestTimingMiddleware> logger)
    {
        this.next = next;
        this.logger = logger;
    }


    public async Task InvokeAsync(HttpContext context)
    {
        Stopwatch stopWatch = new();

        stopWatch.Start();

        try
        {
            await next(context);
        }
        finally
        {
            stopWatch.Stop();

            var ellapsedMilliseconds = stopWatch.ElapsedMilliseconds;

            logger.LogInformation("{RequestMethod} {RequesPath} request took {EllapsedMilloseconds}ms to complete",
                    context.Request.Method,
                    context.Request.Path,
                    ellapsedMilliseconds

                );
        }
    }
}
