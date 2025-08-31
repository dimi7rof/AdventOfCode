using static AdventOfCodeWeb.Endpoints.Handlers;

namespace AdventOfCodeWeb.Endpoints;

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
