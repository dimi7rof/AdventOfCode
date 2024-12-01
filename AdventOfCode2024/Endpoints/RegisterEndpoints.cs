namespace AdventOfCode2024.Endpoints;

public static class RegisterEndpoints
{
    public static void MapEndpoints(this WebApplication app)
    {
        app.MapGet("/", Handlers.MainPageHandler);
        app.MapGet("days", Handlers.DayHandler);
        app.MapPost("input", Handlers.InputHandler);
    }
}
