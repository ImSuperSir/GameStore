using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace ImSuperSir.GameStore.API.ErrorHandling;

public static class ErrorHandlingExtensions
{

    public static void ConfigureExceptionHandler(this IApplicationBuilder app)
    {

        app.Run(async (context) =>
        {
            var logger = context.RequestServices.GetRequiredService<ILoggerFactory>()
                            .CreateLogger("Error Handler");

            var exceptionDetails = context.Features.Get<IExceptionHandlerFeature>();

            var exception = exceptionDetails?.Error;

            logger.LogError(exception, "Could not process a requext on machine {MachineName}. TraceId: {TraceId}",
                    Environment.MachineName,
                    Activity.Current?.TraceId
                );

            var problem = new ProblemDetails() { 
                Title = "",
                Status = StatusCodes.Status500InternalServerError,
                Extensions =
                {
                    {"traceId", Activity.Current?.TraceId }
                }
            };

            var environment = context.RequestServices.GetRequiredService<IHostEnvironment>();
            if (environment.IsDevelopment())
            {
                problem.Detail = exception?.ToString();
            }

            await Results.Problem(problem).ExecuteAsync(context);

        });

    }
}
