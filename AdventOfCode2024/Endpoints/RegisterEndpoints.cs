using static AdventOfCode2024.Endpoints.Handlers;

namespace AdventOfCode2024.Endpoints;

public static class RegisterEndpoints
{
    public static void MapEndpoints(this WebApplication app)
    {
        app.MapGet("/", YearsPageHandler);
        app.MapGet("/year", DaysPageHandler);
        app.MapGet("/day", InputPageHandler);
        app.MapPost("/execute", ResultPageHandler);
    }
}
