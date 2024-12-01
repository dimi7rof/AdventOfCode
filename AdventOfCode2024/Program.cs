using AdventOfCode2024.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapEndpoints();
app.UseStaticFiles();

await app.RunAsync();
